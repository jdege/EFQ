using System;
using Microsoft.EntityFrameworkCore;

namespace EFQ.dbtest.Models
{
    public partial class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        // protected override void OnModelCreating(DbModelBuilder modelBuilder)
        // {
        //     throw new UnintentionalCodeFirstException();
        // }

        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
    }
}