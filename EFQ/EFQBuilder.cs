using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace JDege.EFQ
{
    public class EFQBuilder
    {
        #region static convenience functions

        public static EFQ Compare(EFQType comparison, string fieldName, object rightHandSide)
        {
            return new EFQ
            {
                EFQType = comparison,
                FieldName = fieldName,
                RightHandSide = rightHandSide as EFQ ?? EFQBuilder.Constant(rightHandSide)
            };
        }

        /// <summary>
        /// returns a EFQuery that is always true
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ IsTrue()
        {
            return new EFQ { EFQType = EFQType.IsTrue };
        }

        /// <summary>
        /// returns a EFQuery that is always false
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ IsFalse()
        {
            return new EFQ { EFQType = EFQType.IsFalse };
        }

        /// <summary>
        /// returns a EFQuery that is true if fieldName contains rightHandSide as a substring
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ Contains(string fieldName, object rightHandSide)
        {
            return Compare(EFQType.Contains, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQuery that is true if fieldName starts with rightHandSide as a substring
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ StartsWith(string fieldName, object rightHandSide)
        {
            return Compare(EFQType.StartsWith, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQuery that is true if fieldName ends with rightHandSide as a substring
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ EndsWith(string fieldName, object rightHandSide)
        {
            return Compare(EFQType.EndsWith, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQuery that is true if fieldName matches rightHandSide as a SQL LIKE pattern
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ Like(string fieldName, object rightHandSide)
        {
            return Compare(EFQType.Like, fieldName, rightHandSide);
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
                EFQType = EFQType.Any,
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
            return Compare(EFQType.Equal, fieldName, rightHandSide);
        }

        // #TODO: Fix the doc comments
        /// <summary>
        /// returns a EFQuery that is true if fieldName is not equal to rightHandSide
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ NotEqual(string fieldName, object rightHandSide)
        {
            return Compare(EFQType.NotEqual, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQuery that is true if fieldName is greater than rightHandSide
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ GreaterThan(string fieldName, object rightHandSide)
        {
            return Compare(EFQType.GreaterThan, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQuery that is true if fieldName is greater than or equal to rightHandSide
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ GreaterThanOrEqual(string fieldName, object rightHandSide)
        {
            return Compare(EFQType.GreaterThanOrEqual, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQuery that is true if fieldName is less than rightHandSide
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ LessThan(string fieldName, object rightHandSide)
        {
            return Compare(EFQType.LessThan, fieldName, rightHandSide);
        }

        /// <summary>
        /// returns a EFQuery that is true if fieldName is less than or equal to rightHandSide
        /// </summary>
        /// <returns>EFQuery</returns>
        public static EFQ LessThanOrEqual(string fieldName, object rightHandSide)
        {
            return Compare(EFQType.LessThanOrEqual, fieldName, rightHandSide);
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
                EFQType = EFQType.And,
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
                EFQType = EFQType.Or,
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
                EFQType = EFQType.Nand,
                AggregateList = efQueries
            };
        }

        // #TODO: Ensure that having separate methods for EFQ[] and IEnumerable<EFQ> are both necessary
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
                EFQType = EFQType.Nor,
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
                EFQType = EFQType.Constant,
                ConstantValue = value
            };
        }

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
        #endregion
    }
}
