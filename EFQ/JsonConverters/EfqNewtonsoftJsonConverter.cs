using System;
using System.Linq;

using NJ = Newtonsoft.Json;

namespace JDege.EFQ.JsonConverters
{
    public class EfqNewtonsoftJsonConverter : NJ.JsonConverter<EFQ>
    {
        public override void WriteJson(NJ.JsonWriter writer, EFQ efq, NJ.JsonSerializer serializer)
        {
            WriteEfq(writer, efq, serializer);
        }

        private void WriteEfq(NJ.JsonWriter writer, EFQ efq, NJ.JsonSerializer serializer, string name = null)
        {
            if (name != null)
            {
                writer.WritePropertyName(name);
            }
            writer.WriteStartObject();

            writer.WritePropertyName(nameof(efq.EFQType));
            writer.WriteValue(efq.EFQType.ToString());
            if (efq.FieldName != null)
            {
                writer.WritePropertyName(nameof(efq.FieldName));
                writer.WriteValue(efq.FieldName);
            }
            if (efq.ConstantValue != null)
            {
                WriteConstantValue(writer, efq.ConstantValue, nameof(efq.ConstantValue));
            }
            if (efq.RightHandSide != null)
                WriteEfq(writer, efq.RightHandSide, serializer, nameof(efq.RightHandSide));
            if (efq.InnerCriteria != null)
                WriteEfq(writer, efq.InnerCriteria, serializer, nameof(efq.InnerCriteria));
            if (efq.AggregateList != null && efq.AggregateList.Any())
            {
                writer.WritePropertyName(nameof(efq.AggregateList));
                writer.WriteStartArray();

                foreach (var item in efq.AggregateList)
                {
                    WriteEfq(writer, item, serializer);
                }

                writer.WriteEndArray();
            }

            writer.WriteEndObject();
        }

        private void WriteConstantValue(NJ.JsonWriter writer, object constantValue, string name)
        {
            string formattedConstant;
            // TOD: handle date/time types
            switch (constantValue)
            {
                case EFQ.Constant cv:
                    WriteConstantValue(writer, cv.Value, name);
                    return;
                case int cv:
                    formattedConstant = $"INT:{cv}";
                    break;
                case double cv:
                    formattedConstant = $"DBL:{cv}";
                    break;
                case decimal cv:
                    formattedConstant = $"DEC:{cv}";
                    break;
                case DateTime cv:
                    formattedConstant = $"DT:{cv:o}";
                    break;
                case DateTimeOffset cv:
                    formattedConstant = $"DTO:{cv:o}";
                    break;
                case TimeSpan cv:
                    formattedConstant = $"TSP:{cv:c}";
                    break;
                default:
                    formattedConstant = $"STR:{constantValue}";
                    break;
            }

            writer.WritePropertyName(name);
            writer.WriteValue(formattedConstant);
        }

        public override EFQ ReadJson(NJ.JsonReader reader, Type objectType, EFQ existingValue,
           bool hasExistingValue, NJ.JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}