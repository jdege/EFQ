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
                EFQBuilder.Equal("fieldname", "astring"),
                EFQBuilder.Equal("fieldname", 1),
                EFQBuilder.Equal("fieldname", 1.1),
                EFQBuilder.Equal("fieldname", 1D),
                EFQBuilder.Equal("fieldname", DateTime.Now),
                EFQBuilder.Equal("fieldname", DateTimeOffset.Now),
                EFQBuilder.Not(EFQBuilder.Equal("fieldname", "astring")),
                EFQBuilder.Any("fieldname", EFQBuilder.Equal("child.fieldname", "astring")),
                EFQBuilder.Contains("fieldname", "123"),
                EFQBuilder.Equal("ArtistId", 90),
                EFQBuilder.Equal("fieldname", DateTime.Parse("2021-01-21T13:14:15.678")),
                EFQBuilder.Equal("fieldname", DateTimeOffset.Parse("2021-01-21T13:14:15.678")),
                EFQBuilder.Equal("fieldname", new TimeSpan(days: 0, hours: 13, minutes: 14, seconds: 15, milliseconds: 678))
            };

        [Fact]
        public void EfqDeserialize()
        {
            foreach (var efq in _testEfqs)
            {
                var s = SJ.JsonSerializer.Serialize(efq);
                var d = SJ.JsonSerializer.Deserialize<EFQ>(s);
                d.ShouldBeEquivalentTo(efq);
            }
        }

        // [Fact]
        // public void EfqNewtonsoftDeserialize()
        // {
        //     foreach (var efq in _testEfqs)
        //     {
        //         var s = NJ.JsonConvert.SerializeObject(efq);
        //         var d = NJ.JsonConvert.DeserializeObject<EFQ>(d);
        //         d.ShouldBeEquivalentTo(efq);
        //     }
        // }

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
