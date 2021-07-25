using Shouldly;
using Xunit;
using System.Collections.Generic;

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
                EFQBuilder.Contains("fieldname", "123")
            };

        [Fact]
        public void NewtonsoftShouldDeserializeItself()
        {
            foreach (var efq in _testEfqs)
            {
                var s = NJ.JsonConvert.SerializeObject(efq);
                var d = NJ.JsonConvert.DeserializeObject<EFQ>(s);
                d.ShouldBeEquivalentTo(efq);
            }
        }

        [Fact]
        public void SystemTextJsonDeserializeItself()
        {
            foreach (var efq in _testEfqs)
            {
                var s = SJ.JsonSerializer.Serialize(efq);
                var d = SJ.JsonSerializer.Deserialize<EFQ>(s);
                d.ShouldBeEquivalentTo(efq);
            }
        }

        [Fact]
        public void NewtonsoftShouldDeserializeSystemTextJson()
        {
            foreach (var efq in _testEfqs)
            {
                var s = SJ.JsonSerializer.Serialize(efq);
                var d = NJ.JsonConvert.DeserializeObject<EFQ>(s);
                d.ShouldBeEquivalentTo(efq);
            }
        }

        [Fact]
        public void SystemTextJsonDeserializeNewtonsoft()
        {
            foreach (var efq in _testEfqs)
            {
                var s = SJ.JsonSerializer.Serialize(efq);
                var d = SJ.JsonSerializer.Deserialize<EFQ>(s);
                d.ShouldBeEquivalentTo(efq);
            }
        }
    }
}
