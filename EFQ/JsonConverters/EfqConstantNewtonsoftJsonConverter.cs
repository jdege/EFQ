using System;
using NJ = Newtonsoft.Json;

namespace JDege.EFQ.JsonConverters
{
    public class EfqConstantNewtonsoftJsonConverter : NJ.JsonConverter<EFQ>
    {
        public override EFQ ReadJson(NJ.JsonReader reader, Type objectType, EFQ existingValue,
            bool hasExistingValue, NJ.JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(NJ.JsonWriter writer, EFQ value, NJ.JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}