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

            var efq = JDege.EFQ.EFQBuilder.Equal("itemId", "Item 1");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>()).ToListAsync();

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

            var efq = JDege.EFQ.EFQBuilder.NotEqual("itemId", "Item 2");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>()).ToListAsync();
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

            var efq = JDege.EFQ.EFQBuilder.GreaterThan("itemId", "Item 1");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>()).ToListAsync();
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

            var efq = JDege.EFQ.EFQBuilder.GreaterThanOrEqual("itemId", "Item 2");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>()).ToListAsync();
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

            var efq = JDege.EFQ.EFQBuilder.LessThan("itemId", "Item 2");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>()).ToListAsync();
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

            var efq = JDege.EFQ.EFQBuilder.LessThanOrEqual("itemId", "Item 1");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>()).ToListAsync();
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

            var efq = JDege.EFQ.EFQBuilder.Contains("itemId", "cd");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>())
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

            var efq = JDege.EFQ.EFQBuilder.StartsWith("itemId", "cd");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>())
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

            var efq = JDege.EFQ.EFQBuilder.EndsWith("itemId", "cd");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>())
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

            var efq = JDege.EFQ.EFQBuilder.Like("itemId", "%d%");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(efq.ConstructPredicate<Item>())
                    .OrderBy(i => i.itemId).ToListAsync();
                results.Count.ShouldBe(2);
                results[0].itemId.ShouldBe("abcd");
                results[1].itemId.ShouldBe("cdef");
            }
        }

        [Fact]
        public async Task testContext()
        {
            Seed(items: new[] {
                new Item{itemId = "abcd"}
            });

            var efq = JDege.EFQ.EFQBuilder.Equal("itemId", "{{context:foo}}");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var context = new Dictionary<string, EFQ.Constant>
                {
                    { "foo", new EFQ.Constant("abcd") },
                    { "bar", new EFQ.Constant(10) }
                };

                var predicate = efq.ConstructPredicate<Item>(context);

                var results = await dbContext.Items.Where(predicate)
                    .OrderBy(i => i.itemId).ToListAsync();

                results.Count.ShouldBe(1);
                results[0].itemId.ShouldBe("abcd");
            }
        }
    }
}