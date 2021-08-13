using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

using JDege.EFQ.dbtest.Models;

namespace JDege.EFQ.dbtest
{
    [Collection("Sequential")]
    public class AggregateTests : TestDbContextTestBase
    {
        public AggregateTests()
        : base(new DbContextOptionsBuilder<TestDbContext>().UseSqlite("Filename=Test.db").Options)
        {
        }

        [Fact]
        public async Task testAndAsync()
        {
            Seed(items: new[]
            {
                new Item{itemId = "Item 1", name = "An item"},
                new Item{itemId = "Item 2", name = "Another item"},
                new Item{itemId = "Item 3", name = "A third item"},
            });

            var efq = JDege.EFQ.EFQBuilder.And(new[]
                {
                    JDege.EFQ.EFQBuilder.Equal("itemId", "Item 1"),
                    JDege.EFQ.EFQBuilder.Equal("name", "An item"),
                });

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>()).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].name.ShouldBe("An item");
            }
        }

        [Fact]
        public async Task testAndTrueAsync()
        {
            Seed(items: new[]
            {
                new Item{itemId = "Item 1", name = "An item"},
                new Item{itemId = "Item 2", name = "Another item"},
                new Item{itemId = "Item 3", name = "A third item"},
            });

            var efq = JDege.EFQ.EFQBuilder.And(new[]
                {
                    JDege.EFQ.EFQBuilder.Equal("itemId", "Item 1"),
                    JDege.EFQ.EFQBuilder.IsTrue(),
                });

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>()).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].name.ShouldBe("An item");
            }
        }

        [Fact]
        public async Task testAndTrueWithParamsAsync()
        {
            Seed(items: new[]
            {
                new Item{itemId = "Item 1", name = "An item"},
                new Item{itemId = "Item 2", name = "Another item"},
                new Item{itemId = "Item 3", name = "A third item"},
            });

            var efq = JDege.EFQ.EFQBuilder.And(
                JDege.EFQ.EFQBuilder.Equal("itemId", "Item 1"),
                JDege.EFQ.EFQBuilder.IsTrue()
            );

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>()).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].name.ShouldBe("An item");
            }
        }

        [Fact]
        public async Task testAndFalseAsync()
        {
            Seed(items: new[]
            {
                new Item{itemId = "Item 1", name = "An item"},
                new Item{itemId = "Item 2", name = "Another item"},
                new Item{itemId = "Item 3", name = "A third item"},
            });

            var efq = JDege.EFQ.EFQBuilder.And(new[]
                {
                    JDege.EFQ.EFQBuilder.Equal("itemId", "Item 1"),
                    JDege.EFQ.EFQBuilder.IsFalse(),
                });

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>()).ToListAsync();
                results.Count.ShouldBe(0);
            }
        }

        [Fact]
        public async Task testOrAsync()
        {
            Seed(items: new[]
            {
                new Item{itemId = "Item 1", name = "An item"},
                new Item{itemId = "Item 2", name = "Another item"},
                new Item{itemId = "Item 3", name = "A third item"},
            });

            var efq = JDege.EFQ.EFQBuilder.Or(new[]
                {
                    JDege.EFQ.EFQBuilder.Equal("itemId", "Item 1"),
                    JDege.EFQ.EFQBuilder.Equal("itemId", "Item 3"),
                });

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>())
                    .OrderBy(i => i.itemId).ToListAsync();
                results.Count.ShouldBe(2);
                results[0].name.ShouldBe("An item");
                results[1].name.ShouldBe("A third item");
            }
        }

        [Fact]
        public async Task testNandAsync()
        {
            Seed(items: new[]
            {
                new Item{itemId = "Item 1", name = "An item"},
                new Item{itemId = "Item 2", name = "Another item"},
                new Item{itemId = "Item 3", name = "A third item"},
            });

            var efq = JDege.EFQ.EFQBuilder.Nand(new[]
                {
                    JDege.EFQ.EFQBuilder.Equal("itemId", "Item 1"),
                    JDege.EFQ.EFQBuilder.Equal("name", "An item"),
                });

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>())
                    .OrderBy(i => i.itemId).ToListAsync();
                results.Count.ShouldBe(2);
                results[0].name.ShouldBe("Another item");
                results[1].name.ShouldBe("A third item");
            }
        }

        [Fact]
        public async Task testNorAsync()
        {
            Seed(items: new[]
            {
                new Item{itemId = "Item 1", name = "An item"},
                new Item{itemId = "Item 2", name = "Another item"},
                new Item{itemId = "Item 3", name = "A third item"},
            });

            var efq = JDege.EFQ.EFQBuilder.Nor(new[]
                {
                    JDege.EFQ.EFQBuilder.Equal("itemId", "Item 1"),
                    JDege.EFQ.EFQBuilder.Equal("itemId", "Item 3"),
                });

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>()).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].name.ShouldBe("Another item");
            }
        }

        [Fact]
        public async Task testNotAsync()
        {
            Seed(items: new[]
            {
                new Item{itemId = "Item 1", name = "An item"},
                new Item{itemId = "Item 2", name = "Another item"},
                new Item{itemId = "Item 3", name = "A third item"},
            });

            var efq = JDege.EFQ.EFQBuilder.Not(JDege.EFQ.EFQBuilder.Equal("itemId", "Item 1"));

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>())
                    .OrderBy(i => i.itemId).ToListAsync();
                results.Count.ShouldBe(2);
                results[0].name.ShouldBe("Another item");
                results[1].name.ShouldBe("A third item");
            }
        }
    }
}