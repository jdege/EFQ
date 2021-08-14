using System.Collections.Generic;

using SJ = System.Text.Json.Serialization;
using NJ = Newtonsoft.Json;
using NJC = Newtonsoft.Json.Converters;

using JDege.EFQ.JsonConverters;

namespace JDege.EFQ
{
    /// <summary>
    /// EFQ is an object that can contain a serialized expression tree that can be 
    /// serialized and deserialized, and which can be used to generate an 
    /// predicate that can be passed to an Entity Framework Where() function.
    /// 
    /// This should be generally considered as an opaque type. EFQs are constructed
    /// using the static methods in the EFQBuilder class, serialized and
    /// deserialized using the System.Text.Json or Newtonsoft.Json converters,
    /// and are converted into predicates using the extension methods in EFQExtensions.
    /// </summary>
    [SJ.JsonConverter(typeof(EfqJsonConverter))]
    [NJ.JsonConverter(typeof(EfqNewtonsoftJsonConverter))]
    public class EFQ
    {
#pragma warning disable 1591
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
#pragma warning restore 1591

        /// <summary>
        /// EFQ.Constant wraps constant values in a way that can be reliably serialized and deserialized.
        /// </summary>
        [SJ.JsonConverter(typeof(EfqConstantJsonConverter))]
        [NJ.JsonConverter(typeof(EfqConstantNewtonsoftJsonConverter))]
        public class Constant
        {
#pragma warning disable 1591
            public Constant(object value)
            {
                Value = value;
            }

            public object Value { get; private set; }
#pragma warning restore 1591
        }
    }

    /// <summary>
    /// The EFQType enum lists the various types of expressions that an EFQ might support.
    /// </summary>
    [SJ.JsonConverter(typeof(SJ.JsonStringEnumConverter))]
    [NJ.JsonConverter(typeof(NJC.StringEnumConverter))]
    public enum EFQType
    {
#pragma warning disable 1591
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
#pragma warning restore 1591
    };
}

