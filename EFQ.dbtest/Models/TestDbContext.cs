using Microsoft.EntityFrameworkCore;

namespace JDege.EFQ.dbtest.Models
{
    public partial class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
    }
}