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
    public class NavigationTests : TestDbContextTestBase
    {
        public NavigationTests()
        : base(new DbContextOptionsBuilder<TestDbContext>().UseSqlite("Filename=Test.db").Options)
        {
        }

        [Fact]
        public void testParent()
        {
            Seed(parents: new[]
                {
                    new Parent {parentId = "Parent 1", name = "A parent"},
                    new Parent {parentId = "Parent 2", name = "Another parent"},
                    new Parent {parentId = "Parent 3", name = "A third parent"}
                },
                items: new[]
                {
                    new Item {itemId = "Item 1", name = "An item", parentId = "Parent 1"},
                    new Item {itemId = "Item 2", name = "Another item", parentId = "Parent 2"},
                    new Item {itemId = "Item 3", name = "A third item", parentId = "Parent 3"},
                });

            var sc = JDege.EFQ.EFQ.Equal("parent.name", "A parent");

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = dbContext.Items.Where(sc.ConstructPredicate<Item>()).ToList();
                results.Count.ShouldBe(1);
                results[0].name.ShouldBe("An item");
            }
        }

        [Fact]
        public void testChildren()
        {
            Seed(items: new[]
                {
                    new Item {itemId = "Item 1", name = "An item"},
                    new Item {itemId = "Item 2", name = "Another item"},
                    new Item {itemId = "Item 3", name = "A third item"},
                },
                children: new[]
                {
                    new Child {childId = "Child 1", name = "A child", itemId = "Item 1"},
                    new Child {childId = "Child 2", name = "Another child", itemId = "Item 2"},
                    new Child {childId = "Child 3", name = "A third child", itemId = "Item 3"},
                });

            var sc = JDege.EFQ.EFQ.Any("Children", JDege.EFQ.EFQ.Equal("name", "A child"));

            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var results = dbContext.Items.Where(sc.ConstructPredicate<Item>()).ToList();
                results.Count.ShouldBe(1);
                results[0].name.ShouldBe("An item");
            }
        }
    }
}
