using System.Linq;
using System.Threading.Tasks;
using JDege.EFQ.dbtest;
using JDege.EFQ.dbtest.Models;
using JDege.EFQ;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using System.Collections.Generic;
using System;

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

            var sc = JDege.EFQ.EFQBuilder.Equal("itemId", "{{Context:searchItemId}}");

            var context = new Dictionary<string, EFQ.Constant> {
                {"searchItemId", new EFQ.Constant(searchItemId)}
            };

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var predicate = sc.ConstructPredicate<Item>(context);
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

            var sc = JDege.EFQ.EFQBuilder.Equal("amount", "{{Context:searchAmount}}");

            var context = new Dictionary<string, EFQ.Constant> {
                {"searchAmount", new EFQ.Constant(searchAmount)}
            };

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var predicate = sc.ConstructPredicate<Item>(context);
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

            var sc = JDege.EFQ.EFQBuilder.Equal("when", "{{Context:searchWhen}}");

            var context = new Dictionary<string, EFQ.Constant> {
                {"searchWhen", new EFQ.Constant(searchWhen)}
            };

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var predicate = sc.ConstructPredicate<Item>(context);
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

            var sc = JDege.EFQ.EFQBuilder.Between("when", "{{Context:fromWhen}}", "{{Context:toWhen}}");

            var context = new Dictionary<string, EFQ.Constant> {
                {"fromWhen", new EFQ.Constant(fromWhen)},
                {"toWhen", new EFQ.Constant(toWhen)}
            };

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var predicate = sc.ConstructPredicate<Item>(context);
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
                new Item{itemId = "Item 1", when = mockNow .AddDays(-7)},
                new Item{itemId = expectedItemId, when = mockNow .AddDays(-5)},
                new Item{itemId = "Item 3", when = mockNow .AddDays(-3)},
            });

            var sc = EFQBuilder.Between("when",
                "{{Context:fromWhen}}",
                EFQBuilder.Add("{{Context:fromWhen}}", "{{Context:addInterval}}")
                );

            var context = new Dictionary<string, EFQ.Constant> {
                {"fromWhen", new EFQ.Constant(fromWhen)},
                {"addInterval", new EFQ.Constant(addInterval)}
            };

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var predicate = sc.ConstructPredicate<Item>(context);
                var results = await dbContext.Items.Where(predicate).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].itemId.ShouldBe(expectedItemId);
            }
        }
    }
}
