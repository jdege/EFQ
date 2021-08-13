using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

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
            if (reader.TokenType != NJ.JsonToken.StartObject)
                throw new NJ.JsonException("Expected StartObject token");

            var efq = ReadEfq(ref reader, objectType);

            if (efq == null)
                throw new NJ.JsonException("Expected EndObject token");

            return efq;
        }

        private EFQ ReadEfq(ref JsonReader reader, Type objectType)
        {
            var efq = new EFQ();

            while (reader.Read())
            {
                if (reader.TokenType == NJ.JsonToken.EndObject)
                    return efq;

                if (reader.TokenType != NJ.JsonToken.PropertyName)
                    throw new NJ.JsonException("Expected PropertyName token");

                var propName = reader.Value.ToString();
                reader.Read();

                // Would use switch(), except it doesn't do case-invariant comparisons
                if (propName.Equals(nameof(efq.EFQType), StringComparison.InvariantCultureIgnoreCase))
                {
                    efq.EFQType = Enum.Parse<EFQType>(reader.Value.ToString());
                }
                else if (propName.Equals(nameof(efq.FieldName), StringComparison.InvariantCultureIgnoreCase))
                {
                    efq.FieldName = reader.Value.ToString();
                }
                else if (propName.Equals(nameof(efq.RightHandSide), StringComparison.InvariantCultureIgnoreCase))
                {
                    efq.RightHandSide = ReadEfq(ref reader, objectType);
                }
                else if (propName.Equals(nameof(efq.ConstantValue), StringComparison.InvariantCultureIgnoreCase))
                {
                    efq.ConstantValue = ConvertConstantValue(ref reader, objectType);
                }
                else if (propName.Equals(nameof(efq.InnerCriteria), StringComparison.InvariantCultureIgnoreCase))
                {
                    efq.InnerCriteria = ReadEfq(ref reader, objectType);
                }
                else if (propName.Equals(nameof(efq.AggregateList), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (reader.TokenType != NJ.JsonToken.StartArray)
                        throw new NJ.JsonException("Expected StartArray token");
                    reader.Read();

                    var aggregateList = new List<EFQ>();
                    while (reader.TokenType != NJ.JsonToken.EndArray)
                    {
                        aggregateList.Add(ReadEfq(ref reader, objectType));
                        reader.Read();
                    }
                    efq.AggregateList = aggregateList.ToArray();
                }
            }

            return null;
        }

        private object ConvertConstantValue(ref NJ.JsonReader reader, Type objectType)
        {
            var s = reader.Value.ToString();

            var convertConstantValueRE = new Regex("^(INT|DBL|DEC|DT|DTO|TSP|STR):(.*)", RegexOptions.IgnoreCase);
            var match = convertConstantValueRE.Match(s);
            if (!match.Success)
                throw new NJ.JsonException($"{s} is not a valid constant value expression");

            var destType = match.Groups[1].Value;
            var expr = match.Groups[2].Value;

            switch (destType.ToUpperInvariant())
            {
                case "INT":
                    return Int32.Parse(expr);
                case "DBL":
                    return Double.Parse(expr);
                case "DEC":
                    return Decimal.Parse(expr);
                case "DT":
                    return DateTime.Parse(expr);
                case "DTO":
                    return DateTimeOffset.Parse(expr);
                case "TSP":
                    return TimeSpan.Parse(expr);
                case "STR":
                    return expr;
                default:
                    throw new NJ.JsonException($"{destType} is not a valid constant value type");
            }
        }
    }
}