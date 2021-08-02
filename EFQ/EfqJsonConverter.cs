using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace JDege.EFQ
{
    public class EfqJsonConverter : JsonConverter<EFQ>
    {
        public override void Write(Utf8JsonWriter writer, EFQ efq, JsonSerializerOptions options)
        {
            WriteEfq(writer, efq, options);
        }

        private void WriteEfq(Utf8JsonWriter writer, EFQ efq, JsonSerializerOptions options, string name = null)
        {
            if (name == null)
                writer.WriteStartObject();
            else
                writer.WriteStartObject(name);

            writer.WriteString(nameof(efq.EFQType), efq.EFQType.ToString());
            if (efq.FieldName != null)
                writer.WriteString(nameof(efq.FieldName), efq.FieldName);
            if (efq.ConstantValue != null)
            {
                WriteConstantValue(writer, efq.ConstantValue, options, nameof(efq.ConstantValue));
            }
            if (efq.RightHandSide != null)
                WriteEfq(writer, efq.RightHandSide, options, nameof(efq.RightHandSide));
            if (efq.InnerCriteria != null)
                WriteEfq(writer, efq.InnerCriteria, options, nameof(efq.InnerCriteria));
            if (efq.AggregateList != null && efq.AggregateList.Any())
            {
                writer.WriteStartArray(nameof(efq.AggregateList));

                foreach (var item in efq.AggregateList)
                {
                    WriteEfq(writer, item, options);
                }

                writer.WriteEndArray();
            }

            writer.WriteEndObject();
        }

        private void WriteConstantValue(Utf8JsonWriter writer, object constantValue, JsonSerializerOptions options, string name)
        {
            string formattedConstant;
            // TOD: handle date/time types
            switch (constantValue)
            {
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
            writer.WriteString(name, formattedConstant);
        }
        public override EFQ Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException("Expected StartObject token");

            var efq = ReadEfq(ref reader, typeToConvert, options);

            if (efq == null)
                throw new JsonException("Expected EndObject token");

            return efq;
        }

        private EFQ ReadEfq(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var efq = new EFQ();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    return efq;

                if (reader.TokenType != JsonTokenType.PropertyName)
                    throw new JsonException("Expected PropertyName token");

                var propName = reader.GetString();
                reader.Read();

                // Would use switch(), except it doesn't do case-invariant comparisons
                if (propName.Equals(nameof(efq.EFQType), StringComparison.InvariantCultureIgnoreCase))
                {
                    efq.EFQType = Enum.Parse<EFQType>(reader.GetString());
                }
                else if (propName.Equals(nameof(efq.FieldName), StringComparison.InvariantCultureIgnoreCase))
                {
                    efq.FieldName = reader.GetString();
                }
                else if (propName.Equals(nameof(efq.RightHandSide), StringComparison.InvariantCultureIgnoreCase))
                {
                    efq.RightHandSide = ReadEfq(ref reader, typeToConvert, options);
                }
                else if (propName.Equals(nameof(efq.ConstantValue), StringComparison.InvariantCultureIgnoreCase))
                {
                    efq.ConstantValue = ConvertConstantValue(ref reader, typeToConvert, options);
                }
                else if (propName.Equals(nameof(efq.InnerCriteria), StringComparison.InvariantCultureIgnoreCase))
                {
                    efq.InnerCriteria = ReadEfq(ref reader, typeToConvert, options);
                }
                else if (propName.Equals(nameof(efq.AggregateList), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (reader.TokenType != JsonTokenType.StartArray)
                        throw new JsonException("Expected StartArray token");
                    reader.Read();

                    var aggregateList = new List<EFQ>();
                    while (reader.TokenType != JsonTokenType.EndArray)
                    {
                        aggregateList.Add(ReadEfq(ref reader, typeToConvert, options));
                        reader.Read();
                    }
                    efq.AggregateList = aggregateList.ToArray();
                }
            }

            return null;
        }

        private readonly Regex convertConstantValueRE = new Regex("^(INT|DBL|DEC|DT|DTO|TSP|STR):(.*)");

        private object ConvertConstantValue(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var s = reader.GetString();

            var match = convertConstantValueRE.Match(s);
            if (!match.Success)
                throw new JsonException($"{s} is not a valid constant value expression");

            var destType = match.Groups[1].Value;
            var expr = match.Groups[2].Value;

            switch (destType)
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
                    throw new JsonException($"{destType} is not a valid constant value type");
            }
        }
    }
}

