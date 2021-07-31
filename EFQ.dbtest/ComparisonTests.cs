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

            var sc = JDege.EFQ.EFQBuilder.Equal("itemId", "Item 1");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.ConstructPredicate<Item>()).ToListAsync();

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

            var sc = JDege.EFQ.EFQBuilder.NotEqual("itemId", "Item 2");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.ConstructPredicate<Item>()).ToListAsync();
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

            var sc = JDege.EFQ.EFQBuilder.GreaterThan("itemId", "Item 1");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.ConstructPredicate<Item>()).ToListAsync();
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

            var sc = JDege.EFQ.EFQBuilder.GreaterThanOrEqual("itemId", "Item 2");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.ConstructPredicate<Item>()).ToListAsync();
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

            var sc = JDege.EFQ.EFQBuilder.LessThan("itemId", "Item 2");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.ConstructPredicate<Item>()).ToListAsync();
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

            var sc = JDege.EFQ.EFQBuilder.LessThanOrEqual("itemId", "Item 1");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.ConstructPredicate<Item>()).ToListAsync();
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

            var sc = JDege.EFQ.EFQBuilder.Contains("itemId", "cd");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.ConstructPredicate<Item>())
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

            var sc = JDege.EFQ.EFQBuilder.StartsWith("itemId", "cd");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.ConstructPredicate<Item>())
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

            var sc = JDege.EFQ.EFQBuilder.EndsWith("itemId", "cd");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.ConstructPredicate<Item>())
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

            var sc = JDege.EFQ.EFQBuilder.Like("itemId", "%d%");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = await dbContext.Items.Where(sc.ConstructPredicate<Item>())
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

            var sc = JDege.EFQ.EFQBuilder.Equal("itemId", "{{context:foo}}");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var context = new Dictionary<string, object>
                {
                    { "foo", "abcd" },
                    { "bar", 10 }
                };

                var predicate = sc.ConstructPredicate<Item>(context);

                var results = await dbContext.Items.Where(predicate)
                    .OrderBy(i => i.itemId).ToListAsync();

                results.Count.ShouldBe(1);
                results[0].itemId.ShouldBe("abcd");
            }
        }
    }
}

