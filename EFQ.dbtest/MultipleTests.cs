using System.Linq;
using System.Threading.Tasks;
using EFQ.dbtest;
using EFQ.dbtest.Models;
using JDege.EFQ;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace EFQueryTest
{
    [Collection("Sequential")]
    public class MultipleTests : TestDbContextTestBase
    {
        public MultipleTests()
        : base(new DbContextOptionsBuilder<TestDbContext>().UseSqlite("Filename=Test.db").Options)
        {
        }

        [Fact]
        public async Task testContainedInAsync()
        {
            Seed(items: new[]
            {
                new Item{itemId = "Item 1", name = "An item"},
                new Item{itemId = "Item 2", name = "Another item"},
                new Item{itemId = "Item 3", name = "A third item"},
            });

            var sc = JDege.EFQ.EFQ.ContainedIn("itemId", new[]
                {
                    "Item 0",
                    "Item 2",
                    "Item 4"
                });

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.ConstructPredicate<Item>()).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].name.ShouldBe("Another item");
            }
        }

        [Fact]
        public async Task testBetweenAsync()
        {
            Seed(items: new[]
            {
                new Item{itemId = "a"},
                new Item{itemId = "b"},
                new Item{itemId = "d"},
                new Item{itemId = "e"},
                new Item{itemId = "f"},
            });

            var sc = JDege.EFQ.EFQ.Between("itemId", "c", "e");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.ConstructPredicate<Item>())
                    .OrderBy(i => i.itemId).ToListAsync();
                results.Count.ShouldBe(2);
                results[0].itemId.ShouldBe("d");
                results[1].itemId.ShouldBe("e");
            }
        }
    }
}
