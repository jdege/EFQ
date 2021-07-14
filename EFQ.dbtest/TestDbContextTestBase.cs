using Microsoft.EntityFrameworkCore;
using JDege.EFQ.dbtest.Models;
using System.Collections.Generic;

namespace JDege.EFQ.dbtest
{
    public class TestDbContextTestBase
    {
        protected DbContextOptions<TestDbContext> ContextOptions { get; }

        protected TestDbContextTestBase(DbContextOptions<TestDbContext> contextOptions)
        {
            ContextOptions = contextOptions;

            Init();
        }

        private void Init()
        {
            using (var dbContext = new TestDbContext(ContextOptions))
            {
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
            }
        }

        public void Clear()
        {
            using (var dbContext = new TestDbContext(ContextOptions))
            {
                dbContext.Children.RemoveRange(dbContext.Children);
                dbContext.Items.RemoveRange(dbContext.Items);
                dbContext.Parents.RemoveRange(dbContext.Parents);

                dbContext.SaveChanges();
            }
        }

        public void Seed(IEnumerable<Parent> parents = null, IEnumerable<Item> items = null, IEnumerable<Child> children = null)
        {
            using (var dbContext = new TestDbContext(ContextOptions))
            {
                if (parents != null)
                    dbContext.Parents.AddRange(parents);
                if (items != null)
                    dbContext.Items.AddRange(items);
                if (children != null)
                    dbContext.Children.AddRange(children);

                dbContext.SaveChanges();
            }
        }
    }
}

