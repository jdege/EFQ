using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace JDege.EFQ
{
    /// <summary>
    /// EFQBuilder provides a set of static methods that construct EFQ objects with
    /// various types of expressions.
    /// </summary>
    public class EFQBuilder
    {
        private static EFQ Compare(EFQType comparison, string fieldName, object rightHandSide)
        {
            return new EFQ
            {
                EFQType = comparison,
                FieldName = fieldName,
                RightHandSide = rightHandSide as EFQ ?? EFQBuilder.Constant(rightHandSide)
            };
        }

        /// <summary>
        /// returns a EFQ that is always true
        /// </summary>
        /// <returns>EFQ</returns>
        public static EFQ IsTrue()
        {
            return new EFQ { EFQType = EFQType.IsTrue };
        }

        /// <summary>
        /// returns a EFQ that is always false
        /// </summary>
        /// <returns>EFQ</returns>
        public static EFQ IsFalse()
        {
            return new EFQ { EFQType = EFQType.IsFalse };
        }

        /// <summary>
        /// returns a EFQ that is true if fieldName contains rightHandSide as a substring
        /// </summary>
        /// <param name="fieldName">The name of the field to compare against</param>
        /// <param name="rightHandSide">A constant value or an EFQ that is used to compare</param>
        /// <returns>EFQ</returns>
        public static EFQ Contains(string fieldName, object rightHandSide)
        {
            return Compare(EFQType.Contains, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQ that is true if fieldName starts with rightHandSide as a substring
        /// </summary>
        /// <param name="fieldName">The name of the field to compare against</param>
        /// <param name="rightHandSide">A constant value or an EFQ that is used to compare</param>
        /// <returns>EFQ</returns>
        public static EFQ StartsWith(string fieldName, object rightHandSide)
        {
            return Compare(EFQType.StartsWith, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQ that is true if fieldName ends with rightHandSide as a substring
        /// </summary>
        /// <param name="fieldName">The name of the field to compare against</param>
        /// <param name="rightHandSide">A constant value or an EFQ that is used to compare</param>
        /// <returns>EFQ</returns>
        public static EFQ EndsWith(string fieldName, object rightHandSide)
        {
            return Compare(EFQType.EndsWith, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQ that is true if fieldName matches rightHandSide as a SQL LIKE pattern
        /// </summary>
        /// <param name="fieldName">The name of the field to compare against</param>
        /// <param name="rightHandSide">A constant value or an EFQ that is used to compare</param>
        /// <returns>EFQ</returns>
        public static EFQ Like(string fieldName, object rightHandSide)
        {
            return Compare(EFQType.Like, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQ that is true if the innerCriteria evaluates true
        /// on the fieldName. (Assumes fieldName is a one-to-many navigational property).
        /// </summary>
        /// <param name="fieldName">The name of a navigation property</param>
        /// <param name="innerCriteria">An EFQ that is applied to the navigation property</param>
        /// <returns>EFQ</returns>
        public static EFQ Any(string fieldName, EFQ innerCriteria)
        {
            return new EFQ
            {
                EFQType = EFQType.Any,
                FieldName = fieldName,
                InnerCriteria = innerCriteria
            };
        }

        /// <summary>
        /// returns a EFQ that is true if fieldName is equal to rightHandSide
        /// </summary>
        /// <param name="fieldName">The name of the field to compare against</param>
        /// <param name="rightHandSide">A constant value or an EFQ that is used to compare</param>
        /// <returns>EFQ</returns>
        public static EFQ Equal(string fieldName, object rightHandSide)
        {
            return Compare(EFQType.Equal, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQ that is true if fieldName is not equal to rightHandSide
        /// </summary>
        /// <param name="fieldName">The name of the field to compare against</param>
        /// <param name="rightHandSide">A constant value or an EFQ that is used to compare</param>
        /// <returns>EFQ</returns>
        public static EFQ NotEqual(string fieldName, object rightHandSide)
        {
            return Compare(EFQType.NotEqual, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQ that is true if fieldName is greater than rightHandSide
        /// </summary>
        /// <param name="fieldName">The name of the field to compare against</param>
        /// <param name="rightHandSide">A constant value or an EFQ that is used to compare</param>
        /// <returns>EFQ</returns>
        public static EFQ GreaterThan(string fieldName, object rightHandSide)
        {
            return Compare(EFQType.GreaterThan, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQ that is true if fieldName is greater than or equal to rightHandSide
        /// </summary>
        /// <param name="fieldName">The name of the field to compare against</param>
        /// <param name="rightHandSide">A constant value or an EFQ that is used to compare</param>
        /// <returns>EFQ</returns>
        public static EFQ GreaterThanOrEqual(string fieldName, object rightHandSide)
        {
            return Compare(EFQType.GreaterThanOrEqual, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQ that is true if fieldName is less than rightHandSide
        /// </summary>
        /// <param name="fieldName">The name of the field to compare against</param>
        /// <param name="rightHandSide">A constant value or an EFQ that is used to compare</param>
        /// <returns>EFQ</returns>
        public static EFQ LessThan(string fieldName, object rightHandSide)
        {
            return Compare(EFQType.LessThan, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQ that is true if fieldName is less than or equal to rightHandSide
        /// </summary>
        /// <param name="fieldName">The name of the field to compare against</param>
        /// <param name="rightHandSide">A constant value or an EFQ that is used to compare</param>
        /// <returns>EFQ</returns>
        public static EFQ LessThanOrEqual(string fieldName, object rightHandSide)
        {
            return Compare(EFQType.LessThanOrEqual, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQ that is true if all of the efqs evaluate true
        /// </summary>
        /// <param name="efqs">A collection of EFQs to evaluate</param>
        /// <returns>EFQ</returns>
        public static EFQ And(params EFQ[] efqs)
        {
            return And(efqs as IEnumerable<EFQ>);
        }
        /// <summary>
        /// returns a EFQ that is true if all of the efqs evaluate true
        /// </summary>
        /// <param name="efqs">A collection of EFQs to evaluate</param>
        /// <returns>EFQ</returns>
        public static EFQ And(IEnumerable<EFQ> efqs)
        {
            return new EFQ
            {
                EFQType = EFQType.And,
                AggregateList = efqs
            };
        }

        /// <summary>
        /// returns a EFQ that is true if at least one of the efqs evaluates true
        /// </summary>
        /// <param name="efqs">A collection of EFQs to evaluate</param>
        /// <returns>EFQ</returns>
        public static EFQ Or(params EFQ[] efqs)
        {
            return Or(efqs as IEnumerable<EFQ>);
        }
        /// <summary>
        /// returns a EFQ that is true if at least one of the efqs evaluates true
        /// </summary>
        /// <param name="efqs">A collection of EFQs to evaluate</param>
        /// <returns>EFQ</returns>
        public static EFQ Or(IEnumerable<EFQ> efqs)
        {
            return new EFQ
            {
                EFQType = EFQType.Or,
                AggregateList = efqs
            };
        }

        /// <summary>
        /// returns a EFQ that is true if at least one of the efqs evaluates false
        /// </summary>
        /// <param name="efqs">A collection of EFQs to evaluate</param>
        /// <returns>EFQ</returns>
        public static EFQ Nand(params EFQ[] efqs)
        {
            return Nand(efqs as IEnumerable<EFQ>);
        }
        /// <summary>
        /// returns a EFQ that is true if at least one of the efqs evaluates false
        /// </summary>
        /// <param name="efqs">A collection of EFQs to evaluate</param>
        /// <returns>EFQ</returns>
        public static EFQ Nand(IEnumerable<EFQ> efqs)
        {
            return new EFQ
            {
                EFQType = EFQType.Nand,
                AggregateList = efqs
            };
        }

        /// <summary>
        /// returns a EFQ that is true if all of the efqs evaluate false
        /// </summary>
        /// <param name="efqs">A collection of EFQs to evaluate</param>
        /// <returns>EFQ</returns>
        public static EFQ Nor(params EFQ[] efqs)
        {
            return Nor(efqs as IEnumerable<EFQ>);
        }
        /// <summary>
        /// returns a EFQ that is true if all of the efqs evaluate false
        /// </summary>
        /// <param name="efqs">A collection of EFQs to evaluate</param>
        /// <returns>EFQ</returns>
        public static EFQ Nor(IEnumerable<EFQ> efqs)
        {
            return new EFQ
            {
                EFQType = EFQType.Nor,
                AggregateList = efqs
            };
        }

        /// <summary>
        /// returns a EFQ that is true if efq evaluates false
        /// </summary>
        /// <param name="efq">The EFQ to evaluate</param>
        /// <returns>EFQ</returns>
        public static EFQ Not(EFQ efq)
        {
            return Nand(new[] { efq });
        }

        /// <summary>
        /// returns a EFQ that is true if fieldName is equal to one of the objects
        /// </summary>
        /// <param name="fieldName">The name of the field to compare against</param>
        /// <param name="objects">The collection of objects that fieldName is compared to</param>
        /// <returns>EFQ</returns>
        public static EFQ ContainedIn(string fieldName, IEnumerable<object> objects)
        {
            return Or(objects.Select(o => Equal(fieldName, o)));
        }

        /// <summary>
        /// returns a EFQ that is true if fieldName is greater than or equal to left
        /// and less than or equal to right
        /// </summary>
        /// <param name="fieldName">The name of the field to compare against</param>
        /// <param name="left">the lower bound of the comparison</param>
        /// <param name="right">the upper bound of the comparison</param>
        /// <returns>EFQ</returns>
        public static EFQ Between(string fieldName, object left, object right)
        {
            return And(new[]
                {
                    GreaterThanOrEqual(fieldName, left),
                    LessThanOrEqual(fieldName, right)
                });
        }

        /// <summary>
        /// Wraps a constant value in an EFQ
        /// </summary>
        /// <param name="value">The value to be wrapped</param>
        /// <returns>EFQ</returns>
        public static EFQ Constant(object value)
        {
            var efq = new EFQ
            {
                EFQType = EFQType.Constant,
                ConstantValue = value
            };

            return efq;
        }

        /// <summary>
        /// Returns an EFQ that adds two constant values.
        /// 
        /// This was developed to support adding TimeSpans to DateTime.Now values.
        /// It allows the construction of queries that, for example, return all records
        /// where a date is greater than now-minus-30-days.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>EFQ</returns>
        public static EFQ Add(object left, object right)
        {
            return new EFQ
            {
                EFQType = EFQType.Add,
                AggregateList = new[]
                {
                    EFQBuilder.Constant(left),
                    EFQBuilder.Constant(right)
                }
            };
        }
    }
}