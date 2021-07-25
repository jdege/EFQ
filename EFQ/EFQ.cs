using System.Collections.Generic;

using SJ = System.Text.Json;
using SJS = System.Text.Json.Serialization;
using NJ = Newtonsoft.Json;
using NJC = Newtonsoft.Json.Converters;
using System;

namespace JDege.EFQ
{
    public class EFQ
    {
        #region Member variables

        // #TODO: Work with both json serializers!
        // #TODO: better name for SelectionComparison?
        [NJ.JsonConverter(typeof(NJC.StringEnumConverter))]
        [SJS.JsonConverter(typeof(SJS.JsonStringEnumConverter))]
        public EFQType EFQType { get; set; }

        // [NJ.JsonProperty(NullValueHandling = NJ.NullValueHandling.Ignore)]
        public string FieldName { get; set; }

        // [NJ.JsonProperty(NullValueHandling = NJ.NullValueHandling.Ignore)]
        public EFQ RightHandSide { get; set; }

        // [NJ.JsonProperty(NullValueHandling = NJ.NullValueHandling.Ignore)]
        public string ConstantString { get; set; }

        // [NJ.JsonProperty(NullValueHandling = NJ.NullValueHandling.Ignore)]
        public int? ConstantInt { get; set; }

        // [NJ.JsonProperty(NullValueHandling = NJ.NullValueHandling.Ignore)]
        public double? ConstantDouble { get; set; }

        // [NJ.JsonProperty(NullValueHandling = NJ.NullValueHandling.Ignore)]
        public decimal? ConstantDecimal { get; set; }

        // [NJ.JsonProperty(NullValueHandling = NJ.NullValueHandling.Ignore)]
        public DateTime? ConstantDateTime { get; set; }

        // [NJ.JsonProperty(NullValueHandling = NJ.NullValueHandling.Ignore)]
        public DateTimeOffset? ConstantDateTimeOffset { get; set; }

        // [NJ.JsonProperty(NullValueHandling = NJ.NullValueHandling.Ignore)]
        public TimeSpan? ConstantTimeSpan { get; set; }

        // [NJ.JsonProperty(NullValueHandling = NJ.NullValueHandling.Ignore)]
        public EFQ InnerCriteria { get; set; }

        private IEnumerable<EFQ> _aggregateList = null;

        public IEnumerable<EFQ> AggregateList
        {
            get { return this._aggregateList ?? (this._aggregateList = new List<EFQ>()); }
            set { this._aggregateList = value; }
        }

        #endregion

        // // This just tells JSON.net whether to include aggregateList when serializing an object
        // public bool ShouldSerializeaggregateList()
        // {
        //     return this._aggregateList != null;
        // }
    }

    // #TODO: Rename SelectionComparison enum
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

