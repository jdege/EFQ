using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

using JDege.EFQ.dbtest.Models;

namespace JDege.EFQ.dbtest
{
    [Collection("Sequential")]
    public class ParameterTests : TestDbContextTestBase
    {
        public ParameterTests()
        : base(new DbContextOptionsBuilder<TestDbContext>().UseSqlite("Filename=Test.db").Options)
        {
        }

        [Fact]
        public async Task testStringParameterAsync()
        {
            var searchItemId = "Item 2";
            var expectedName = "Another item";
            Seed(items: new[]
            {
                new Item{itemId = "Item 1", name = "An item"},
                new Item{itemId = searchItemId, name = expectedName},
                new Item{itemId = "Item 3", name = "A third item"},
            });

            var efq = EFQBuilder.Equal("itemId", "{{Context:searchItemId}}");

            var paramDict = new Dictionary<string, EFQ.Constant> {
                {"searchItemId", new EFQ.Constant(searchItemId)}
            };

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var predicate = efq.ConstructPredicate<Item>(paramDict);
                var results = await dbContext.Items.Where(predicate).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].name.ShouldBe(expectedName);
            }
        }

        [Fact]
        public async Task testIntParameterAsync()
        {
            var searchAmount = 2;
            var expectedItemId = "Item 2";
            Seed(items: new[]
            {
                new Item{itemId = "Item 1", amount = 1},
                new Item{itemId = expectedItemId, amount = searchAmount},
                new Item{itemId = "Item 3", amount = 3},
            });

            var efq = EFQBuilder.Equal("amount", "{{Context:searchAmount}}");

            var paramDict = new Dictionary<string, EFQ.Constant> {
                {"searchAmount", new EFQ.Constant(searchAmount)}
            };

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var predicate = efq.ConstructPredicate<Item>(paramDict);
                var results = await dbContext.Items.Where(predicate).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].itemId.ShouldBe(expectedItemId);
            }
        }

        [Fact]
        public async Task testDateParameterAsync()
        {
            var searchWhen = DateTime.Parse("2020-01-01");
            var expectedItemId = "Item 2";
            Seed(items: new[]
            {
                new Item{itemId = "Item 1", when = DateTime.Parse("2020-07-14")},
                new Item{itemId = expectedItemId, when = searchWhen},
                new Item{itemId = "Item 3", when = DateTime.Parse("2020-03-11")},
            });

            var efq = EFQBuilder.Equal("when", "{{Context:searchWhen}}");

            var paramDict = new Dictionary<string, EFQ.Constant> {
                {"searchWhen", new EFQ.Constant(searchWhen)}
            };

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var predicate = efq.ConstructPredicate<Item>(paramDict);
                var results = await dbContext.Items.Where(predicate).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].itemId.ShouldBe(expectedItemId);
            }
        }

        [Fact]
        public async Task testDateRangeParameterAsync()
        {
            var mockNow = DateTime.Parse("2020-01-01");
            var fromWhen = mockNow.AddDays(-6);
            var toWhen = mockNow.AddDays(-4);
            var expectedItemId = "Item 2";
            Seed(items: new[]
            {
                new Item{itemId = "Item 1", when = mockNow .AddDays(-7)},
                new Item{itemId = expectedItemId, when = mockNow .AddDays(-5)},
                new Item{itemId = "Item 3", when = mockNow .AddDays(-3)},
            });

            var efq = EFQBuilder.Between("when", "{{Context:fromWhen}}", "{{Context:toWhen}}");

            var paramDict = new Dictionary<string, EFQ.Constant> {
                {"fromWhen", new EFQ.Constant(fromWhen)},
                {"toWhen", new EFQ.Constant(toWhen)}
            };

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var predicate = efq.ConstructPredicate<Item>(paramDict);
                var results = await dbContext.Items.Where(predicate).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].itemId.ShouldBe(expectedItemId);
            }
        }

        [Fact]
        public async Task testDateAddRangeParameterAsync()
        {
            var mockNow = DateTime.Parse("2020-01-01");
            var fromWhen = mockNow.AddDays(-6);
            var addInterval = TimeSpan.FromDays(2);
            var expectedItemId = "Item 2";
            Seed(items: new[]
            {
                new Item{itemId = "Item 1", when = mockNow.AddDays(-7)},
                new Item{itemId = expectedItemId, when = mockNow.AddDays(-5)},
                new Item{itemId = "Item 3", when = mockNow.AddDays(-3)},
            });

            var efq = EFQBuilder.Between("when",
                "{{Context:fromWhen}}",
                EFQBuilder.Add("{{Context:fromWhen}}", "{{Context:addInterval}}")
                );

            var paramDict = new Dictionary<string, EFQ.Constant> {
                {"fromWhen", new EFQ.Constant(fromWhen)},
                {"addInterval", new EFQ.Constant(addInterval)}
            };

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var predicate = efq.ConstructPredicate<Item>(paramDict);
                var results = await dbContext.Items.Where(predicate).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].itemId.ShouldBe(expectedItemId);
            }
        }

        [Fact]
        public async Task testNowDateAsync()
        {
            var expectedItemId = "Item 2";
            Seed(items: new[]
            {
                new Item{itemId = "Item 1", when = DateTime.Parse("2020-07-14")},
                new Item{itemId = expectedItemId, when = DateTime.Now.Date},
                new Item{itemId = "Item 3", when = DateTime.Parse("2020-03-11")},
            });

            var efq = EFQBuilder.Equal("when", "{{NOW:Date}}");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var predicate = efq.ConstructPredicate<Item>();
                var results = await dbContext.Items.Where(predicate).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].itemId.ShouldBe(expectedItemId);
            }
        }

        [Fact]
        public async Task testNowDateTimeAsync()
        {
            var expectedItemId = "Item 2";
            Seed(items: new[]
            {
                new Item{itemId = "Item 1", when = DateTime.Parse("2020-07-14 13:14:15.678")},
                new Item{itemId = expectedItemId, when = DateTime.Now},
                new Item{itemId = "Item 3", when = DateTime.Parse("2020-03-11 13:14:15.678")},
            });

            // exact match of datetime will almost always fail
            var efq = EFQBuilder.Between("when",
                EFQBuilder.Add("{{NOW:DateTime}}", TimeSpan.FromSeconds(-1)),
                EFQBuilder.Add("{{NOW:DateTime}}", TimeSpan.FromSeconds(1))
            );

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var predicate = efq.ConstructPredicate<Item>();
                var results = await dbContext.Items.Where(predicate).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].itemId.ShouldBe(expectedItemId);
            }
        }

        // I had hoped I'd be able to test DateTimeOffset, but SqlLite doesn't support it.
        // [Fact]
        // public async Task testNowDateOffsetAsync()
        // {
        //     var expectedItemId = "Item 2";
        //     Seed(items: new[]
        //     {
        //         new Item{itemId = "Item 1", whenOffset = DateTimeOffset.Parse("2020-07-14")},
        //         new Item{itemId = expectedItemId, whenOffset = DateTimeOffset.Now.Date},
        //         new Item{itemId = "Item 3", whenOffset = DateTimeOffset.Parse("2020-03-11")},
        //     });

        //     var efq = EFQBuilder.Equal("whenOffset", "{{NOW:DateOffset}}");

        //     using (var dbContext = new TestDbContext(ContextOptions))
        //     {
        //         var predicate = efq.ConstructPredicate<Item>();
        //         var results = await dbContext.Items.Where(predicate).ToListAsync();
        //         results.Count.ShouldBe(1);
        //         results[0].itemId.ShouldBe(expectedItemId);
        //     }
        // }

        // I had hoped I'd be able to test DateTimeOffset, but SqlLite doesn't support it.
        // [Fact]
        // public async Task testNowDateTimeOffsetAsync()
        // {
        //     var expectedItemId = "Item 2";
        //     Seed(items: new[]
        //     {
        //         new Item{itemId = "Item 1", whenOffset = DateTimeOffset.Parse("2020-07-14 13:14:15.678")},
        //         new Item{itemId = expectedItemId, whenOffset = DateTimeOffset.Now},
        //         new Item{itemId = "Item 3", whenOffset = DateTimeOffset.Parse("2020-03-11 13:14:15.678")},
        //     });

        //     // exact match of datetime will almost always fail
        //     var efq = EFQBuilder.Between("whenOffset",
        //         EFQBuilder.Add("{{NOW:DateTimeOffset}}", TimeSpan.FromSeconds(-1)),
        //         EFQBuilder.Add("{{NOW:DateTimeOffset}}", TimeSpan.FromSeconds(1))
        //     );

        //     using (var dbContext = new TestDbContext(ContextOptions))
        //     {
        //         var predicate = efq.ConstructPredicate<Item>();
        //         var results = await dbContext.Items.Where(predicate).ToListAsync();
        //         results.Count.ShouldBe(1);
        //         results[0].itemId.ShouldBe(expectedItemId);
        //     }
        // }

        [Fact]
        public async Task testUtcNowDateAsync()
        {
            var expectedItemId = "Item 2";
            Seed(items: new[]
            {
                new Item{itemId = "Item 1", when = DateTime.Parse("2020-07-14")},
                new Item{itemId = expectedItemId, when = DateTime.UtcNow.Date},
                new Item{itemId = "Item 3", when = DateTime.Parse("2020-03-11")},
            });

            var efq = EFQBuilder.Equal("when", "{{UTCNOW:Date}}");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var predicate = efq.ConstructPredicate<Item>();
                var results = await dbContext.Items.Where(predicate).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].itemId.ShouldBe(expectedItemId);
            }
        }

        [Fact]
        public async Task testUtcNowDateTimeAsync()
        {
            var expectedItemId = "Item 2";
            Seed(items: new[]
            {
                new Item{itemId = "Item 1", when = DateTime.Parse("2020-07-14 13:14:15.678")},
                new Item{itemId = expectedItemId, when = DateTime.UtcNow},
                new Item{itemId = "Item 3", when = DateTime.Parse("2020-03-11 13:14:15.678")},
            });

            // exact match of datetime will almost always fail
            var efq = EFQBuilder.Between("when",
                EFQBuilder.Add("{{UTCNOW:DateTime}}", TimeSpan.FromSeconds(-1)),
                EFQBuilder.Add("{{UTCNOW:DateTime}}", TimeSpan.FromSeconds(1))
            );

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var predicate = efq.ConstructPredicate<Item>();
                var results = await dbContext.Items.Where(predicate).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].itemId.ShouldBe(expectedItemId);
            }
        }

        // I had hoped I'd be able to test DateTimeOffset, but SqlLite doesn't support it.
        // [Fact]
        // public async Task testUtcNowDateOffsetAsync()
        // {
        //     var expectedItemId = "Item 2";
        //     Seed(items: new[]
        //     {
        //         new Item{itemId = "Item 1", whenOffset = DateTimeOffset.Parse("2020-07-14")},
        //         new Item{itemId = expectedItemId, whenOffset = DateTimeOffset.UtcNow.Date},
        //         new Item{itemId = "Item 3", whenOffset = DateTimeOffset.Parse("2020-03-11")},
        //     });

        //     var efq = EFQBuilder.Equal("whenOffset", "{{UTCNOW:DateOffset}}");

        //     using (var dbContext = new TestDbContext(ContextOptions))
        //     {
        //         var predicate = efq.ConstructPredicate<Item>();
        //         var results = await dbContext.Items.Where(predicate).ToListAsync();
        //         results.Count.ShouldBe(1);
        //         results[0].itemId.ShouldBe(expectedItemId);
        //     }
        // }

        // I had hoped I'd be able to test DateTimeOffset, but SqlLite doesn't support it.
        // [Fact]
        // public async Task testUtcNowDateTimeOffsetAsync()
        // {
        //     var expectedItemId = "Item 2";
        //     Seed(items: new[]
        //     {
        //         new Item{itemId = "Item 1", whenOffset = DateTimeOffset.Parse("2020-07-14 13:14:15.678")},
        //         new Item{itemId = expectedItemId, whenOffset = DateTimeOffset.UtcNow},
        //         new Item{itemId = "Item 3", whenOffset = DateTimeOffset.Parse("2020-03-11 13:14:15.678")},
        //     });

        //     // exact match of datetime will almost always fail
        //     var efq = EFQBuilder.Between("whenOffset",
        //         EFQBuilder.Add("{{UTCNOW:DateTimeOffset}}", TimeSpan.FromSeconds(-1)),
        //         EFQBuilder.Add("{{UTCNOW:DateTimeOffset}}", TimeSpan.FromSeconds(1))
        //     );

        //     using (var dbContext = new TestDbContext(ContextOptions))
        //     {
        //         var predicate = efq.ConstructPredicate<Item>();
        //         var results = await dbContext.Items.Where(predicate).ToListAsync();
        //         results.Count.ShouldBe(1);
        //         results[0].itemId.ShouldBe(expectedItemId);
        //     }
        // }
    }
}