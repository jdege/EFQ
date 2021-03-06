using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;

using Shouldly;
using Xunit;

using SJ = System.Text.Json;
using NJ = Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace JDege.EFQ.test
{
    public class SerializationTests
    {
        private SJ.JsonSerializerOptions _jso;

        public SerializationTests()
        {
            // System.Text.Json defaults to aggressively escaping characters when it serializes
            // Specifically, it escapes '+' as '\u002B', which means that DateTimeOffsets in the
            // eastern hemisphere don't serialize the same way as in Newtonsoft.Json.
            _jso = new SJ.JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
        }

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
                var systemJsonSerialized = SJ.JsonSerializer.Serialize(efq, _jso);
                var newtonsoftJsonSerialized = NJ.JsonConvert.SerializeObject(efq);
                newtonsoftJsonSerialized.ShouldBe(systemJsonSerialized, ShowFilePosition());

                var systemJsonDeserialized = SJ.JsonSerializer.Deserialize<EFQ>(systemJsonSerialized);
                systemJsonDeserialized.ShouldBeEquivalentTo(efq, ShowFilePosition());

                var newtonsoftJsonDeserialized = NJ.JsonConvert.DeserializeObject<EFQ>(newtonsoftJsonSerialized);
                newtonsoftJsonDeserialized.ShouldBeEquivalentTo(efq, ShowFilePosition());

                newtonsoftJsonDeserialized.ShouldBeEquivalentTo(systemJsonDeserialized, ShowFilePosition());
            }
        }

        private static string ShowFilePosition(
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string member = null)
        {
            return $"Path: {filePath}, Line: {lineNumber}, Member: {member}";
        }

        private IEnumerable<EFQ.Constant> _testEfqConstants = new[] {
            new EFQ.Constant("aString"),
            new EFQ.Constant(1),
            new EFQ.Constant(1.2),
            new EFQ.Constant(2.3M),
            new EFQ.Constant(DateTime.Now),
            new EFQ.Constant(DateTimeOffset.Now),
            new EFQ.Constant(new DateTimeOffset(
                year: DateTime.UtcNow.Year,
                month: DateTime.UtcNow.Month,
                day: DateTime.UtcNow.Day,
                hour: DateTime.UtcNow.Hour,
                minute: DateTime.UtcNow.Minute,
                second: DateTime.UtcNow.Second,
                millisecond: DateTime.UtcNow.Second,
                offset: TimeSpan.FromHours(-5)
            )),
            new EFQ.Constant(new DateTimeOffset(
                year: DateTime.UtcNow.Year,
                month: DateTime.UtcNow.Month,
                day: DateTime.UtcNow.Day,
                hour: DateTime.UtcNow.Hour,
                minute: DateTime.UtcNow.Minute,
                second: DateTime.UtcNow.Second,
                millisecond: DateTime.UtcNow.Second,
                offset: TimeSpan.FromHours(5)
            )),
            new EFQ.Constant(TimeSpan.FromHours(1))
            };

        [Fact]
        public void ConstantValueDeserialize()
        {
            foreach (var efqConstant in _testEfqConstants)
            {
                var systemJsonSerialized = SJ.JsonSerializer.Serialize(efqConstant, _jso);
                var newtonsoftJsonSerialized = NJ.JsonConvert.SerializeObject(efqConstant);

                newtonsoftJsonSerialized.ShouldBe(systemJsonSerialized, ShowFilePosition());

                var systemJsonDeserialized = SJ.JsonSerializer.Deserialize<EFQ.Constant>(systemJsonSerialized);
                systemJsonDeserialized.ShouldBeEquivalentTo(efqConstant, ShowFilePosition());

                var newtonsoftJsonDeserialized = NJ.JsonConvert.DeserializeObject<EFQ.Constant>(newtonsoftJsonSerialized);
                newtonsoftJsonDeserialized.ShouldBeEquivalentTo(efqConstant, ShowFilePosition());

                newtonsoftJsonDeserialized.ShouldBeEquivalentTo(systemJsonDeserialized, ShowFilePosition());
            }
        }

        [Fact]
        public void ConstantValueDictionaryDeserialize()
        {
            // it would be nice if ShouldBeEquivalentTo() worked with dictionaries, but...
            // https://github.com/shouldly/shouldly/issues/767
            Action<Dictionary<string, EFQ.Constant>, Dictionary<string, EFQ.Constant>> DictsShouldMatch = (dict1, dict2) =>
            {
                dict1.Keys.ShouldBeEquivalentTo(dict2.Keys, ShowFilePosition());
                foreach (var key in dict1.Keys)
                {
                    dict2[key].ShouldBeEquivalentTo(dict1[key], ShowFilePosition());
                }
            };

            var dict = new Dictionary<string, EFQ.Constant>
            {
                {"first", new EFQ.Constant("string")},
                {"second", new EFQ.Constant(10)},
            };

            var systemJsonSerialized = SJ.JsonSerializer.Serialize(dict, _jso);
            var newtonsoftJsonSerialized = NJ.JsonConvert.SerializeObject(dict);

            newtonsoftJsonSerialized.ShouldBe(systemJsonSerialized, ShowFilePosition());

            var systemJsonDeserialized = SJ.JsonSerializer.Deserialize<Dictionary<string, EFQ.Constant>>(systemJsonSerialized);
            DictsShouldMatch(systemJsonDeserialized, dict);

            var newtonsoftJsonDeserialized = NJ.JsonConvert.DeserializeObject<Dictionary<string, EFQ.Constant>>(newtonsoftJsonSerialized);
            DictsShouldMatch(newtonsoftJsonDeserialized, dict);

            DictsShouldMatch(newtonsoftJsonDeserialized, systemJsonDeserialized);
        }
    }
}