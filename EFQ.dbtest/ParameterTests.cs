using System.Linq;
using System.Threading.Tasks;
using JDege.EFQ.dbtest;
using JDege.EFQ.dbtest.Models;
using JDege.EFQ;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using System.Collections.Generic;

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
        public async Task testContextParameterAsync()
        {
            Seed(items: new[]
            {
                new Item{itemId = "Item 1", name = "An item"},
                new Item{itemId = "Item 2", name = "Another item"},
                new Item{itemId = "Item 3", name = "A third item"},
            });

            var sc = JDege.EFQ.EFQBuilder.Equal("itemId", "{{Context:anid}}");

            var context = new Dictionary<string, object> {
                {"anid", "Item 2"}
            };

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var predicate = sc.ConstructPredicate<Item>(context);
                var results = await dbContext.Items.Where(predicate).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].name.ShouldBe("Another item");
            }
        }

    }
}
