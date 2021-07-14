using System.Linq;
using System.Threading.Tasks;
using JDege.EFQ.dbtest;
using JDege.EFQ.dbtest.Models;
using JDege.EFQ;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

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

            var sc = JDege.EFQ.EFQ.And(new[]
                {
                    JDege.EFQ.EFQ.Equal("itemId", "Item 1"),
                    JDege.EFQ.EFQ.Equal("name", "An item"),
                });

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.ConstructPredicate<Item>()).ToListAsync();
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

            var sc = JDege.EFQ.EFQ.And(new[]
                {
                    JDege.EFQ.EFQ.Equal("itemId", "Item 1"),
                    JDege.EFQ.EFQ.IsTrue(),
                });

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.ConstructPredicate<Item>()).ToListAsync();
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

            var sc = JDege.EFQ.EFQ.And(
                JDege.EFQ.EFQ.Equal("itemId", "Item 1"),
                JDege.EFQ.EFQ.IsTrue()
            );

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.ConstructPredicate<Item>()).ToListAsync();
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

            var sc = JDege.EFQ.EFQ.And(new[]
                {
                    JDege.EFQ.EFQ.Equal("itemId", "Item 1"),
                    JDege.EFQ.EFQ.IsFalse(),
                });

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.ConstructPredicate<Item>()).ToListAsync();
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

            var sc = JDege.EFQ.EFQ.Or(new[]
                {
                    JDege.EFQ.EFQ.Equal("itemId", "Item 1"),
                    JDege.EFQ.EFQ.Equal("itemId", "Item 3"),
                });

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.ConstructPredicate<Item>())
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

            var sc = JDege.EFQ.EFQ.Nand(new[]
                {
                    JDege.EFQ.EFQ.Equal("itemId", "Item 1"),
                    JDege.EFQ.EFQ.Equal("name", "An item"),
                });

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.ConstructPredicate<Item>())
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

            var sc = JDege.EFQ.EFQ.Nor(new[]
                {
                    JDege.EFQ.EFQ.Equal("itemId", "Item 1"),
                    JDege.EFQ.EFQ.Equal("itemId", "Item 3"),
                });

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.ConstructPredicate<Item>()).ToListAsync();
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

            var sc = JDege.EFQ.EFQ.Not(JDege.EFQ.EFQ.Equal("itemId", "Item 1"));

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.ConstructPredicate<Item>())
                    .OrderBy(i => i.itemId).ToListAsync();
                results.Count.ShouldBe(2);
                results[0].name.ShouldBe("Another item");
                results[1].name.ShouldBe("A third item");
            }
        }
    }
}
