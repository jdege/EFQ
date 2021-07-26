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
        [NJ.JsonConverter(typeof(NJC.StringEnumConverter))]
        [SJS.JsonConverter(typeof(SJS.JsonStringEnumConverter))]
        public EFQType EFQType { get; set; }

        public string FieldName { get; set; }

        public EFQ RightHandSide { get; set; }

        public string ConstantString { get; set; }

        public int? ConstantInt { get; set; }

        public double? ConstantDouble { get; set; }

        public decimal? ConstantDecimal { get; set; }

        public DateTime? ConstantDateTime { get; set; }

        public DateTimeOffset? ConstantDateTimeOffset { get; set; }

        // System.Text.Json doesn't support TimeSpans, yet
        // https://github.com/dotnet/runtime/issues/29932
        // public TimeSpan? ConstantTimeSpan { get; set; }

        public EFQ InnerCriteria { get; set; }

        private IEnumerable<EFQ> _aggregateList = new List<EFQ>();

        public IEnumerable<EFQ> AggregateList
        {
            get { return this._aggregateList; }
            set { this._aggregateList = value; }
        }

        #endregion
    }

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

