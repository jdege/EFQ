using System.Linq;
using System.Threading.Tasks;
using EFQ.dbtest;
using EFQ.dbtest.Models;
using JeffDege.EFQuery;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace EFQueryTest
{
    [Collection("Sequential")]
    public class AggregateTests : TestDbContextTest
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

            var sc = EFQuery.and(new[]
                {
                    EFQuery.equal("itemId", "Item 1"),
                    EFQuery.equal("name", "An item"),
                });

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.constructPredicate<Item>()).ToListAsync();
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

            var sc = EFQuery.and(new[]
                {
                    EFQuery.equal("itemId", "Item 1"),
                    EFQuery.isTrue(),
                });

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.constructPredicate<Item>()).ToListAsync();
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

            var sc = EFQuery.and(
                EFQuery.equal("itemId", "Item 1"),
                EFQuery.isTrue()
            );

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.constructPredicate<Item>()).ToListAsync();
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

            var sc = EFQuery.and(new[]
                {
                    EFQuery.equal("itemId", "Item 1"),
                    EFQuery.isFalse(),
                });

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.constructPredicate<Item>()).ToListAsync();
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

            var sc = EFQuery.or(new[]
                {
                    EFQuery.equal("itemId", "Item 1"),
                    EFQuery.equal("itemId", "Item 3"),
                });

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.constructPredicate<Item>())
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

            var sc = EFQuery.nand(new[]
                {
                    EFQuery.equal("itemId", "Item 1"),
                    EFQuery.equal("name", "An item"),
                });

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.constructPredicate<Item>())
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

            var sc = EFQuery.nor(new[]
                {
                    EFQuery.equal("itemId", "Item 1"),
                    EFQuery.equal("itemId", "Item 3"),
                });

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.constructPredicate<Item>()).ToListAsync();
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

            var sc = EFQuery.not(EFQuery.equal("itemId", "Item 1"));

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.constructPredicate<Item>())
                    .OrderBy(i => i.itemId).ToListAsync();
                results.Count.ShouldBe(2);
                results[0].name.ShouldBe("Another item");
                results[1].name.ShouldBe("A third item");
            }
        }
    }
}
