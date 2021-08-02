using System;
using System.Collections.Generic;
using System.Text.Json;
using Shouldly;
using Xunit;

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
        public void SystemTextJsonDeserializeItself()
        {
            foreach (var efq in _testEfqs)
            {
                var s = JsonSerializer.Serialize(efq);
                var d = JsonSerializer.Deserialize<EFQ>(s);
                d.ShouldBeEquivalentTo(efq);
            }
        }
    }
}
