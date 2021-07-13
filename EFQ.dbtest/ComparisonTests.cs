using System.Linq;
using System.Threading.Tasks;
using EFQ.dbtest;
using EFQ.dbtest.Models;
using jdege.EFQ;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace EFQueryTest
{
    [Collection("Sequential")]
    public class ComparisonTests : TestDbContextTestBase
    {
        public ComparisonTests()
        : base(new DbContextOptionsBuilder<TestDbContext>().UseSqlite("Filename=Test.db").Options)
        {
        }

        [Fact]
        public async Task testEqualAsync()
        {
            const string expectedName = "An item";
            Seed(items: new[]
            {
                new Item{ itemId = "Item 1", name = expectedName},
                new Item{ itemId = "Item 2", name = "Another item"},
            });

            var sc = jdege.EFQ.EFQ.equal("itemId", "Item 1");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.constructPredicate<Item>()).ToListAsync();

                results.Count.ShouldBe(1);
                results[0].name.ShouldBe(expectedName);
            }
        }

        [Fact]
        public async Task testNotEqualAsync()
        {
            Seed(items: new[]
                {
                    new Item{itemId = "Item 1", name = "An item"},
                    new Item{itemId = "Item 2", name = "Another item"},
                });

            var sc = jdege.EFQ.EFQ.notEqual("itemId", "Item 2");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.constructPredicate<Item>()).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].name.ShouldBe("An item");
            }
        }

        [Fact]
        public async Task testGreaterThanAsync()
        {
            Seed(items: new[]
            {
                    new Item{itemId = "Item 1", name = "An item"},
                    new Item{itemId = "Item 2", name = "Another item"},
                });

            var sc = jdege.EFQ.EFQ.greaterThan("itemId", "Item 1");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.constructPredicate<Item>()).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].name.ShouldBe("Another item");
            }
        }

        [Fact]
        public async Task testGreaterThanOrEqualAsync()
        {
            Seed(items: new[]
            {
                    new Item{itemId = "Item 1", name = "An item"},
                    new Item{itemId = "Item 2", name = "Another item"},
                });

            var sc = jdege.EFQ.EFQ.greaterThanOrEqual("itemId", "Item 2");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.constructPredicate<Item>()).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].name.ShouldBe("Another item");
            }
        }

        [Fact]
        public async Task testLessThanAsync()
        {
            Seed(items: new[]
            {
                    new Item{itemId = "Item 1", name = "An item"},
                    new Item{itemId = "Item 2", name = "Another item"},
                });

            var sc = jdege.EFQ.EFQ.lessThan("itemId", "Item 2");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.constructPredicate<Item>()).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].name.ShouldBe("An item");
            }
        }

        [Fact]
        public async Task testLessThanOrEqualAsync()
        {
            Seed(items: new[]
            {
                    new Item{itemId = "Item 1", name = "An item"},
                    new Item{itemId = "Item 2", name = "Another item"},
                });

            var sc = jdege.EFQ.EFQ.lessThanOrEqual("itemId", "Item 1");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.constructPredicate<Item>()).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].name.ShouldBe("An item");
            }
        }

        [Fact]
        public async Task testContainsAsync()
        {
            Seed(items: new[]
            {
                    new Item{itemId = "abcd"},
                    new Item{itemId = "cdef"},
                    new Item{itemId = "efgh"},
                });

            var sc = jdege.EFQ.EFQ.contains("itemId", "cd");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.constructPredicate<Item>())
                    .OrderBy(i => i.itemId).ToListAsync();
                results.Count.ShouldBe(2);
                results[0].itemId.ShouldBe("abcd");
                results[1].itemId.ShouldBe("cdef");
            }
        }

        [Fact]
        public async Task testStartsWithAsync()
        {
            Seed(items: new[]
            {
                    new Item{itemId = "abcd"},
                    new Item{itemId = "cdef"},
                    new Item{itemId = "efgh"},
                });

            var sc = jdege.EFQ.EFQ.startsWith("itemId", "cd");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.constructPredicate<Item>())
                    .OrderBy(i => i.itemId).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].itemId.ShouldBe("cdef");
            }
        }

        [Fact]
        public async Task testEndsWithAsync()
        {
            Seed(items: new[]
            {
                    new Item{itemId = "abcd"},
                    new Item{itemId = "cdef"},
                    new Item{itemId = "efgh"},
                });

            var sc = jdege.EFQ.EFQ.endsWith("itemId", "cd");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.constructPredicate<Item>())
                    .OrderBy(i => i.itemId).ToListAsync();
                results.Count.ShouldBe(1);
                results[0].itemId.ShouldBe("abcd");
            }
        }

        [Fact]
        public async Task testLikeAsync()
        {
            Seed(items: new[]
            {
                    new Item{itemId = "abcd"},
                    new Item{itemId = "cdef"},
                    new Item{itemId = "efgh"},
                });

            var sc = jdege.EFQ.EFQ.like("itemId", "%d%");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.constructPredicate<Item>())
                    .OrderBy(i => i.itemId).ToListAsync();
                results.Count.ShouldBe(2);
                results[0].itemId.ShouldBe("abcd");
                results[1].itemId.ShouldBe("cdef");
            }
        }
    }
}
