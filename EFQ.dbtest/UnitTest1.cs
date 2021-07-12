using System;
using System.Threading.Tasks;
using EFQ.dbtest.Models;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace EFQ.dbtest
{
    public class UnitTest1 : TestDbContextTest
    {
        public UnitTest1()
        : base(new DbContextOptionsBuilder<TestDbContext>().UseSqlite("Filename=Test.db").Options)
        {
        }

        [Fact]
        public void Test1()
        {
            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var parent = dbContext.Parents.FirstOrDefaultAsync().GetAwaiter().GetResult();

                parent.name.ShouldBe("Joe");
            }
        }

        [Fact]
        public async Task Test2Async()
        {
            using (var dbContext = new TestDbContext(ContextOptions))
            {
                var parent = await dbContext.Parents.FirstOrDefaultAsync();

                parent.name.ShouldBe("Joe");
            }
        }
    }
}
