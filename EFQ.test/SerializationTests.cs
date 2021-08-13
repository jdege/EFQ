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
                var sj = SJ.JsonSerializer.Serialize(efq);
                var nj = NJ.JsonConvert.SerializeObject(efq);
                nj.ShouldBe(sj);

                var sd = SJ.JsonSerializer.Deserialize<EFQ>(sj);
                sd.ShouldBeEquivalentTo(efq);

                // var nd = NJ.JsonConvert.DeserializeObject<EFQ>(nj);
                // nd.ShouldBeEquivalentTo(efq);

                // nd.ShouldBeEquivalentTo(sd);
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
                var s = SJ.JsonSerializer.Serialize(efqConstant);
                var d = SJ.JsonSerializer.Deserialize<EFQ.Constant>(s);
                d.ShouldBeEquivalentTo(efqConstant);
            }
        }

        [Fact]
        public void ConstantValueDictionaryDeserialize()
        {
            var dict = new Dictionary<string, EFQ.Constant>
            {
                {"first", new EFQ.Constant("string")},
                {"second", new EFQ.Constant(10)},
            };

            var s = SJ.JsonSerializer.Serialize(dict);
            var d = SJ.JsonSerializer.Deserialize<Dictionary<string, EFQ.Constant>>(s);
            d.ShouldBeEquivalentTo(d);
        }
    }
}
