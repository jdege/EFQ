using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using PeteMontgomery.PredicateBuilder;

namespace JDege.EFQ
{
    public static class EFQExtensions
    {
        #region predicate construction functions
        public static Expression<Func<T, bool>> ConstructPredicate<T>(this EFQ efq, object context = null)
        {
            // #TODO: Move IsUnary, etc., to extension methods
            if (efq.IsUnary())
                return efq.EFQType == EFQType.IsTrue
                    ? PredicateBuilder.True<T>()
                    : PredicateBuilder.False<T>();

            if (efq.IsAggregate())
                return efq.constructAggregatePredicate<T>(context);

            if (efq.IsMethodCall())
                return efq.constructMethodCallPredicate<T>(context);

            if (efq.IsStaticCall())
                return efq.constructStaticCallPredicate<T>(context);

            if (efq.IsAny())
                return efq.ConstructAnyPredicate<T>(context);

            return efq.ConstructSinglePredicate<T>(context);
        }

        private static Expression<Func<T, bool>> constructAggregatePredicate<T>(this EFQ efq, object context)
        {
            var predicate = efq.IsAnd() ? PredicateBuilder.True<T>() : PredicateBuilder.False<T>();

            foreach (var item in efq.AggregateList)
            {
                predicate = efq.IsAnd()
                    ? predicate.And(item.ConstructPredicate<T>(context))
                    : predicate.Or(item.ConstructPredicate<T>(context));
            }

            if (efq.IsNegate())
                predicate = negate(predicate);

            return predicate;
        }

        private static Expression<Func<T, bool>> negate<T>(Expression<Func<T, bool>> one)
        {
            if (one.Parameters.Count != 1)
                throw new InvalidOperationException("Cannot \"not\" a compound expression");
            var candidateExpr = one.Parameters[0];
            var body = Expression.Not(one.Body);

            return Expression.Lambda<Func<T, bool>>(body, candidateExpr);
        }

        private static Expression<Func<T, bool>> constructMethodCallPredicate<T>(this EFQ efq, object context)
        {
            var type = typeof(T);

            if (type.GetProperty(efq.FieldName) == null && type.GetField(efq.FieldName) == null)
                throw new MissingMemberException(type.Name, efq.FieldName);

            MethodInfo method;
            if (!methodMap.TryGetValue(efq.EFQType, out method))
                throw new ArgumentOutOfRangeException("EFQType", efq.EFQType, "Invalid filter operation");

            var parameter = Expression.Parameter(type);
            var member = Expression.PropertyOrField(parameter, efq.FieldName);
            var value = efq.constructConstantExpression<T>(efq.RightHandSide, context);

            try
            {
                var converted = (value.Type != member.Type)
                    ? (Expression)Expression.Convert(value, member.Type)
                    : (Expression)value;

                var methodExpression = Expression.Call(member, method, converted);

                var lambda = Expression.Lambda<Func<T, bool>>(methodExpression, parameter);

                return lambda;
            }
            catch (Exception)
            {
                throw new InvalidOperationException(
                    String.Format("Cannot convert value \"{0}\" of type \"{1}\" to field \"{2}\" of type \"{3}\"",
                        efq.RightHandSide, value.Type, efq.FieldName, member.Type));
            }
        }

        private static Expression<Func<T, bool>> constructStaticCallPredicate<T>(this EFQ efq, object context)
        {
            var type = typeof(T);

            if (type.GetProperty(efq.FieldName) == null && type.GetField(efq.FieldName) == null)
                throw new MissingMemberException(type.Name, efq.FieldName);

            var parameter = Expression.Parameter(type);
            var member = Expression.PropertyOrField(parameter, efq.FieldName);
            var value = efq.constructConstantExpression<T>(efq.RightHandSide, context);

            try
            {
                var converted = (value.Type != member.Type)
                    ? (Expression)Expression.Convert(value, member.Type)
                    : (Expression)value;

                var methodExpression = efq.getStaticCallMethod(efq.EFQType, member, converted);

                var lambda = Expression.Lambda<Func<T, bool>>(methodExpression, parameter);

                return lambda;
            }
            catch (Exception)
            {
                throw new InvalidOperationException(
                    String.Format("Cannot convert value \"{0}\" of type \"{1}\" to field \"{2}\" of type \"{3}\"",
                        efq.RightHandSide, value.Type, efq.FieldName, member.Type));
            }
        }

        private static Expression getStaticCallMethod(
            this EFQ efq,
            EFQType efqType,
            MemberExpression member,
            Expression converted)
        {
            if (efqType == EFQType.Like)
            {
                var methodExpression = Expression.Call(
                    typeof(DbFunctionsExtensions), "Like", Type.EmptyTypes,
                    Expression.Constant(EF.Functions), member, converted);

                return methodExpression;
            }

            // #TODO: use string interpolation
            throw new InvalidExpressionException(String.Format("Invalid EFQType {0}", efqType));
        }

        public static Expression<Func<T, bool>> ConstructAnyPredicate<T>(this EFQ efq, object context)
        {
            var type = typeof(T);

            var parameter = Expression.Parameter(type);

            if (efq.InnerCriteria == null)
                throw new MissingMemberException("\"Any\" criteria must have an innerCriteria");

            var member = efq.getMember<T>(type, parameter);

            var collectionType = member.Type;
            var memberType = collectionType.GenericTypeArguments[0];

            // #TODO: Use nameof()?
            var constructPredicateMethod = typeof(EFQExtensions).GetMethod("ConstructPredicate");
            var constructPredicateMethodGeneric = constructPredicateMethod.MakeGenericMethod(memberType);
            var innerPredicate = (Expression)constructPredicateMethodGeneric.Invoke(null, new object[] { efq.InnerCriteria, context });

            var call = Expression.Call(typeof(Enumerable), "Any",
                new Type[] { memberType }, new[] { member, innerPredicate });

            var lambda = Expression.Lambda<Func<T, bool>>(call, parameter);

            return lambda;
        }

        public static Expression<Func<T, bool>> ConstructSinglePredicate<T>(this EFQ efq, object context)
        {
            var type = typeof(T);

            var parameter = Expression.Parameter(type);

            var member = efq.getMember<T>(type, parameter);

            var value = efq.constructConstantExpression<T>(efq.RightHandSide, context);

            ExpressionType operation;
            if (!operationMap.TryGetValue(efq.EFQType, out operation))
                throw new ArgumentOutOfRangeException("EFQType", efq.EFQType, "Invalid filter operation");

            try
            {
                var converted = (value.Type != member.Type)
                    ? (Expression)Expression.Convert(value, member.Type)
                    : (Expression)value;

                Expression comparison = null;

                if (value.Type == typeof(string))
                {
                    if (operation == ExpressionType.GreaterThanOrEqual ||
                        operation == ExpressionType.GreaterThan ||
                        operation == ExpressionType.LessThanOrEqual ||
                        operation == ExpressionType.LessThan)
                    {
                        MethodInfo method = value.Type.GetMethod("CompareTo", new[] { typeof(string) });
                        var zero = Expression.Constant(0);

                        var result = Expression.Call(member, method, converted);

                        comparison = Expression.MakeBinary(operation, result, zero);
                    }
                }

                if (comparison == null)
                    comparison = Expression.MakeBinary(operation, member, converted);

                var lambda = Expression.Lambda<Func<T, bool>>(comparison, parameter);

                return lambda;
            }
            catch (Exception)
            {
                throw new InvalidOperationException(
                    String.Format("Cannot convert value \"{0}\" of type \"{1}\" to field \"{2}\" of type \"{3}\"",
                        efq.RightHandSide, value.Type, efq.FieldName, member.Type));
            }
        }

        private static ConstantExpression constructConstantExpression<T>(this EFQ efq, object value, object context)
        {
            var sc = value as EFQ;
            if (sc != null)
            {
                if (sc.IsAdd())
                    value = executeAddExpression<T>(sc, context);
                else if (sc.IsConstant())
                    value = sc.ConstantValue();
            }

            value = getConstantValue(value, context);

            if (value == null)
                return Expression.Constant(null);

            return Expression.Constant(value, value.GetType());
        }

        private static object ConstantValue(this EFQ efq)
        {
            if (efq.ConstantString != null)
                return efq.ConstantString;
            if (efq.ConstantInt != null)
                return efq.ConstantInt;
            if (efq.ConstantDouble != null)
                return efq.ConstantDouble;
            if (efq.ConstantDecimal != null)
                return efq.ConstantDecimal;
            if (efq.ConstantDateTime != null)
                return efq.ConstantDateTime;
            if (efq.ConstantDateTimeOffset != null)
                return efq.ConstantDateTimeOffset;
            // System.Text.Json doesn't support TimeSpans, yet
            // https://github.com/dotnet/runtime/issues/29932
            // if (efq.ConstantTimeSpan != null)
            //     return efq.ConstantTimeSpan;
            return null;
        }

        private static object executeAddExpression<T>(EFQ sc, object context)
        {
            object result = null;

            foreach (var arg in sc.AggregateList)
            {
                if (!arg.IsConstant())
                    throw new ArgumentException(String.Format("{0} must be constant", sc));

                if (result == null)
                {
                    result = getConstantValue(arg.ConstantValue(), context);
                    continue;
                }

                var value = getConstantValue(arg.ConstantValue(), context);

                // System.Text.Json doesn't support TimeSpans, yet
                // Until we figure out how to make Json.NET deserialize into TimeSpan objects ...
                var s = value as string;
                if (s != null)
                {
                    TimeSpan span;
                    if (TimeSpan.TryParse(s, out span))
                        value = span;
                }

                var leftType = result.GetType();
                var rightType = value.GetType();

                // #TODO: Ensure Add() works
                var methodInfo = leftType.GetMethod("Add", new[] { rightType });

                if (methodInfo == null)
                    throw new ArgumentException(
                        String.Format("Cannot find operation \"Add\" for type \"{0}\"", leftType));

                result = methodInfo.Invoke(result, new[] { value });
            }

            return result;
        }

        private static object getConstantValue(object value, object context)
        {
            // #TODO: Remove dtKludge
            string dtKludge = null;
            var s = value as String;
            if (s != null)
            {
                var re = new Regex("^{(.*)}(:.*)?$");
                var match = re.Match(s);
                if (match.Success)
                {
                    var matchString = match.Groups[1].Value;
                    dtKludge = match.Groups[2].Value;
                    if (!String.IsNullOrEmpty(matchString))
                    {
                        if (matchString == "NOW")
                        {
                            value = DateTime.Now;
                        }
                        else if (matchString == "NOW:DATE")
                        {
                            value = DateTime.Now.Date;
                        }
                        else if (matchString == "NOW:TIME")
                        {
                            value = DateTime.Now.TimeOfDay;
                        }
                        else
                        {
                            var parts = matchString.Split(new[] { '.' });
                            foreach (var part in parts)
                            {
                                var dict = context as Dictionary<string, object>;
                                if (dict != null)
                                {
                                    var val = dict[part];
                                    context = val;
                                    value = val;
                                }
                                else
                                {
                                    var type = context.GetType();
                                    var prop = type.GetProperty(part);
                                    if (prop != null)
                                    {
                                        var val = prop.GetValue(context, null);
                                        context = val;
                                        value = val;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (value is DateTime)
            {
                var dt = (DateTime)value;

                if (dtKludge == ":date")
                {
                    value = dt.Date;
                }
                else if (dtKludge == ":time")
                {
                    value = dt.ToString("HH:mm:ss.fff");
                }
                else if (dtKludge == ":null")
                {
                    var f = dt.ToString("HH:mm:ss.fff");
                    if (f == "00:00:00.000")
                        value = null;
                    else
                        value = f;
                }
            }

            return value;
        }

        private static MemberExpression getMember<T>(this EFQ efq, Type type, ParameterExpression parameter)
        {
            MemberExpression rVal = null;

            if (efq.FieldName.Contains("."))
            {
                var parts = efq.FieldName.Split(new[] { '.' });

                foreach (var part in parts)
                {
                    if (rVal == null)
                    {
                        rVal = Expression.PropertyOrField(parameter, part);
                    }
                    else
                    {
                        rVal = Expression.PropertyOrField(rVal, part);
                    }
                }
            }
            else
            {
                if (type.GetProperty(efq.FieldName) == null && type.GetField(efq.FieldName) == null)
                    throw new MissingMemberException(type.Name, efq.FieldName);
                rVal = Expression.PropertyOrField(parameter, efq.FieldName);
            }

            return rVal;
        }
        #endregion

        #region processing types

        private static bool IsAdd(this EFQ efq)
        {
            return efq.EFQType == EFQType.Add;
        }

        private static bool IsConstant(this EFQ efq)
        {
            return efq.EFQType == EFQType.Constant;
        }

        private static bool IsMethodCall(this EFQ efq)
        {
            switch (efq.EFQType)
            {
                case EFQType.Contains:
                case EFQType.StartsWith:
                case EFQType.EndsWith:
                    return true;
                default:
                    return false;
            }
        }

        private static bool IsStaticCall(this EFQ efq)
        {
            switch (efq.EFQType)
            {
                case EFQType.Like:
                    return true;
                default:
                    return false;
            }
        }

        private static bool IsAny(this EFQ efq)
        {
            switch (efq.EFQType)
            {
                case EFQType.Any:
                    return true;
                default:
                    return false;
            }
        }

        private static bool IsAggregate(this EFQ efq)
        {
            switch (efq.EFQType)
            {
                case EFQType.And:
                case EFQType.Or:
                case EFQType.Nand:
                case EFQType.Nor:
                    return true;
                default:
                    return false;
            }
        }

        private static bool IsNegate(this EFQ efq)
        {
            switch (efq.EFQType)
            {
                case EFQType.Nand:
                case EFQType.Nor:
                    return true;
                default:
                    return false;
            }
        }

        private static bool IsAnd(this EFQ efq)
        {
            switch (efq.EFQType)
            {
                case EFQType.And:
                case EFQType.Nand:
                    return true;
                default:
                    return false;
            }
        }

        private static bool IsUnary(this EFQ efq)
        {
            switch (efq.EFQType)
            {
                case EFQType.IsTrue:
                case EFQType.IsFalse:
                    return true;
                default:
                    return false;
            }
        }

        #endregion


        #region internal dictionaries

        private static readonly Dictionary<EFQType, ExpressionType> operationMap =
            new Dictionary<EFQType, ExpressionType>
            {
                { EFQType.Equal, ExpressionType.Equal },
                { EFQType.NotEqual, ExpressionType.NotEqual },
                { EFQType.LessThan, ExpressionType.LessThan },
                { EFQType.LessThanOrEqual, ExpressionType.LessThanOrEqual },
                { EFQType.GreaterThan, ExpressionType.GreaterThan },
                { EFQType.GreaterThanOrEqual, ExpressionType.GreaterThanOrEqual },
                { EFQType.IsTrue, ExpressionType.IsTrue },
                { EFQType.IsFalse, ExpressionType.IsFalse },
            };


        private static readonly Dictionary<EFQType, MethodInfo> methodMap =
            new Dictionary<EFQType, MethodInfo>
            {
                { EFQType.Contains, typeof(string).GetMethod("Contains", new[] { typeof(string) }) },
                { EFQType.StartsWith, typeof(string).GetMethod("StartsWith", new[] { typeof(string) }) },
                { EFQType.EndsWith, typeof(string).GetMethod("EndsWith", new[] { typeof(string) }) },
            };
        #endregion
    }

}

