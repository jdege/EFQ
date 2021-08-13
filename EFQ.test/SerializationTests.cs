using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

using SJ = System.Text.Json;
using NJ = Newtonsoft.Json;

namespace JDege.EFQ.test
{
    public class SerializationTests
    {
        // InlineData only works with static initializers
        private IEnumerable<EFQ> _testEfqs = new[] {
                EFQBuilder.IsTrue(),
                EFQBuilder.IsFalse(),
                EFQBuilder.Equal("aFieldName", "astring"),
                EFQBuilder.Equal("aFieldName", 1),
                EFQBuilder.Equal("aFieldName", 1.1),
                EFQBuilder.Equal("aFieldName", 1D),
                EFQBuilder.Equal("aFieldName", DateTime.Now),
                EFQBuilder.Equal("aFieldName", DateTimeOffset.Now),
                EFQBuilder.Not(EFQBuilder.Equal("aFieldName", "astring")),
                EFQBuilder.Any("aFieldName", EFQBuilder.Equal("child.aChildFieldName", "astring")),
                EFQBuilder.Contains("aFieldName", "123"),
                EFQBuilder.Equal("ArtistId", 90),
                EFQBuilder.Equal("aFieldName", DateTime.Parse("2021-01-21T13:14:15.678")),
                EFQBuilder.Equal("aFieldName", DateTimeOffset.Parse("2021-01-21T13:14:15.678")),
                EFQBuilder.Equal("aFieldName", new TimeSpan(days: 0, hours: 13, minutes: 14, seconds: 15, milliseconds: 678)),
                EFQBuilder.And(EFQBuilder.Equal("aFieldName", 1), EFQBuilder.Equal("anotherFieldName", 2))
            };

        [Fact]
        public void EfqDeserialize()
        {
            foreach (var efq in _testEfqs)
            {
                var systemJsonSerialized = SJ.JsonSerializer.Serialize(efq);
                var newtonsoftJsonSerialized = NJ.JsonConvert.SerializeObject(efq);
                newtonsoftJsonSerialized.ShouldBe(systemJsonSerialized);

                var systemJsonDeserialized = SJ.JsonSerializer.Deserialize<EFQ>(systemJsonSerialized);
                systemJsonDeserialized.ShouldBeEquivalentTo(efq);

                var newtonsoftJsonDeserialized = NJ.JsonConvert.DeserializeObject<EFQ>(newtonsoftJsonSerialized);
                newtonsoftJsonDeserialized.ShouldBeEquivalentTo(efq);

                newtonsoftJsonDeserialized.ShouldBeEquivalentTo(systemJsonDeserialized);
            }
        }

        private IEnumerable<EFQ.Constant> _testEfqConstants = new[] {
            new EFQ.Constant("aString"),
            new EFQ.Constant(1),
            new EFQ.Constant(1.2),
            new EFQ.Constant(2.3M),
            new EFQ.Constant(DateTime.Now),
            new EFQ.Constant(DateTimeOffset.Now),
            new EFQ.Constant(TimeSpan.FromHours(1))
            };

        [Fact]
        public void ConstantValueDeserialize()
        {
            foreach (var efqConstant in _testEfqConstants)
            {
                var systemJsonSerialized = SJ.JsonSerializer.Serialize(efqConstant);
                var newtonsoftJsonSerialized = NJ.JsonConvert.SerializeObject(efqConstant);

                newtonsoftJsonSerialized.ShouldBe(systemJsonSerialized);

                var systemJsonDeserialized = SJ.JsonSerializer.Deserialize<EFQ.Constant>(systemJsonSerialized);
                systemJsonDeserialized.ShouldBeEquivalentTo(efqConstant);

                var newtonsoftJsonDeserialized = NJ.JsonConvert.DeserializeObject<EFQ.Constant>(newtonsoftJsonSerialized);
                newtonsoftJsonDeserialized.ShouldBeEquivalentTo(efqConstant);

                newtonsoftJsonDeserialized.ShouldBeEquivalentTo(systemJsonDeserialized);
            }
        }

        [Fact]
        public void ConstantValueDictionaryDeserialize()
        {
            // it would be nice if ShouldBeEquivalentTo() worked with dictionaries, but...
            // https://github.com/shouldly/shouldly/issues/767
            Action<Dictionary<string, EFQ.Constant>, Dictionary<string, EFQ.Constant>> DictsShouldMatch = (dict1, dict2) =>
            {
                dict1.Keys.ShouldBeEquivalentTo(dict2.Keys);
                foreach (var key in dict1.Keys)
                {
                    dict2[key].ShouldBeEquivalentTo(dict1[key]);
                }
            };

            var dict = new Dictionary<string, EFQ.Constant>
            {
                {"first", new EFQ.Constant("string")},
                {"second", new EFQ.Constant(10)},
            };

            var systemJsonSerialized = SJ.JsonSerializer.Serialize(dict);
            var newtonsoftJsonSerialized = NJ.JsonConvert.SerializeObject(dict);

            newtonsoftJsonSerialized.ShouldBe(systemJsonSerialized);

            var systemJsonDeserialized = SJ.JsonSerializer.Deserialize<Dictionary<string, EFQ.Constant>>(systemJsonSerialized);
            DictsShouldMatch(systemJsonDeserialized, dict);

            var newtonsoftJsonDeserialized = NJ.JsonConvert.DeserializeObject<Dictionary<string, EFQ.Constant>>(newtonsoftJsonSerialized);
            DictsShouldMatch(newtonsoftJsonDeserialized, dict);

            DictsShouldMatch(newtonsoftJsonDeserialized, systemJsonDeserialized);
        }
    }
}
