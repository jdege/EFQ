using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PeteMontgomery.PredicateBuilder;

namespace JDege.EFQ
{
    public class EFQ
    {
        #region static convenience functions

        public static EFQ Compare(SelectionComparison comparison, string fieldName, object rightHandSide)
        {
            return new EFQ
            {
                SelectionComparison = comparison,
                FieldName = fieldName,
                RightHandSide = rightHandSide as EFQ ?? EFQ.Constant(rightHandSide)
            };
        }

        /// <summary>
        /// returns a EFQuery that is always true
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ IsTrue()
        {
            return new EFQ { SelectionComparison = SelectionComparison.IsTrue };
        }

        /// <summary>
        /// returns a EFQuery that is always false
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ IsFalse()
        {
            return new EFQ { SelectionComparison = SelectionComparison.IsFalse };
        }

        /// <summary>
        /// returns a EFQuery that is true if fieldName contains rightHandSide as a substring
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ Contains(string fieldName, object rightHandSide)
        {
            return Compare(SelectionComparison.Contains, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQuery that is true if fieldName starts with rightHandSide as a substring
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ StartsWith(string fieldName, object rightHandSide)
        {
            return Compare(SelectionComparison.StartsWith, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQuery that is true if fieldName ends with rightHandSide as a substring
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ EndsWith(string fieldName, object rightHandSide)
        {
            return Compare(SelectionComparison.EndsWith, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQuery that is true if fieldName matches rightHandSide as a SQL LIKE pattern
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ Like(string fieldName, object rightHandSide)
        {
            return Compare(SelectionComparison.Like, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQuery that is true if the innerCriteria evaluates true
        /// on the fieldName. (Assumes fieldName is a one-to-many navigational property).
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ Any(string fieldName, EFQ innerCriteria)
        {
            return new EFQ
            {
                SelectionComparison = SelectionComparison.Any,
                FieldName = fieldName,
                InnerCriteria = innerCriteria
            };
        }

        /// <summary>
        /// returns a EFQuery that is true if fieldName is equal to rightHandSide
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ Equal(string fieldName, object rightHandSide)
        {
            return Compare(SelectionComparison.Equal, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQuery that is true if fieldName is not equal to rightHandSide
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ NotEqual(string fieldName, object rightHandSide)
        {
            return Compare(SelectionComparison.NotEqual, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQuery that is true if fieldName is greater than rightHandSide
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ GreaterThan(string fieldName, object rightHandSide)
        {
            return Compare(SelectionComparison.GreaterThan, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQuery that is true if fieldName is greater than or equal to rightHandSide
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ GreaterThanOrEqual(string fieldName, object rightHandSide)
        {
            return Compare(SelectionComparison.GreaterThanOrEqual, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQuery that is true if fieldName is less than rightHandSide
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ LessThan(string fieldName, object rightHandSide)
        {
            return Compare(SelectionComparison.LessThan, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQuery that is true if fieldName is less than or equal to rightHandSide
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ LessThanOrEqual(string fieldName, object rightHandSide)
        {
            return Compare(SelectionComparison.LessThanOrEqual, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQuery that is true if all of the efQueries evaluate true
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ And(params EFQ[] efQueries)
        {
            return And(efQueries as IEnumerable<EFQ>);
        }
        public static EFQ And(IEnumerable<EFQ> efQueries)
        {
            return new EFQ
            {
                SelectionComparison = SelectionComparison.And,
                AggregateList = efQueries
            };
        }

        /// <summary>
        /// returns a EFQuery that is true if at least one of the efQueries evaluates true
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ Or(params EFQ[] efQueries)
        {
            return Or(efQueries as IEnumerable<EFQ>);
        }
        public static EFQ Or(IEnumerable<EFQ> efQueries)
        {
            return new EFQ
            {
                SelectionComparison = SelectionComparison.Or,
                AggregateList = efQueries
            };
        }

        /// <summary>
        /// returns a EFQuery that is true if at least one the efQueries evaluates false
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ Nand(params EFQ[] efQueries)
        {
            return Nand(efQueries as IEnumerable<EFQ>);
        }
        public static EFQ Nand(IEnumerable<EFQ> efQueries)
        {
            return new EFQ
            {
                SelectionComparison = SelectionComparison.Nand,
                AggregateList = efQueries
            };
        }

        // todo: Ensure that having separate methods for EFQ[] and IEnumerable<EFQ> are both necessary
        /// <summary>
        /// returns a EFQuery that is true if all of the efQueries evaluate false
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ Nor(params EFQ[] efQueries)
        {
            return Nor(efQueries as IEnumerable<EFQ>);
        }
        public static EFQ Nor(IEnumerable<EFQ> efQueries)
        {
            return new EFQ
            {
                SelectionComparison = SelectionComparison.Nor,
                AggregateList = efQueries
            };
        }

        /// <summary>
        /// returns a EFQuery that is true if all of the EFQuery evaluates false
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ Not(EFQ efQuery)
        {
            return Nand(new[] { efQuery });
        }

        /// <summary>
        /// returns a EFQuery that is true if fieldName is equal to one of the objects
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ ContainedIn(string fieldName, IEnumerable<object> objects)
        {
            return Or(objects.Select(o => Equal(fieldName, o)));
        }

        /// <summary>
        /// returns a EFQuery that is true if fieldName is greatder than or equal to left
        /// and less than or equal to right
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ Between(string fieldName, object left, object right)
        {
            return And(new[]
                {
                    GreaterThanOrEqual(fieldName, left),
                    LessThanOrEqual(fieldName, right)
                });
        }

        public static EFQ Constant(object value)
        {
            return new EFQ
            {
                SelectionComparison = SelectionComparison.Constant,
                ConstantValue = value
            };
        }

        public static EFQ Add(object left, object right)
        {
            return new EFQ
            {
                SelectionComparison = SelectionComparison.Add,
                AggregateList = new[]
                {
                    EFQ.Constant(left),
                    EFQ.Constant(right)
                }
            };
        }
        #endregion

        #region Member variables

        // todo: better name for SelectionComparison?
        [JsonConverter(typeof(StringEnumConverter))]
        public SelectionComparison SelectionComparison { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string FieldName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public EFQ RightHandSide { get; set; }

        // This is here so we can deserialize old-style EFQuery strings
        public object FieldValue
        {
            set { this.RightHandSide = EFQ.Constant((value)); }
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object ConstantValue { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public EFQ InnerCriteria { get; set; }

        private IEnumerable<EFQ> _aggregateList = null;

        public IEnumerable<EFQ> AggregateList
        {
            get { return this._aggregateList ?? (this._aggregateList = new List<EFQ>()); }
            set { this._aggregateList = value; }
        }

        #endregion

        #region Constructors

        public EFQ()
        {
            this.SelectionComparison = SelectionComparison.Constant;
            this.ConstantValue = null;
        }

        #endregion

        // This just tells JSON.net whether to include aggregateList when serializing an object
        public bool ShouldSerializeaggregateList()
        {
            return this._aggregateList != null;
        }

        #region processing types

        [JsonIgnore]
        public bool IsAdd
        {
            get { return this.SelectionComparison == SelectionComparison.Add; }
        }

        [JsonIgnore]
        public bool IsConstant
        {
            get { return this.SelectionComparison == SelectionComparison.Constant; }
        }

        [JsonIgnore]
        public bool IsMethodCall
        {
            get
            {
                switch (this.SelectionComparison)
                {
                    case SelectionComparison.Contains:
                    case SelectionComparison.StartsWith:
                    case SelectionComparison.EndsWith:
                        return true;
                    default:
                        return false;
                }
            }
        }

        [JsonIgnore]
        public bool IsStaticCall
        {
            get
            {
                switch (this.SelectionComparison)
                {
                    case SelectionComparison.Like:
                        return true;
                    default:
                        return false;
                }
            }
        }

        [JsonIgnore]
        public bool IsAny
        {
            get
            {
                switch (this.SelectionComparison)
                {
                    case SelectionComparison.Any:
                        return true;
                    default:
                        return false;
                }
            }
        }

        [JsonIgnore]
        public bool IsAggregate
        {
            get
            {
                switch (this.SelectionComparison)
                {
                    case SelectionComparison.And:
                    case SelectionComparison.Or:
                    case SelectionComparison.Nand:
                    case SelectionComparison.Nor:
                        return true;
                    default:
                        return false;
                }
            }
        }

        [JsonIgnore]
        public bool IsNegate
        {
            get
            {
                switch (this.SelectionComparison)
                {
                    case SelectionComparison.Nand:
                    case SelectionComparison.Nor:
                        return true;
                    default:
                        return false;
                }
            }
        }

        [JsonIgnore]
        public bool IsAnd
        {
            get
            {
                switch (this.SelectionComparison)
                {
                    case SelectionComparison.And:
                    case SelectionComparison.Nand:
                        return true;
                    default:
                        return false;
                }
            }
        }

        [JsonIgnore]
        public bool IsUnary
        {
            get
            {
                switch (this.SelectionComparison)
                {
                    case SelectionComparison.IsTrue:
                    case SelectionComparison.IsFalse:
                        return true;
                    default:
                        return false;
                }
            }
        }
        #endregion

        #region predicate construction functions
        public Expression<Func<T, bool>> ConstructPredicate<T>(object context = null)
        {
            if (this.IsUnary)
                return this.SelectionComparison == SelectionComparison.IsTrue
                    ? PredicateBuilder.True<T>()
                    : PredicateBuilder.False<T>();

            if (this.IsAggregate)
                return this.constructAggregatePredicate<T>(context);

            if (this.IsMethodCall)
                return this.constructMethodCallPredicate<T>(context);

            if (this.IsStaticCall)
                return this.constructStaticCallPredicate<T>(context);

            if (this.IsAny)
                return this.ConstructAnyPredicate<T>(context);

            return this.ConstructSinglePredicate<T>(context);
        }

        private Expression<Func<T, bool>> constructAggregatePredicate<T>(object context)
        {
            var predicate = this.IsAnd ? PredicateBuilder.True<T>() : PredicateBuilder.False<T>();

            foreach (var item in this.AggregateList)
            {
                predicate = this.IsAnd
                    ? predicate.And(item.ConstructPredicate<T>(context))
                    : predicate.Or(item.ConstructPredicate<T>(context));
            }

            if (this.IsNegate)
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

        private Expression<Func<T, bool>> constructMethodCallPredicate<T>(object context)
        {
            var type = typeof(T);

            if (type.GetProperty(this.FieldName) == null && type.GetField(this.FieldName) == null)
                throw new MissingMemberException(type.Name, this.FieldName);

            MethodInfo method;
            if (!methodMap.TryGetValue(this.SelectionComparison, out method))
                throw new ArgumentOutOfRangeException("selectionComparison", this.SelectionComparison, "Invalid filter operation");

            var parameter = Expression.Parameter(type);
            var member = Expression.PropertyOrField(parameter, this.FieldName);
            var value = this.constructConstantExpression<T>(this.RightHandSide, context);

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
                    String.Format("Cannot convert value \"{0}\" of type \"{1}\" to field \"{2}\" of type \"{3}\"", this.RightHandSide,
                        value.Type, this.FieldName, member.Type));
            }
        }

        private Expression<Func<T, bool>> constructStaticCallPredicate<T>(object context)
        {
            var type = typeof(T);

            if (type.GetProperty(this.FieldName) == null && type.GetField(this.FieldName) == null)
                throw new MissingMemberException(type.Name, this.FieldName);

            var parameter = Expression.Parameter(type);
            var member = Expression.PropertyOrField(parameter, this.FieldName);
            var value = this.constructConstantExpression<T>(this.RightHandSide, context);

            try
            {
                var converted = (value.Type != member.Type)
                    ? (Expression)Expression.Convert(value, member.Type)
                    : (Expression)value;

                var methodExpression = this.getStaticCallMethod(this.SelectionComparison, member, converted);

                var lambda = Expression.Lambda<Func<T, bool>>(methodExpression, parameter);

                return lambda;
            }
            catch (Exception)
            {
                throw new InvalidOperationException(
                    String.Format("Cannot convert value \"{0}\" of type \"{1}\" to field \"{2}\" of type \"{3}\"", this.RightHandSide,
                        value.Type, this.FieldName, member.Type));
            }
        }

        private Expression getStaticCallMethod(
            SelectionComparison selectionComparison,
            MemberExpression member,
            Expression converted)
        {
            if (selectionComparison == SelectionComparison.Like)
            {
                var methodExpression = Expression.Call(
                    typeof(DbFunctionsExtensions), "Like", Type.EmptyTypes,
                    Expression.Constant(EF.Functions), member, converted);

                return methodExpression;
            }

            throw new InvalidExpressionException(String.Format("Invalid SelectionComparison {0}", selectionComparison));
        }

        public Expression<Func<T, bool>> ConstructAnyPredicate<T>(object context)
        {
            var type = typeof(T);

            var parameter = Expression.Parameter(type);

            if (this.InnerCriteria == null)
                throw new MissingMemberException("\"Any\" criteria must have an innerCriteria");

            var member = this.getMember<T>(type, parameter);

            var collectionType = member.Type;
            var memberType = collectionType.GenericTypeArguments[0];

            var constructPredicateMethod = typeof(EFQ).GetMethod("ConstructPredicate");
            var constructPredicateMethodGeneric = constructPredicateMethod.MakeGenericMethod(memberType);
            var innerPredicate = (Expression)constructPredicateMethodGeneric.Invoke(this.InnerCriteria, new object[] { context });

            var call = Expression.Call(typeof(Enumerable), "Any",
                new Type[] { memberType }, new[] { member, innerPredicate });

            var lambda = Expression.Lambda<Func<T, bool>>(call, parameter);

            return lambda;
        }

        public Expression<Func<T, bool>> ConstructSinglePredicate<T>(object context)
        {
            var type = typeof(T);

            var parameter = Expression.Parameter(type);

            var member = this.getMember<T>(type, parameter);

            var value = this.constructConstantExpression<T>(this.RightHandSide, context);

            ExpressionType operation;
            if (!operationMap.TryGetValue(this.SelectionComparison, out operation))
                throw new ArgumentOutOfRangeException("selectionComparison", this.SelectionComparison, "Invalid filter operation");

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
                    String.Format("Cannot convert value \"{0}\" of type \"{1}\" to field \"{2}\" of type \"{3}\"", this.RightHandSide,
                        value.Type, this.FieldName, member.Type));
            }
        }

        private ConstantExpression constructConstantExpression<T>(object value, object context)
        {
            var sc = value as EFQ;
            if (sc != null)
            {
                if (sc.IsAdd)
                    value = this.executeAddExpression<T>(sc, context);
                else if (sc.IsConstant)
                    value = sc.ConstantValue;
            }

            value = getConstantValue(value, context);

            if (value == null)
                return Expression.Constant(null);

            return Expression.Constant(value, value.GetType());
        }

        private object executeAddExpression<T>(EFQ sc, object context)
        {
            object result = null;

            foreach (var arg in sc.AggregateList)
            {
                if (!arg.IsConstant)
                    throw new ArgumentException(String.Format("{0} must be constant", sc));

                if (result == null)
                {
                    result = getConstantValue(arg.ConstantValue, context);
                    continue;
                }

                var value = getConstantValue(arg.ConstantValue, context);

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

        private MemberExpression getMember<T>(Type type, ParameterExpression parameter)
        {
            MemberExpression rVal = null;

            if (this.FieldName.Contains("."))
            {
                var parts = this.FieldName.Split(new[] { '.' });

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
                if (type.GetProperty(this.FieldName) == null && type.GetField(this.FieldName) == null)
                    throw new MissingMemberException(type.Name, this.FieldName);
                rVal = Expression.PropertyOrField(parameter, this.FieldName);
            }

            return rVal;
        }
        #endregion


        #region internal dictionaries

        private static readonly Dictionary<SelectionComparison, ExpressionType> operationMap =
            new Dictionary<SelectionComparison, ExpressionType>
            {
                { SelectionComparison.Equal, ExpressionType.Equal },
                { SelectionComparison.NotEqual, ExpressionType.NotEqual },
                { SelectionComparison.LessThan, ExpressionType.LessThan },
                { SelectionComparison.LessThanOrEqual, ExpressionType.LessThanOrEqual },
                { SelectionComparison.GreaterThan, ExpressionType.GreaterThan },
                { SelectionComparison.GreaterThanOrEqual, ExpressionType.GreaterThanOrEqual },
                { SelectionComparison.IsTrue, ExpressionType.IsTrue },
                { SelectionComparison.IsFalse, ExpressionType.IsFalse },
            };


        private static readonly Dictionary<SelectionComparison, MethodInfo> methodMap =
            new Dictionary<SelectionComparison, MethodInfo>
            {
                { SelectionComparison.Contains, typeof(string).GetMethod("Contains", new[] { typeof(string) }) },
                { SelectionComparison.StartsWith, typeof(string).GetMethod("StartsWith", new[] { typeof(string) }) },
                { SelectionComparison.EndsWith, typeof(string).GetMethod("EndsWith", new[] { typeof(string) }) },
            };
        #endregion

    }

    public enum SelectionComparison
    {
        Equal,
        NotEqual,
        LessThan,
        LessThanOrEqual,
        GreaterThan,
        GreaterThanOrEqual,
        And,
        Or,
        Nand,
        Nor,
        IsTrue,
        IsFalse,
        Contains,
        StartsWith,
        EndsWith,
        Like,
        Any,
        Constant,
        Add
    };

}

