using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JDege.EFQ.Web.Entities
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasIndex(e => e.ReportsTo, "IFK_EmployeeReportsTo");

            builder.Property(e => e.Address).HasMaxLength(70);

            builder.Property(e => e.BirthDate).HasColumnType("datetime");

            builder.Property(e => e.City).HasMaxLength(40);

            builder.Property(e => e.Country).HasMaxLength(40);

            builder.Property(e => e.Email).HasMaxLength(60);

            builder.Property(e => e.Fax).HasMaxLength(24);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.HireDate).HasColumnType("datetime");

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Phone).HasMaxLength(24);

            builder.Property(e => e.PostalCode).HasMaxLength(10);

            builder.Property(e => e.State).HasMaxLength(40);

            builder.Property(e => e.Title).HasMaxLength(30);

            builder.HasOne(d => d.ReportsToNavigation)
                .WithMany(p => p.InverseReportsToNavigation)
                .HasForeignKey(d => d.ReportsTo)
                .HasConstraintName("FK_EmployeeReportsTo");

            seedData(builder);
        }
        private void seedData(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    EmployeeId = 1,
                    LastName = "Adams",
                    FirstName = "Andrew",
                    Title = "General Manager",
                    ReportsTo = null,
                    BirthDate = DateTime.Parse("1962-02-18T06:00:00.000Z"),
                    HireDate = DateTime.Parse("2002-08-14T05:00:00.000Z"),
                    Address = "11120 Jasper Ave NW",
                    City = "Edmonton",
                    State = "AB",
                    Country = "Canada",
                    PostalCode = "T5K 2N1",
                    Phone = "+1 (780) 428-9482",
                    Fax = "+1 (780) 428-3457",
                    Email = "andrew@chinookcorp.com"
                },
                new Employee
                {
                    EmployeeId = 2,
                    LastName = "Edwards",
                    FirstName = "Nancy",
                    Title = "Sales Manager",
                    ReportsTo = 1,
                    BirthDate = DateTime.Parse("1958-12-08T06:00:00.000Z"),
                    HireDate = DateTime.Parse("2002-05-01T05:00:00.000Z"),
                    Address = "825 8 Ave SW",
                    City = "Calgary",
                    State = "AB",
                    Country = "Canada",
                    PostalCode = "T2P 2T3",
                    Phone = "+1 (403) 262-3443",
                    Fax = "+1 (403) 262-3322",
                    Email = "nancy@chinookcorp.com"
                },
                new Employee
                {
                    EmployeeId = 3,
                    LastName = "Peacock",
                    FirstName = "Jane",
                    Title = "Sales Support Agent",
                    ReportsTo = 2,
                    BirthDate = DateTime.Parse("1973-08-29T05:00:00.000Z"),
                    HireDate = DateTime.Parse("2002-04-01T06:00:00.000Z"),
                    Address = "1111 6 Ave SW",
                    City = "Calgary",
                    State = "AB",
                    Country = "Canada",
                    PostalCode = "T2P 5M5",
                    Phone = "+1 (403) 262-3443",
                    Fax = "+1 (403) 262-6712",
                    Email = "jane@chinookcorp.com"
                },
                new Employee
                {
                    EmployeeId = 4,
                    LastName = "Park",
                    FirstName = "Margaret",
                    Title = "Sales Support Agent",
                    ReportsTo = 2,
                    BirthDate = DateTime.Parse("1947-09-19T05:00:00.000Z"),
                    HireDate = DateTime.Parse("2003-05-03T05:00:00.000Z"),
                    Address = "683 10 Street SW",
                    City = "Calgary",
                    State = "AB",
                    Country = "Canada",
                    PostalCode = "T2P 5G3",
                    Phone = "+1 (403) 263-4423",
                    Fax = "+1 (403) 263-4289",
                    Email = "margaret@chinookcorp.com"
                },
                new Employee
                {
                    EmployeeId = 5,
                    LastName = "Johnson",
                    FirstName = "Steve",
                    Title = "Sales Support Agent",
                    ReportsTo = 2,
                    BirthDate = DateTime.Parse("1965-03-03T06:00:00.000Z"),
                    HireDate = DateTime.Parse("2003-10-17T05:00:00.000Z"),
                    Address = "7727B 41 Ave",
                    City = "Calgary",
                    State = "AB",
                    Country = "Canada",
                    PostalCode = "T3B 1Y7",
                    Phone = "1 (780) 836-9987",
                    Fax = "1 (780) 836-9543",
                    Email = "steve@chinookcorp.com"
                },
                new Employee
                {
                    EmployeeId = 6,
                    LastName = "Mitchell",
                    FirstName = "Michael",
                    Title = "IT Manager",
                    ReportsTo = 1,
                    BirthDate = DateTime.Parse("1973-07-01T05:00:00.000Z"),
                    HireDate = DateTime.Parse("2003-10-17T05:00:00.000Z"),
                    Address = "5827 Bowness Road NW",
                    City = "Calgary",
                    State = "AB",
                    Country = "Canada",
                    PostalCode = "T3B 0C5",
                    Phone = "+1 (403) 246-9887",
                    Fax = "+1 (403) 246-9899",
                    Email = "michael@chinookcorp.com"
                },
                new Employee
                {
                    EmployeeId = 7,
                    LastName = "King",
                    FirstName = "Robert",
                    Title = "IT Staff",
                    ReportsTo = 6,
                    BirthDate = DateTime.Parse("1970-05-29T05:00:00.000Z"),
                    HireDate = DateTime.Parse("2004-01-02T06:00:00.000Z"),
                    Address = "590 Columbia Boulevard West",
                    City = "Lethbridge",
                    State = "AB",
                    Country = "Canada",
                    PostalCode = "T1K 5N8",
                    Phone = "+1 (403) 456-9986",
                    Fax = "+1 (403) 456-8485",
                    Email = "robert@chinookcorp.com"
                },
                new Employee
                {
                    EmployeeId = 8,
                    LastName = "Callahan",
                    FirstName = "Laura",
                    Title = "IT Staff",
                    ReportsTo = 6,
                    BirthDate = DateTime.Parse("1968-01-09T06:00:00.000Z"),
                    HireDate = DateTime.Parse("2004-03-04T06:00:00.000Z"),
                    Address = "923 7 ST NW",
                    City = "Lethbridge",
                    State = "AB",
                    Country = "Canada",
                    PostalCode = "T1H 1Y8",
                    Phone = "+1 (403) 467-3351",
                    Fax = "+1 (403) 467-8772",
                    Email = "laura@chinookcorp.com"
                }
            );
        }
    }
}