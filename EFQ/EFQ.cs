using System.Collections.Generic;

using SJ = System.Text.Json.Serialization;
using NJ = Newtonsoft.Json;
using NJC = Newtonsoft.Json.Converters;

using JDege.EFQ.JsonConverters;

namespace JDege.EFQ
{
    [SJ.JsonConverter(typeof(EfqJsonConverter))]
    [NJ.JsonConverter(typeof(EfqNewtonsoftJsonConverter))]
    public class EFQ
    {
        #region Member variables

        public EFQType EFQType { get; set; }

        public string FieldName { get; set; }

        public EFQ RightHandSide { get; set; }

        public object ConstantValue { get; set; }

        public EFQ InnerCriteria { get; set; }

        private IEnumerable<EFQ> _aggregateList = new List<EFQ>();

        public IEnumerable<EFQ> AggregateList
        {
            get { return this._aggregateList; }
            set { this._aggregateList = value; }
        }

        [SJ.JsonConverter(typeof(EfqConstantJsonConverter))]
        [NJ.JsonConverter(typeof(EfqConstantNewtonsoftJsonConverter))]
        public class Constant
        {
            public Constant(object value)
            {
                Value = value;
            }

            public object Value { get; private set; }
        }

        #endregion
    }

    [SJ.JsonConverter(typeof(SJ.JsonStringEnumConverter))]
    [NJ.JsonConverter(typeof(NJC.StringEnumConverter))]
    public enum EFQType
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

