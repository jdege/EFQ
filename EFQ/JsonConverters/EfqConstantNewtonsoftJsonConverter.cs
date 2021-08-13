using System;
using System.Text.RegularExpressions;

using NJ = Newtonsoft.Json;

namespace JDege.EFQ.JsonConverters
{
    public class EfqConstantNewtonsoftJsonConverter : NJ.JsonConverter<EFQ.Constant>
    {
        public override void WriteJson(NJ.JsonWriter writer, EFQ.Constant efqConstant, NJ.JsonSerializer serializer)
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

            writer.WritePropertyName(nameof(EFQ.Constant));
            writer.WriteValue(formattedConstant);

            writer.WriteEndObject();
        }

        public override EFQ.Constant ReadJson(NJ.JsonReader reader, Type objectType, EFQ.Constant existingValue,
            bool hasExistingValue, NJ.JsonSerializer serializer)
        {
            if (reader.TokenType != NJ.JsonToken.StartObject)
                throw new NJ.JsonException("Expected StartObject token");

            EFQ.Constant efqConstant = null;

            while (reader.Read())
            {
                if (reader.TokenType == NJ.JsonToken.EndObject)
                    return efqConstant;

                if (reader.TokenType != NJ.JsonToken.PropertyName)
                    throw new NJ.JsonException("Expected PropertyName token");

                var propName = reader.Value.ToString();
                reader.Read();

                // Would use switch(), except it doesn't do case-invariant comparisons
                if (propName.Equals(nameof(EFQ.Constant), StringComparison.InvariantCultureIgnoreCase))
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
                            throw new NJ.JsonException($"{destType} is not a valid constant value type");
                    }

                }
            }

            return null;
        }
    }
}