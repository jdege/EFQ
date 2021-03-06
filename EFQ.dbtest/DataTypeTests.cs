using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

using JDege.EFQ.dbtest.Models;

namespace JDege.EFQ.dbtest
{
    [Collection("Sequential")]
    public class DatatypeTests : TestDbContextTestBase
    {
        public DatatypeTests()
        : base(new DbContextOptionsBuilder<TestDbContext>().UseSqlite("Filename=Test.db").Options)
        {
        }

        [Fact]
        public async Task testDatetimeAsync()
        {
            var date1 = new DateTime(2014, 1, 1, 11, 12, 13);
            var date2 = new DateTime(2014, 1, 1, 12, 13, 14);
            var date3 = new DateTime(2014, 1, 1, 13, 14, 15);

            Seed(items: new[]
            {

                new Item {itemId = "Item 1", when = date1},
                new Item {itemId = "Item 2", when = date2},
                new Item {itemId = "Item 3", when = date3},
            });

            var efq = JDege.EFQ.EFQBuilder.GreaterThan("when", date2);

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>()).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].itemId.ShouldBe("Item 3");
            }

            efq = JDege.EFQ.EFQBuilder.GreaterThanOrEqual("when", date2);

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>())
                    .OrderBy(i => i.itemId).ToListAsync();
                results.Count.ShouldBe(2);
                results[0].itemId.ShouldBe("Item 2");
                results[1].itemId.ShouldBe("Item 3");
            }
        }

        [Fact]
        public async Task testIntAsync()
        {
            Seed(items: new[]
            {

                new Item {itemId = "Item 1", amount = 10},
                new Item {itemId = "Item 2", amount = 11},
                new Item {itemId = "Item 3", amount = 12},
            });

            var efq = JDege.EFQ.EFQBuilder.GreaterThan("amount", 11);

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>()).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].itemId.ShouldBe("Item 3");
            }

            efq = JDege.EFQ.EFQBuilder.GreaterThanOrEqual("amount", 11);

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>())
                    .OrderBy(i => i.itemId).ToListAsync();
                results.Count.ShouldBe(2);
                results[0].itemId.ShouldBe("Item 2");
                results[1].itemId.ShouldBe("Item 3");
            }
        }
    }
}