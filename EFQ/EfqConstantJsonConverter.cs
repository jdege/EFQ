using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace JDege.EFQ
{
    public class EfqConstantJsonConverter : JsonConverter<EFQ.Constant>
    {
        public override void Write(Utf8JsonWriter writer, EFQ.Constant efqConstant, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            string formattedConstant;
            switch (efqConstant.Value)
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
                    formattedConstant = $"STR:{efqConstant.Value}";
                    break;
            }
            writer.WriteString(nameof(EFQ.Constant), formattedConstant);

            writer.WriteEndObject();
        }

        public override EFQ.Constant Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException("Expected StartObject token");

            EFQ.Constant efqConstant = null;

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    return efqConstant;

                if (reader.TokenType != JsonTokenType.PropertyName)
                    throw new JsonException("Expected PropertyName token");

                var propName = reader.GetString();
                reader.Read();

                // Would use switch(), except it doesn't do case-invariant comparisons
                if (propName.Equals(nameof(EFQ.Constant), StringComparison.InvariantCultureIgnoreCase))
                {
                    var s = reader.GetString();

                    var convertConstantValueRE = new Regex("^(INT|DBL|DEC|DT|DTO|TSP|STR):(.*)");
                    var match = convertConstantValueRE.Match(s);
                    if (!match.Success)
                        throw new JsonException($"{s} is not a valid constant value expression");

                    var destType = match.Groups[1].Value;
                    var expr = match.Groups[2].Value;

                    switch (destType)
                    {
                        case "INT":
                            efqConstant = new EFQ.Constant(Int32.Parse(expr));
                            break;
                        case "DBL":
                            efqConstant = new EFQ.Constant(Double.Parse(expr));
                            break;
                        case "DEC":
                            efqConstant = new EFQ.Constant(Decimal.Parse(expr));
                            break;
                        case "DT":
                            efqConstant = new EFQ.Constant(DateTime.Parse(expr));
                            break;
                        case "DTO":
                            efqConstant = new EFQ.Constant(DateTimeOffset.Parse(expr));
                            break;
                        case "TSP":
                            efqConstant = new EFQ.Constant(TimeSpan.Parse(expr));
                            break;
                        case "STR":
                            efqConstant = new EFQ.Constant(expr);
                            break;
                        default:
                            throw new JsonException($"{destType} is not a valid constant value type");
                    }

                }
            }

            return null;
        }
    }
}

