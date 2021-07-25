using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace JDege.EFQ.test
{
    public class SerializationTests
    {
        [Fact]
        public void NewtonSoftShouldSerializeItself()
        {
            var efqs = new[] {
                EFQBuilder.IsTrue(),
                EFQBuilder.IsFalse()
            };

            foreach (var efq in efqs)
            {
                var s = JsonConvert.SerializeObject(efq);
                var d = JsonConvert.DeserializeObject<EFQ>(s);
                d.ShouldBeEquivalentTo(efq);
            }
        }
    }
}
