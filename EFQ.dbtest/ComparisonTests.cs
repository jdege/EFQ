using System.Collections.Generic;
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
    public class ComparisonTests : TestDbContextTest
    {
        public ComparisonTests()
        : base(new DbContextOptionsBuilder<TestDbContext>().UseSqlite("Filename=Test.db").Options)
        {
        }

        [Fact]
        public void testEqual()
        {
            const string expectedName = "An item";
            Seed(items: new[]
            {
                new Item{ itemId = "Item 1", name = expectedName},
                new Item{ itemId = "Item 2", name = "Another item"},
            });

            var sc = EFQuery.equal("itemId", "Item 1");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = dbContext.Items.Where(sc.constructPredicate<Item>()).ToList();

                results.Count.ShouldBe(1);
                results[0].name.ShouldBe(expectedName);
            }
        }

        [Fact]
        public void testNotEqual()
        {
            Seed(items: new[]
                {
                    new Item{itemId = "Item 1", name = "An item"},
                    new Item{itemId = "Item 2", name = "Another item"},
                });

            var sc = EFQuery.notEqual("itemId", "Item 2");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = dbContext.Items.Where(sc.constructPredicate<Item>()).ToList();
                results.Count.ShouldBe(1);
                results[0].name.ShouldBe("An item");
            }
        }

        [Fact]
        public void testGreaterThan()
        {
            Seed(items: new[]
            {
                    new Item{itemId = "Item 1", name = "An item"},
                    new Item{itemId = "Item 2", name = "Another item"},
                });

            var sc = EFQuery.greaterThan("itemId", "Item 1");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = dbContext.Items.Where(sc.constructPredicate<Item>()).ToList();
                results.Count.ShouldBe(1);
                results[0].name.ShouldBe("Another item");
            }
        }

        [Fact]
        public void testGreaterThanOrEqual()
        {
            Seed(items: new[]
            {
                    new Item{itemId = "Item 1", name = "An item"},
                    new Item{itemId = "Item 2", name = "Another item"},
                });

            var sc = EFQuery.greaterThanOrEqual("itemId", "Item 2");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = dbContext.Items.Where(sc.constructPredicate<Item>()).ToList();
                results.Count.ShouldBe(1);
                results[0].name.ShouldBe("Another item");
            }
        }

        [Fact]
        public void testLessThan()
        {
            Seed(items: new[]
            {
                    new Item{itemId = "Item 1", name = "An item"},
                    new Item{itemId = "Item 2", name = "Another item"},
                });

            var sc = EFQuery.lessThan("itemId", "Item 2");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = dbContext.Items.Where(sc.constructPredicate<Item>()).ToList();
                results.Count.ShouldBe(1);
                results[0].name.ShouldBe("An item");
            }
        }

        [Fact]
        public void testLessThanOrEqual()
        {
            Seed(items: new[]
            {
                    new Item{itemId = "Item 1", name = "An item"},
                    new Item{itemId = "Item 2", name = "Another item"},
                });

            var sc = EFQuery.lessThanOrEqual("itemId", "Item 1");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = dbContext.Items.Where(sc.constructPredicate<Item>()).ToList();
                results.Count.ShouldBe(1);
                results[0].name.ShouldBe("An item");
            }
        }

        [Fact]
        public void testContains()
        {
            Seed(items: new[]
            {
                    new Item{itemId = "abcd"},
                    new Item{itemId = "cdef"},
                    new Item{itemId = "efgh"},
                });

            var sc = EFQuery.contains("itemId", "cd");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = dbContext.Items.Where(sc.constructPredicate<Item>())
                    .OrderBy(i => i.itemId).ToList();
                results.Count.ShouldBe(2);
                results[0].itemId.ShouldBe("abcd");
                results[1].itemId.ShouldBe("cdef");
            }
        }

        [Fact]
        public void testStartsWith()
        {
            Seed(items: new[]
            {
                    new Item{itemId = "abcd"},
                    new Item{itemId = "cdef"},
                    new Item{itemId = "efgh"},
                });

            var sc = EFQuery.startsWith("itemId", "cd");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = dbContext.Items.Where(sc.constructPredicate<Item>())
                    .OrderBy(i => i.itemId).ToList();
                results.Count.ShouldBe(1);
                results[0].itemId.ShouldBe("cdef");
            }
        }

        [Fact]
        public void testEndsWith()
        {
            Seed(items: new[]
            {
                    new Item{itemId = "abcd"},
                    new Item{itemId = "cdef"},
                    new Item{itemId = "efgh"},
                });

            var sc = EFQuery.endsWith("itemId", "cd");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = dbContext.Items.Where(sc.constructPredicate<Item>())
                    .OrderBy(i => i.itemId).ToList();
                results.Count.ShouldBe(1);
                results[0].itemId.ShouldBe("abcd");
            }
        }

        [Fact]
        public void testLike()
        {
            Seed(items: new[]
            {
                    new Item{itemId = "abcd"},
                    new Item{itemId = "cdef"},
                    new Item{itemId = "efgh"},
                });

            var sc = EFQuery.like("itemId", "%d%");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = dbContext.Items.Where(sc.constructPredicate<Item>())
                    .OrderBy(i => i.itemId).ToList();
                results.Count.ShouldBe(2);
                results[0].itemId.ShouldBe("abcd");
                results[1].itemId.ShouldBe("cdef");
            }
        }
    }
}

