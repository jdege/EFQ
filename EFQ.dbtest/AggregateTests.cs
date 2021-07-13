using System.Linq;
using System.Threading.Tasks;
using EFQ.dbtest;
using EFQ.dbtest.Models;
using JeffDege.EFQ;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace EFQueryTest
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

            var sc = JeffDege.EFQ.EFQ.And(new[]
                {
                    JeffDege.EFQ.EFQ.Equal("itemId", "Item 1"),
                    JeffDege.EFQ.EFQ.Equal("name", "An item"),
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

            var sc = JeffDege.EFQ.EFQ.And(new[]
                {
                    JeffDege.EFQ.EFQ.Equal("itemId", "Item 1"),
                    JeffDege.EFQ.EFQ.IsTrue(),
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

            var sc = JeffDege.EFQ.EFQ.And(
                JeffDege.EFQ.EFQ.Equal("itemId", "Item 1"),
                JeffDege.EFQ.EFQ.IsTrue()
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

            var sc = JeffDege.EFQ.EFQ.And(new[]
                {
                    JeffDege.EFQ.EFQ.Equal("itemId", "Item 1"),
                    JeffDege.EFQ.EFQ.IsFalse(),
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

            var sc = JeffDege.EFQ.EFQ.Or(new[]
                {
                    JeffDege.EFQ.EFQ.Equal("itemId", "Item 1"),
                    JeffDege.EFQ.EFQ.Equal("itemId", "Item 3"),
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

            var sc = JeffDege.EFQ.EFQ.Nand(new[]
                {
                    JeffDege.EFQ.EFQ.Equal("itemId", "Item 1"),
                    JeffDege.EFQ.EFQ.Equal("name", "An item"),
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

            var sc = JeffDege.EFQ.EFQ.Nor(new[]
                {
                    JeffDege.EFQ.EFQ.Equal("itemId", "Item 1"),
                    JeffDege.EFQ.EFQ.Equal("itemId", "Item 3"),
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

            var sc = JeffDege.EFQ.EFQ.Not(JeffDege.EFQ.EFQ.Equal("itemId", "Item 1"));

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
