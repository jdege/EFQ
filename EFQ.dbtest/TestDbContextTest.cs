using Microsoft.EntityFrameworkCore;
using EFQ.dbtest.Models;

namespace EFQ.dbtest
{
    public class TestDbContextTest
    {
        protected TestDbContextTest(DbContextOptions<TestDbContext> contextOptions)
        {
            ContextOptions = contextOptions;

            Seed();
        }

        protected DbContextOptions<TestDbContext> ContextOptions { get; }

        private void Seed()
        {
            using (var dbContext = new TestDbContext(ContextOptions))
            {
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();

                dbContext.Parents.Add(new Parent
                {
                    parentId = "P1",
                    name = "Joe"
                });

                dbContext.SaveChanges();
            }
        }
    }
}

