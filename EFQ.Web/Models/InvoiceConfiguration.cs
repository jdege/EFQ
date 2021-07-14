using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JDege.EFQ.Web.Models
{
    internal class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoice");

            builder.HasIndex(e => e.CustomerId, "IFK_InvoiceCustomerId");

            builder.Property(e => e.BillingAddress).HasMaxLength(70);

            builder.Property(e => e.BillingCity).HasMaxLength(40);

            builder.Property(e => e.BillingCountry).HasMaxLength(40);

            builder.Property(e => e.BillingPostalCode).HasMaxLength(10);

            builder.Property(e => e.BillingState).HasMaxLength(40);

            builder.Property(e => e.InvoiceDate).HasColumnType("datetime");

            builder.Property(e => e.Total).HasColumnType("numeric(10, 2)");

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceCustomerId");

            seedData(builder);
        }
        private void seedData(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasData(
                new Invoice
                {
                    InvoiceId = 1,
                    CustomerId = 2,
                    InvoiceDate = DateTime.Parse("2009-01-01T06:00:00.000Z"),
                    BillingAddress = "Theodor-Heuss-Straße 34",
                    BillingCity = "Stuttgart",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "70174",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 2,
                    CustomerId = 4,
                    InvoiceDate = DateTime.Parse("2009-01-02T06:00:00.000Z"),
                    BillingAddress = "Ullevålsveien 14",
                    BillingCity = "Oslo",
                    BillingState = null,
                    BillingCountry = "Norway",
                    BillingPostalCode = "0171",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 3,
                    CustomerId = 8,
                    InvoiceDate = DateTime.Parse("2009-01-03T06:00:00.000Z"),
                    BillingAddress = "Grétrystraat 63",
                    BillingCity = "Brussels",
                    BillingState = null,
                    BillingCountry = "Belgium",
                    BillingPostalCode = "1000",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 4,
                    CustomerId = 14,
                    InvoiceDate = DateTime.Parse("2009-01-06T06:00:00.000Z"),
                    BillingAddress = "8210 111 ST NW",
                    BillingCity = "Edmonton",
                    BillingState = "AB",
                    BillingCountry = "Canada",
                    BillingPostalCode = "T6G 2C7",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 5,
                    CustomerId = 23,
                    InvoiceDate = DateTime.Parse("2009-01-11T06:00:00.000Z"),
                    BillingAddress = "69 Salem Street",
                    BillingCity = "Boston",
                    BillingState = "MA",
                    BillingCountry = "USA",
                    BillingPostalCode = "2113",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 6,
                    CustomerId = 37,
                    InvoiceDate = DateTime.Parse("2009-01-19T06:00:00.000Z"),
                    BillingAddress = "Berger Straße 10",
                    BillingCity = "Frankfurt",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "60316",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 7,
                    CustomerId = 38,
                    InvoiceDate = DateTime.Parse("2009-02-01T06:00:00.000Z"),
                    BillingAddress = "Barbarossastraße 19",
                    BillingCity = "Berlin",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "10779",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 8,
                    CustomerId = 40,
                    InvoiceDate = DateTime.Parse("2009-02-01T06:00:00.000Z"),
                    BillingAddress = "8, Rue Hanovre",
                    BillingCity = "Paris",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "75002",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 9,
                    CustomerId = 42,
                    InvoiceDate = DateTime.Parse("2009-02-02T06:00:00.000Z"),
                    BillingAddress = "9, Place Louis Barthou",
                    BillingCity = "Bordeaux",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "33000",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 10,
                    CustomerId = 46,
                    InvoiceDate = DateTime.Parse("2009-02-03T06:00:00.000Z"),
                    BillingAddress = "3 Chatham Street",
                    BillingCity = "Dublin",
                    BillingState = "Dublin",
                    BillingCountry = "Ireland",
                    BillingPostalCode = null,
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 11,
                    CustomerId = 52,
                    InvoiceDate = DateTime.Parse("2009-02-06T06:00:00.000Z"),
                    BillingAddress = "202 Hoxton Street",
                    BillingCity = "London",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "N1 5LH",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 12,
                    CustomerId = 2,
                    InvoiceDate = DateTime.Parse("2009-02-11T06:00:00.000Z"),
                    BillingAddress = "Theodor-Heuss-Straße 34",
                    BillingCity = "Stuttgart",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "70174",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 13,
                    CustomerId = 16,
                    InvoiceDate = DateTime.Parse("2009-02-19T06:00:00.000Z"),
                    BillingAddress = "1600 Amphitheatre Parkway",
                    BillingCity = "Mountain View",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "94043-1351",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 14,
                    CustomerId = 17,
                    InvoiceDate = DateTime.Parse("2009-03-04T06:00:00.000Z"),
                    BillingAddress = "1 Microsoft Way",
                    BillingCity = "Redmond",
                    BillingState = "WA",
                    BillingCountry = "USA",
                    BillingPostalCode = "98052-8300",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 15,
                    CustomerId = 19,
                    InvoiceDate = DateTime.Parse("2009-03-04T06:00:00.000Z"),
                    BillingAddress = "1 Infinite Loop",
                    BillingCity = "Cupertino",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "95014",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 16,
                    CustomerId = 21,
                    InvoiceDate = DateTime.Parse("2009-03-05T06:00:00.000Z"),
                    BillingAddress = "801 W 4th Street",
                    BillingCity = "Reno",
                    BillingState = "NV",
                    BillingCountry = "USA",
                    BillingPostalCode = "89503",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 17,
                    CustomerId = 25,
                    InvoiceDate = DateTime.Parse("2009-03-06T06:00:00.000Z"),
                    BillingAddress = "319 N. Frances Street",
                    BillingCity = "Madison",
                    BillingState = "WI",
                    BillingCountry = "USA",
                    BillingPostalCode = "53703",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 18,
                    CustomerId = 31,
                    InvoiceDate = DateTime.Parse("2009-03-09T05:00:00.000Z"),
                    BillingAddress = "194A Chain Lake Drive",
                    BillingCity = "Halifax",
                    BillingState = "NS",
                    BillingCountry = "Canada",
                    BillingPostalCode = "B3S 1C5",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 19,
                    CustomerId = 40,
                    InvoiceDate = DateTime.Parse("2009-03-14T05:00:00.000Z"),
                    BillingAddress = "8, Rue Hanovre",
                    BillingCity = "Paris",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "75002",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 20,
                    CustomerId = 54,
                    InvoiceDate = DateTime.Parse("2009-03-22T05:00:00.000Z"),
                    BillingAddress = "110 Raeburn Pl",
                    BillingCity = "Edinburgh ",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "EH4 1HH",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 21,
                    CustomerId = 55,
                    InvoiceDate = DateTime.Parse("2009-04-04T05:00:00.000Z"),
                    BillingAddress = "421 Bourke Street",
                    BillingCity = "Sidney",
                    BillingState = "NSW",
                    BillingCountry = "Australia",
                    BillingPostalCode = "2010",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 22,
                    CustomerId = 57,
                    InvoiceDate = DateTime.Parse("2009-04-04T05:00:00.000Z"),
                    BillingAddress = "Calle Lira, 198",
                    BillingCity = "Santiago",
                    BillingState = null,
                    BillingCountry = "Chile",
                    BillingPostalCode = null,
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 23,
                    CustomerId = 59,
                    InvoiceDate = DateTime.Parse("2009-04-05T05:00:00.000Z"),
                    BillingAddress = "3,Raj Bhavan Road",
                    BillingCity = "Bangalore",
                    BillingState = null,
                    BillingCountry = "India",
                    BillingPostalCode = "560001",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 24,
                    CustomerId = 4,
                    InvoiceDate = DateTime.Parse("2009-04-06T05:00:00.000Z"),
                    BillingAddress = "Ullevålsveien 14",
                    BillingCity = "Oslo",
                    BillingState = null,
                    BillingCountry = "Norway",
                    BillingPostalCode = "0171",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 25,
                    CustomerId = 10,
                    InvoiceDate = DateTime.Parse("2009-04-09T05:00:00.000Z"),
                    BillingAddress = "Rua Dr. Falcão Filho, 155",
                    BillingCity = "São Paulo",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "01007-010",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 26,
                    CustomerId = 19,
                    InvoiceDate = DateTime.Parse("2009-04-14T05:00:00.000Z"),
                    BillingAddress = "1 Infinite Loop",
                    BillingCity = "Cupertino",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "95014",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 27,
                    CustomerId = 33,
                    InvoiceDate = DateTime.Parse("2009-04-22T05:00:00.000Z"),
                    BillingAddress = "5112 48 Street",
                    BillingCity = "Yellowknife",
                    BillingState = "NT",
                    BillingCountry = "Canada",
                    BillingPostalCode = "X1A 1N6",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 28,
                    CustomerId = 34,
                    InvoiceDate = DateTime.Parse("2009-05-05T05:00:00.000Z"),
                    BillingAddress = "Rua da Assunção 53",
                    BillingCity = "Lisbon",
                    BillingState = null,
                    BillingCountry = "Portugal",
                    BillingPostalCode = null,
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 29,
                    CustomerId = 36,
                    InvoiceDate = DateTime.Parse("2009-05-05T05:00:00.000Z"),
                    BillingAddress = "Tauentzienstraße 8",
                    BillingCity = "Berlin",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "10789",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 30,
                    CustomerId = 38,
                    InvoiceDate = DateTime.Parse("2009-05-06T05:00:00.000Z"),
                    BillingAddress = "Barbarossastraße 19",
                    BillingCity = "Berlin",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "10779",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 31,
                    CustomerId = 42,
                    InvoiceDate = DateTime.Parse("2009-05-07T05:00:00.000Z"),
                    BillingAddress = "9, Place Louis Barthou",
                    BillingCity = "Bordeaux",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "33000",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 32,
                    CustomerId = 48,
                    InvoiceDate = DateTime.Parse("2009-05-10T05:00:00.000Z"),
                    BillingAddress = "Lijnbaansgracht 120bg",
                    BillingCity = "Amsterdam",
                    BillingState = "VV",
                    BillingCountry = "Netherlands",
                    BillingPostalCode = "1016",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 33,
                    CustomerId = 57,
                    InvoiceDate = DateTime.Parse("2009-05-15T05:00:00.000Z"),
                    BillingAddress = "Calle Lira, 198",
                    BillingCity = "Santiago",
                    BillingState = null,
                    BillingCountry = "Chile",
                    BillingPostalCode = null,
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 34,
                    CustomerId = 12,
                    InvoiceDate = DateTime.Parse("2009-05-23T05:00:00.000Z"),
                    BillingAddress = "Praça Pio X, 119",
                    BillingCity = "Rio de Janeiro",
                    BillingState = "RJ",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "20040-020",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 35,
                    CustomerId = 13,
                    InvoiceDate = DateTime.Parse("2009-06-05T05:00:00.000Z"),
                    BillingAddress = "Qe 7 Bloco G",
                    BillingCity = "Brasília",
                    BillingState = "DF",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "71020-677",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 36,
                    CustomerId = 15,
                    InvoiceDate = DateTime.Parse("2009-06-05T05:00:00.000Z"),
                    BillingAddress = "700 W Pender Street",
                    BillingCity = "Vancouver",
                    BillingState = "BC",
                    BillingCountry = "Canada",
                    BillingPostalCode = "V6C 1G8",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 37,
                    CustomerId = 17,
                    InvoiceDate = DateTime.Parse("2009-06-06T05:00:00.000Z"),
                    BillingAddress = "1 Microsoft Way",
                    BillingCity = "Redmond",
                    BillingState = "WA",
                    BillingCountry = "USA",
                    BillingPostalCode = "98052-8300",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 38,
                    CustomerId = 21,
                    InvoiceDate = DateTime.Parse("2009-06-07T05:00:00.000Z"),
                    BillingAddress = "801 W 4th Street",
                    BillingCity = "Reno",
                    BillingState = "NV",
                    BillingCountry = "USA",
                    BillingPostalCode = "89503",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 39,
                    CustomerId = 27,
                    InvoiceDate = DateTime.Parse("2009-06-10T05:00:00.000Z"),
                    BillingAddress = "1033 N Park Ave",
                    BillingCity = "Tucson",
                    BillingState = "AZ",
                    BillingCountry = "USA",
                    BillingPostalCode = "85719",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 40,
                    CustomerId = 36,
                    InvoiceDate = DateTime.Parse("2009-06-15T05:00:00.000Z"),
                    BillingAddress = "Tauentzienstraße 8",
                    BillingCity = "Berlin",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "10789",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 41,
                    CustomerId = 50,
                    InvoiceDate = DateTime.Parse("2009-06-23T05:00:00.000Z"),
                    BillingAddress = "C/ San Bernardo 85",
                    BillingCity = "Madrid",
                    BillingState = null,
                    BillingCountry = "Spain",
                    BillingPostalCode = "28015",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 42,
                    CustomerId = 51,
                    InvoiceDate = DateTime.Parse("2009-07-06T05:00:00.000Z"),
                    BillingAddress = "Celsiusg. 9",
                    BillingCity = "Stockholm",
                    BillingState = null,
                    BillingCountry = "Sweden",
                    BillingPostalCode = "11230",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 43,
                    CustomerId = 53,
                    InvoiceDate = DateTime.Parse("2009-07-06T05:00:00.000Z"),
                    BillingAddress = "113 Lupus St",
                    BillingCity = "London",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "SW1V 3EN",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 44,
                    CustomerId = 55,
                    InvoiceDate = DateTime.Parse("2009-07-07T05:00:00.000Z"),
                    BillingAddress = "421 Bourke Street",
                    BillingCity = "Sidney",
                    BillingState = "NSW",
                    BillingCountry = "Australia",
                    BillingPostalCode = "2010",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 45,
                    CustomerId = 59,
                    InvoiceDate = DateTime.Parse("2009-07-08T05:00:00.000Z"),
                    BillingAddress = "3,Raj Bhavan Road",
                    BillingCity = "Bangalore",
                    BillingState = null,
                    BillingCountry = "India",
                    BillingPostalCode = "560001",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 46,
                    CustomerId = 6,
                    InvoiceDate = DateTime.Parse("2009-07-11T05:00:00.000Z"),
                    BillingAddress = "Rilská 3174/6",
                    BillingCity = "Prague",
                    BillingState = null,
                    BillingCountry = "Czech Republic",
                    BillingPostalCode = "14300",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 47,
                    CustomerId = 15,
                    InvoiceDate = DateTime.Parse("2009-07-16T05:00:00.000Z"),
                    BillingAddress = "700 W Pender Street",
                    BillingCity = "Vancouver",
                    BillingState = "BC",
                    BillingCountry = "Canada",
                    BillingPostalCode = "V6C 1G8",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 48,
                    CustomerId = 29,
                    InvoiceDate = DateTime.Parse("2009-07-24T05:00:00.000Z"),
                    BillingAddress = "796 Dundas Street West",
                    BillingCity = "Toronto",
                    BillingState = "ON",
                    BillingCountry = "Canada",
                    BillingPostalCode = "M6J 1V1",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 49,
                    CustomerId = 30,
                    InvoiceDate = DateTime.Parse("2009-08-06T05:00:00.000Z"),
                    BillingAddress = "230 Elgin Street",
                    BillingCity = "Ottawa",
                    BillingState = "ON",
                    BillingCountry = "Canada",
                    BillingPostalCode = "K2P 1L7",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 50,
                    CustomerId = 32,
                    InvoiceDate = DateTime.Parse("2009-08-06T05:00:00.000Z"),
                    BillingAddress = "696 Osborne Street",
                    BillingCity = "Winnipeg",
                    BillingState = "MB",
                    BillingCountry = "Canada",
                    BillingPostalCode = "R3L 2B9",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 51,
                    CustomerId = 34,
                    InvoiceDate = DateTime.Parse("2009-08-07T05:00:00.000Z"),
                    BillingAddress = "Rua da Assunção 53",
                    BillingCity = "Lisbon",
                    BillingState = null,
                    BillingCountry = "Portugal",
                    BillingPostalCode = null,
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 52,
                    CustomerId = 38,
                    InvoiceDate = DateTime.Parse("2009-08-08T05:00:00.000Z"),
                    BillingAddress = "Barbarossastraße 19",
                    BillingCity = "Berlin",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "10779",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 53,
                    CustomerId = 44,
                    InvoiceDate = DateTime.Parse("2009-08-11T05:00:00.000Z"),
                    BillingAddress = "Porthaninkatu 9",
                    BillingCity = "Helsinki",
                    BillingState = null,
                    BillingCountry = "Finland",
                    BillingPostalCode = "00530",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 54,
                    CustomerId = 53,
                    InvoiceDate = DateTime.Parse("2009-08-16T05:00:00.000Z"),
                    BillingAddress = "113 Lupus St",
                    BillingCity = "London",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "SW1V 3EN",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 55,
                    CustomerId = 8,
                    InvoiceDate = DateTime.Parse("2009-08-24T05:00:00.000Z"),
                    BillingAddress = "Grétrystraat 63",
                    BillingCity = "Brussels",
                    BillingState = null,
                    BillingCountry = "Belgium",
                    BillingPostalCode = "1000",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 56,
                    CustomerId = 9,
                    InvoiceDate = DateTime.Parse("2009-09-06T05:00:00.000Z"),
                    BillingAddress = "Sønder Boulevard 51",
                    BillingCity = "Copenhagen",
                    BillingState = null,
                    BillingCountry = "Denmark",
                    BillingPostalCode = "1720",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 57,
                    CustomerId = 11,
                    InvoiceDate = DateTime.Parse("2009-09-06T05:00:00.000Z"),
                    BillingAddress = "Av. Paulista, 2022",
                    BillingCity = "São Paulo",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "01310-200",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 58,
                    CustomerId = 13,
                    InvoiceDate = DateTime.Parse("2009-09-07T05:00:00.000Z"),
                    BillingAddress = "Qe 7 Bloco G",
                    BillingCity = "Brasília",
                    BillingState = "DF",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "71020-677",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 59,
                    CustomerId = 17,
                    InvoiceDate = DateTime.Parse("2009-09-08T05:00:00.000Z"),
                    BillingAddress = "1 Microsoft Way",
                    BillingCity = "Redmond",
                    BillingState = "WA",
                    BillingCountry = "USA",
                    BillingPostalCode = "98052-8300",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 60,
                    CustomerId = 23,
                    InvoiceDate = DateTime.Parse("2009-09-11T05:00:00.000Z"),
                    BillingAddress = "69 Salem Street",
                    BillingCity = "Boston",
                    BillingState = "MA",
                    BillingCountry = "USA",
                    BillingPostalCode = "2113",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 61,
                    CustomerId = 32,
                    InvoiceDate = DateTime.Parse("2009-09-16T05:00:00.000Z"),
                    BillingAddress = "696 Osborne Street",
                    BillingCity = "Winnipeg",
                    BillingState = "MB",
                    BillingCountry = "Canada",
                    BillingPostalCode = "R3L 2B9",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 62,
                    CustomerId = 46,
                    InvoiceDate = DateTime.Parse("2009-09-24T05:00:00.000Z"),
                    BillingAddress = "3 Chatham Street",
                    BillingCity = "Dublin",
                    BillingState = "Dublin",
                    BillingCountry = "Ireland",
                    BillingPostalCode = null,
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 63,
                    CustomerId = 47,
                    InvoiceDate = DateTime.Parse("2009-10-07T05:00:00.000Z"),
                    BillingAddress = "Via Degli Scipioni, 43",
                    BillingCity = "Rome",
                    BillingState = "RM",
                    BillingCountry = "Italy",
                    BillingPostalCode = "00192",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 64,
                    CustomerId = 49,
                    InvoiceDate = DateTime.Parse("2009-10-07T05:00:00.000Z"),
                    BillingAddress = "Ordynacka 10",
                    BillingCity = "Warsaw",
                    BillingState = null,
                    BillingCountry = "Poland",
                    BillingPostalCode = "00-358",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 65,
                    CustomerId = 51,
                    InvoiceDate = DateTime.Parse("2009-10-08T05:00:00.000Z"),
                    BillingAddress = "Celsiusg. 9",
                    BillingCity = "Stockholm",
                    BillingState = null,
                    BillingCountry = "Sweden",
                    BillingPostalCode = "11230",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 66,
                    CustomerId = 55,
                    InvoiceDate = DateTime.Parse("2009-10-09T05:00:00.000Z"),
                    BillingAddress = "421 Bourke Street",
                    BillingCity = "Sidney",
                    BillingState = "NSW",
                    BillingCountry = "Australia",
                    BillingPostalCode = "2010",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 67,
                    CustomerId = 2,
                    InvoiceDate = DateTime.Parse("2009-10-12T05:00:00.000Z"),
                    BillingAddress = "Theodor-Heuss-Straße 34",
                    BillingCity = "Stuttgart",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "70174",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 68,
                    CustomerId = 11,
                    InvoiceDate = DateTime.Parse("2009-10-17T05:00:00.000Z"),
                    BillingAddress = "Av. Paulista, 2022",
                    BillingCity = "São Paulo",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "01310-200",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 69,
                    CustomerId = 25,
                    InvoiceDate = DateTime.Parse("2009-10-25T05:00:00.000Z"),
                    BillingAddress = "319 N. Frances Street",
                    BillingCity = "Madison",
                    BillingState = "WI",
                    BillingCountry = "USA",
                    BillingPostalCode = "53703",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 70,
                    CustomerId = 26,
                    InvoiceDate = DateTime.Parse("2009-11-07T06:00:00.000Z"),
                    BillingAddress = "2211 W Berry Street",
                    BillingCity = "Fort Worth",
                    BillingState = "TX",
                    BillingCountry = "USA",
                    BillingPostalCode = "76110",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 71,
                    CustomerId = 28,
                    InvoiceDate = DateTime.Parse("2009-11-07T06:00:00.000Z"),
                    BillingAddress = "302 S 700 E",
                    BillingCity = "Salt Lake City",
                    BillingState = "UT",
                    BillingCountry = "USA",
                    BillingPostalCode = "84102",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 72,
                    CustomerId = 30,
                    InvoiceDate = DateTime.Parse("2009-11-08T06:00:00.000Z"),
                    BillingAddress = "230 Elgin Street",
                    BillingCity = "Ottawa",
                    BillingState = "ON",
                    BillingCountry = "Canada",
                    BillingPostalCode = "K2P 1L7",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 73,
                    CustomerId = 34,
                    InvoiceDate = DateTime.Parse("2009-11-09T06:00:00.000Z"),
                    BillingAddress = "Rua da Assunção 53",
                    BillingCity = "Lisbon",
                    BillingState = null,
                    BillingCountry = "Portugal",
                    BillingPostalCode = null,
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 74,
                    CustomerId = 40,
                    InvoiceDate = DateTime.Parse("2009-11-12T06:00:00.000Z"),
                    BillingAddress = "8, Rue Hanovre",
                    BillingCity = "Paris",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "75002",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 75,
                    CustomerId = 49,
                    InvoiceDate = DateTime.Parse("2009-11-17T06:00:00.000Z"),
                    BillingAddress = "Ordynacka 10",
                    BillingCity = "Warsaw",
                    BillingState = null,
                    BillingCountry = "Poland",
                    BillingPostalCode = "00-358",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 76,
                    CustomerId = 4,
                    InvoiceDate = DateTime.Parse("2009-11-25T06:00:00.000Z"),
                    BillingAddress = "Ullevålsveien 14",
                    BillingCity = "Oslo",
                    BillingState = null,
                    BillingCountry = "Norway",
                    BillingPostalCode = "0171",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 77,
                    CustomerId = 5,
                    InvoiceDate = DateTime.Parse("2009-12-08T06:00:00.000Z"),
                    BillingAddress = "Klanova 9/506",
                    BillingCity = "Prague",
                    BillingState = null,
                    BillingCountry = "Czech Republic",
                    BillingPostalCode = "14700",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 78,
                    CustomerId = 7,
                    InvoiceDate = DateTime.Parse("2009-12-08T06:00:00.000Z"),
                    BillingAddress = "Rotenturmstraße 4, 1010 Innere Stadt",
                    BillingCity = "Vienne",
                    BillingState = null,
                    BillingCountry = "Austria",
                    BillingPostalCode = "1010",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 79,
                    CustomerId = 9,
                    InvoiceDate = DateTime.Parse("2009-12-09T06:00:00.000Z"),
                    BillingAddress = "Sønder Boulevard 51",
                    BillingCity = "Copenhagen",
                    BillingState = null,
                    BillingCountry = "Denmark",
                    BillingPostalCode = "1720",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 80,
                    CustomerId = 13,
                    InvoiceDate = DateTime.Parse("2009-12-10T06:00:00.000Z"),
                    BillingAddress = "Qe 7 Bloco G",
                    BillingCity = "Brasília",
                    BillingState = "DF",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "71020-677",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 81,
                    CustomerId = 19,
                    InvoiceDate = DateTime.Parse("2009-12-13T06:00:00.000Z"),
                    BillingAddress = "1 Infinite Loop",
                    BillingCity = "Cupertino",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "95014",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 82,
                    CustomerId = 28,
                    InvoiceDate = DateTime.Parse("2009-12-18T06:00:00.000Z"),
                    BillingAddress = "302 S 700 E",
                    BillingCity = "Salt Lake City",
                    BillingState = "UT",
                    BillingCountry = "USA",
                    BillingPostalCode = "84102",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 83,
                    CustomerId = 42,
                    InvoiceDate = DateTime.Parse("2009-12-26T06:00:00.000Z"),
                    BillingAddress = "9, Place Louis Barthou",
                    BillingCity = "Bordeaux",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "33000",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 84,
                    CustomerId = 43,
                    InvoiceDate = DateTime.Parse("2010-01-08T06:00:00.000Z"),
                    BillingAddress = "68, Rue Jouvence",
                    BillingCity = "Dijon",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "21000",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 85,
                    CustomerId = 45,
                    InvoiceDate = DateTime.Parse("2010-01-08T06:00:00.000Z"),
                    BillingAddress = "Erzsébet krt. 58.",
                    BillingCity = "Budapest",
                    BillingState = null,
                    BillingCountry = "Hungary",
                    BillingPostalCode = "H-1073",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 86,
                    CustomerId = 47,
                    InvoiceDate = DateTime.Parse("2010-01-09T06:00:00.000Z"),
                    BillingAddress = "Via Degli Scipioni, 43",
                    BillingCity = "Rome",
                    BillingState = "RM",
                    BillingCountry = "Italy",
                    BillingPostalCode = "00192",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 87,
                    CustomerId = 51,
                    InvoiceDate = DateTime.Parse("2010-01-10T06:00:00.000Z"),
                    BillingAddress = "Celsiusg. 9",
                    BillingCity = "Stockholm",
                    BillingState = null,
                    BillingCountry = "Sweden",
                    BillingPostalCode = "11230",
                    Total = 6.94M
                },
                new Invoice
                {
                    InvoiceId = 88,
                    CustomerId = 57,
                    InvoiceDate = DateTime.Parse("2010-01-13T06:00:00.000Z"),
                    BillingAddress = "Calle Lira, 198",
                    BillingCity = "Santiago",
                    BillingState = null,
                    BillingCountry = "Chile",
                    BillingPostalCode = null,
                    Total = 17.91M
                },
                new Invoice
                {
                    InvoiceId = 89,
                    CustomerId = 7,
                    InvoiceDate = DateTime.Parse("2010-01-18T06:00:00.000Z"),
                    BillingAddress = "Rotenturmstraße 4, 1010 Innere Stadt",
                    BillingCity = "Vienne",
                    BillingState = null,
                    BillingCountry = "Austria",
                    BillingPostalCode = "1010",
                    Total = 18.86M
                },
                new Invoice
                {
                    InvoiceId = 90,
                    CustomerId = 21,
                    InvoiceDate = DateTime.Parse("2010-01-26T06:00:00.000Z"),
                    BillingAddress = "801 W 4th Street",
                    BillingCity = "Reno",
                    BillingState = "NV",
                    BillingCountry = "USA",
                    BillingPostalCode = "89503",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 91,
                    CustomerId = 22,
                    InvoiceDate = DateTime.Parse("2010-02-08T06:00:00.000Z"),
                    BillingAddress = "120 S Orange Ave",
                    BillingCity = "Orlando",
                    BillingState = "FL",
                    BillingCountry = "USA",
                    BillingPostalCode = "32801",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 92,
                    CustomerId = 24,
                    InvoiceDate = DateTime.Parse("2010-02-08T06:00:00.000Z"),
                    BillingAddress = "162 E Superior Street",
                    BillingCity = "Chicago",
                    BillingState = "IL",
                    BillingCountry = "USA",
                    BillingPostalCode = "60611",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 93,
                    CustomerId = 26,
                    InvoiceDate = DateTime.Parse("2010-02-09T06:00:00.000Z"),
                    BillingAddress = "2211 W Berry Street",
                    BillingCity = "Fort Worth",
                    BillingState = "TX",
                    BillingCountry = "USA",
                    BillingPostalCode = "76110",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 94,
                    CustomerId = 30,
                    InvoiceDate = DateTime.Parse("2010-02-10T06:00:00.000Z"),
                    BillingAddress = "230 Elgin Street",
                    BillingCity = "Ottawa",
                    BillingState = "ON",
                    BillingCountry = "Canada",
                    BillingPostalCode = "K2P 1L7",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 95,
                    CustomerId = 36,
                    InvoiceDate = DateTime.Parse("2010-02-13T06:00:00.000Z"),
                    BillingAddress = "Tauentzienstraße 8",
                    BillingCity = "Berlin",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "10789",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 96,
                    CustomerId = 45,
                    InvoiceDate = DateTime.Parse("2010-02-18T06:00:00.000Z"),
                    BillingAddress = "Erzsébet krt. 58.",
                    BillingCity = "Budapest",
                    BillingState = null,
                    BillingCountry = "Hungary",
                    BillingPostalCode = "H-1073",
                    Total = 21.86M
                },
                new Invoice
                {
                    InvoiceId = 97,
                    CustomerId = 59,
                    InvoiceDate = DateTime.Parse("2010-02-26T06:00:00.000Z"),
                    BillingAddress = "3,Raj Bhavan Road",
                    BillingCity = "Bangalore",
                    BillingState = null,
                    BillingCountry = "India",
                    BillingPostalCode = "560001",
                    Total = 1.99M
                },
                new Invoice
                {
                    InvoiceId = 98,
                    CustomerId = 1,
                    InvoiceDate = DateTime.Parse("2010-03-11T06:00:00.000Z"),
                    BillingAddress = "Av. Brigadeiro Faria Lima, 2170",
                    BillingCity = "São José dos Campos",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "12227-000",
                    Total = 3.98M
                },
                new Invoice
                {
                    InvoiceId = 99,
                    CustomerId = 3,
                    InvoiceDate = DateTime.Parse("2010-03-11T06:00:00.000Z"),
                    BillingAddress = "1498 rue Bélanger",
                    BillingCity = "Montréal",
                    BillingState = "QC",
                    BillingCountry = "Canada",
                    BillingPostalCode = "H2G 1A7",
                    Total = 3.98M
                },
                new Invoice
                {
                    InvoiceId = 100,
                    CustomerId = 5,
                    InvoiceDate = DateTime.Parse("2010-03-12T06:00:00.000Z"),
                    BillingAddress = "Klanova 9/506",
                    BillingCity = "Prague",
                    BillingState = null,
                    BillingCountry = "Czech Republic",
                    BillingPostalCode = "14700",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 101,
                    CustomerId = 9,
                    InvoiceDate = DateTime.Parse("2010-03-13T06:00:00.000Z"),
                    BillingAddress = "Sønder Boulevard 51",
                    BillingCity = "Copenhagen",
                    BillingState = null,
                    BillingCountry = "Denmark",
                    BillingPostalCode = "1720",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 102,
                    CustomerId = 15,
                    InvoiceDate = DateTime.Parse("2010-03-16T05:00:00.000Z"),
                    BillingAddress = "700 W Pender Street",
                    BillingCity = "Vancouver",
                    BillingState = "BC",
                    BillingCountry = "Canada",
                    BillingPostalCode = "V6C 1G8",
                    Total = 9.91M
                },
                new Invoice
                {
                    InvoiceId = 103,
                    CustomerId = 24,
                    InvoiceDate = DateTime.Parse("2010-03-21T05:00:00.000Z"),
                    BillingAddress = "162 E Superior Street",
                    BillingCity = "Chicago",
                    BillingState = "IL",
                    BillingCountry = "USA",
                    BillingPostalCode = "60611",
                    Total = 15.86M
                },
                new Invoice
                {
                    InvoiceId = 104,
                    CustomerId = 38,
                    InvoiceDate = DateTime.Parse("2010-03-29T05:00:00.000Z"),
                    BillingAddress = "Barbarossastraße 19",
                    BillingCity = "Berlin",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "10779",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 105,
                    CustomerId = 39,
                    InvoiceDate = DateTime.Parse("2010-04-11T05:00:00.000Z"),
                    BillingAddress = "4, Rue Milton",
                    BillingCity = "Paris",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "75009",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 106,
                    CustomerId = 41,
                    InvoiceDate = DateTime.Parse("2010-04-11T05:00:00.000Z"),
                    BillingAddress = "11, Place Bellecour",
                    BillingCity = "Lyon",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "69002",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 107,
                    CustomerId = 43,
                    InvoiceDate = DateTime.Parse("2010-04-12T05:00:00.000Z"),
                    BillingAddress = "68, Rue Jouvence",
                    BillingCity = "Dijon",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "21000",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 108,
                    CustomerId = 47,
                    InvoiceDate = DateTime.Parse("2010-04-13T05:00:00.000Z"),
                    BillingAddress = "Via Degli Scipioni, 43",
                    BillingCity = "Rome",
                    BillingState = "RM",
                    BillingCountry = "Italy",
                    BillingPostalCode = "00192",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 109,
                    CustomerId = 53,
                    InvoiceDate = DateTime.Parse("2010-04-16T05:00:00.000Z"),
                    BillingAddress = "113 Lupus St",
                    BillingCity = "London",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "SW1V 3EN",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 110,
                    CustomerId = 3,
                    InvoiceDate = DateTime.Parse("2010-04-21T05:00:00.000Z"),
                    BillingAddress = "1498 rue Bélanger",
                    BillingCity = "Montréal",
                    BillingState = "QC",
                    BillingCountry = "Canada",
                    BillingPostalCode = "H2G 1A7",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 111,
                    CustomerId = 17,
                    InvoiceDate = DateTime.Parse("2010-04-29T05:00:00.000Z"),
                    BillingAddress = "1 Microsoft Way",
                    BillingCity = "Redmond",
                    BillingState = "WA",
                    BillingCountry = "USA",
                    BillingPostalCode = "98052-8300",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 112,
                    CustomerId = 18,
                    InvoiceDate = DateTime.Parse("2010-05-12T05:00:00.000Z"),
                    BillingAddress = "627 Broadway",
                    BillingCity = "New York",
                    BillingState = "NY",
                    BillingCountry = "USA",
                    BillingPostalCode = "10012-2612",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 113,
                    CustomerId = 20,
                    InvoiceDate = DateTime.Parse("2010-05-12T05:00:00.000Z"),
                    BillingAddress = "541 Del Medio Avenue",
                    BillingCity = "Mountain View",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "94040-111",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 114,
                    CustomerId = 22,
                    InvoiceDate = DateTime.Parse("2010-05-13T05:00:00.000Z"),
                    BillingAddress = "120 S Orange Ave",
                    BillingCity = "Orlando",
                    BillingState = "FL",
                    BillingCountry = "USA",
                    BillingPostalCode = "32801",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 115,
                    CustomerId = 26,
                    InvoiceDate = DateTime.Parse("2010-05-14T05:00:00.000Z"),
                    BillingAddress = "2211 W Berry Street",
                    BillingCity = "Fort Worth",
                    BillingState = "TX",
                    BillingCountry = "USA",
                    BillingPostalCode = "76110",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 116,
                    CustomerId = 32,
                    InvoiceDate = DateTime.Parse("2010-05-17T05:00:00.000Z"),
                    BillingAddress = "696 Osborne Street",
                    BillingCity = "Winnipeg",
                    BillingState = "MB",
                    BillingCountry = "Canada",
                    BillingPostalCode = "R3L 2B9",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 117,
                    CustomerId = 41,
                    InvoiceDate = DateTime.Parse("2010-05-22T05:00:00.000Z"),
                    BillingAddress = "11, Place Bellecour",
                    BillingCity = "Lyon",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "69002",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 118,
                    CustomerId = 55,
                    InvoiceDate = DateTime.Parse("2010-05-30T05:00:00.000Z"),
                    BillingAddress = "421 Bourke Street",
                    BillingCity = "Sidney",
                    BillingState = "NSW",
                    BillingCountry = "Australia",
                    BillingPostalCode = "2010",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 119,
                    CustomerId = 56,
                    InvoiceDate = DateTime.Parse("2010-06-12T05:00:00.000Z"),
                    BillingAddress = "307 Macacha Güemes",
                    BillingCity = "Buenos Aires",
                    BillingState = null,
                    BillingCountry = "Argentina",
                    BillingPostalCode = "1106",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 120,
                    CustomerId = 58,
                    InvoiceDate = DateTime.Parse("2010-06-12T05:00:00.000Z"),
                    BillingAddress = "12,Community Centre",
                    BillingCity = "Delhi",
                    BillingState = null,
                    BillingCountry = "India",
                    BillingPostalCode = "110017",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 121,
                    CustomerId = 1,
                    InvoiceDate = DateTime.Parse("2010-06-13T05:00:00.000Z"),
                    BillingAddress = "Av. Brigadeiro Faria Lima, 2170",
                    BillingCity = "São José dos Campos",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "12227-000",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 122,
                    CustomerId = 5,
                    InvoiceDate = DateTime.Parse("2010-06-14T05:00:00.000Z"),
                    BillingAddress = "Klanova 9/506",
                    BillingCity = "Prague",
                    BillingState = null,
                    BillingCountry = "Czech Republic",
                    BillingPostalCode = "14700",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 123,
                    CustomerId = 11,
                    InvoiceDate = DateTime.Parse("2010-06-17T05:00:00.000Z"),
                    BillingAddress = "Av. Paulista, 2022",
                    BillingCity = "São Paulo",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "01310-200",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 124,
                    CustomerId = 20,
                    InvoiceDate = DateTime.Parse("2010-06-22T05:00:00.000Z"),
                    BillingAddress = "541 Del Medio Avenue",
                    BillingCity = "Mountain View",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "94040-111",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 125,
                    CustomerId = 34,
                    InvoiceDate = DateTime.Parse("2010-06-30T05:00:00.000Z"),
                    BillingAddress = "Rua da Assunção 53",
                    BillingCity = "Lisbon",
                    BillingState = null,
                    BillingCountry = "Portugal",
                    BillingPostalCode = null,
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 126,
                    CustomerId = 35,
                    InvoiceDate = DateTime.Parse("2010-07-13T05:00:00.000Z"),
                    BillingAddress = "Rua dos Campeões Europeus de Viena, 4350",
                    BillingCity = "Porto",
                    BillingState = null,
                    BillingCountry = "Portugal",
                    BillingPostalCode = null,
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 127,
                    CustomerId = 37,
                    InvoiceDate = DateTime.Parse("2010-07-13T05:00:00.000Z"),
                    BillingAddress = "Berger Straße 10",
                    BillingCity = "Frankfurt",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "60316",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 128,
                    CustomerId = 39,
                    InvoiceDate = DateTime.Parse("2010-07-14T05:00:00.000Z"),
                    BillingAddress = "4, Rue Milton",
                    BillingCity = "Paris",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "75009",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 129,
                    CustomerId = 43,
                    InvoiceDate = DateTime.Parse("2010-07-15T05:00:00.000Z"),
                    BillingAddress = "68, Rue Jouvence",
                    BillingCity = "Dijon",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "21000",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 130,
                    CustomerId = 49,
                    InvoiceDate = DateTime.Parse("2010-07-18T05:00:00.000Z"),
                    BillingAddress = "Ordynacka 10",
                    BillingCity = "Warsaw",
                    BillingState = null,
                    BillingCountry = "Poland",
                    BillingPostalCode = "00-358",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 131,
                    CustomerId = 58,
                    InvoiceDate = DateTime.Parse("2010-07-23T05:00:00.000Z"),
                    BillingAddress = "12,Community Centre",
                    BillingCity = "Delhi",
                    BillingState = null,
                    BillingCountry = "India",
                    BillingPostalCode = "110017",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 132,
                    CustomerId = 13,
                    InvoiceDate = DateTime.Parse("2010-07-31T05:00:00.000Z"),
                    BillingAddress = "Qe 7 Bloco G",
                    BillingCity = "Brasília",
                    BillingState = "DF",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "71020-677",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 133,
                    CustomerId = 14,
                    InvoiceDate = DateTime.Parse("2010-08-13T05:00:00.000Z"),
                    BillingAddress = "8210 111 ST NW",
                    BillingCity = "Edmonton",
                    BillingState = "AB",
                    BillingCountry = "Canada",
                    BillingPostalCode = "T6G 2C7",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 134,
                    CustomerId = 16,
                    InvoiceDate = DateTime.Parse("2010-08-13T05:00:00.000Z"),
                    BillingAddress = "1600 Amphitheatre Parkway",
                    BillingCity = "Mountain View",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "94043-1351",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 135,
                    CustomerId = 18,
                    InvoiceDate = DateTime.Parse("2010-08-14T05:00:00.000Z"),
                    BillingAddress = "627 Broadway",
                    BillingCity = "New York",
                    BillingState = "NY",
                    BillingCountry = "USA",
                    BillingPostalCode = "10012-2612",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 136,
                    CustomerId = 22,
                    InvoiceDate = DateTime.Parse("2010-08-15T05:00:00.000Z"),
                    BillingAddress = "120 S Orange Ave",
                    BillingCity = "Orlando",
                    BillingState = "FL",
                    BillingCountry = "USA",
                    BillingPostalCode = "32801",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 137,
                    CustomerId = 28,
                    InvoiceDate = DateTime.Parse("2010-08-18T05:00:00.000Z"),
                    BillingAddress = "302 S 700 E",
                    BillingCity = "Salt Lake City",
                    BillingState = "UT",
                    BillingCountry = "USA",
                    BillingPostalCode = "84102",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 138,
                    CustomerId = 37,
                    InvoiceDate = DateTime.Parse("2010-08-23T05:00:00.000Z"),
                    BillingAddress = "Berger Straße 10",
                    BillingCity = "Frankfurt",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "60316",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 139,
                    CustomerId = 51,
                    InvoiceDate = DateTime.Parse("2010-08-31T05:00:00.000Z"),
                    BillingAddress = "Celsiusg. 9",
                    BillingCity = "Stockholm",
                    BillingState = null,
                    BillingCountry = "Sweden",
                    BillingPostalCode = "11230",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 140,
                    CustomerId = 52,
                    InvoiceDate = DateTime.Parse("2010-09-13T05:00:00.000Z"),
                    BillingAddress = "202 Hoxton Street",
                    BillingCity = "London",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "N1 5LH",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 141,
                    CustomerId = 54,
                    InvoiceDate = DateTime.Parse("2010-09-13T05:00:00.000Z"),
                    BillingAddress = "110 Raeburn Pl",
                    BillingCity = "Edinburgh ",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "EH4 1HH",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 142,
                    CustomerId = 56,
                    InvoiceDate = DateTime.Parse("2010-09-14T05:00:00.000Z"),
                    BillingAddress = "307 Macacha Güemes",
                    BillingCity = "Buenos Aires",
                    BillingState = null,
                    BillingCountry = "Argentina",
                    BillingPostalCode = "1106",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 143,
                    CustomerId = 1,
                    InvoiceDate = DateTime.Parse("2010-09-15T05:00:00.000Z"),
                    BillingAddress = "Av. Brigadeiro Faria Lima, 2170",
                    BillingCity = "São José dos Campos",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "12227-000",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 144,
                    CustomerId = 7,
                    InvoiceDate = DateTime.Parse("2010-09-18T05:00:00.000Z"),
                    BillingAddress = "Rotenturmstraße 4, 1010 Innere Stadt",
                    BillingCity = "Vienne",
                    BillingState = null,
                    BillingCountry = "Austria",
                    BillingPostalCode = "1010",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 145,
                    CustomerId = 16,
                    InvoiceDate = DateTime.Parse("2010-09-23T05:00:00.000Z"),
                    BillingAddress = "1600 Amphitheatre Parkway",
                    BillingCity = "Mountain View",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "94043-1351",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 146,
                    CustomerId = 30,
                    InvoiceDate = DateTime.Parse("2010-10-01T05:00:00.000Z"),
                    BillingAddress = "230 Elgin Street",
                    BillingCity = "Ottawa",
                    BillingState = "ON",
                    BillingCountry = "Canada",
                    BillingPostalCode = "K2P 1L7",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 147,
                    CustomerId = 31,
                    InvoiceDate = DateTime.Parse("2010-10-14T05:00:00.000Z"),
                    BillingAddress = "194A Chain Lake Drive",
                    BillingCity = "Halifax",
                    BillingState = "NS",
                    BillingCountry = "Canada",
                    BillingPostalCode = "B3S 1C5",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 148,
                    CustomerId = 33,
                    InvoiceDate = DateTime.Parse("2010-10-14T05:00:00.000Z"),
                    BillingAddress = "5112 48 Street",
                    BillingCity = "Yellowknife",
                    BillingState = "NT",
                    BillingCountry = "Canada",
                    BillingPostalCode = "X1A 1N6",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 149,
                    CustomerId = 35,
                    InvoiceDate = DateTime.Parse("2010-10-15T05:00:00.000Z"),
                    BillingAddress = "Rua dos Campeões Europeus de Viena, 4350",
                    BillingCity = "Porto",
                    BillingState = null,
                    BillingCountry = "Portugal",
                    BillingPostalCode = null,
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 150,
                    CustomerId = 39,
                    InvoiceDate = DateTime.Parse("2010-10-16T05:00:00.000Z"),
                    BillingAddress = "4, Rue Milton",
                    BillingCity = "Paris",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "75009",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 151,
                    CustomerId = 45,
                    InvoiceDate = DateTime.Parse("2010-10-19T05:00:00.000Z"),
                    BillingAddress = "Erzsébet krt. 58.",
                    BillingCity = "Budapest",
                    BillingState = null,
                    BillingCountry = "Hungary",
                    BillingPostalCode = "H-1073",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 152,
                    CustomerId = 54,
                    InvoiceDate = DateTime.Parse("2010-10-24T05:00:00.000Z"),
                    BillingAddress = "110 Raeburn Pl",
                    BillingCity = "Edinburgh ",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "EH4 1HH",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 153,
                    CustomerId = 9,
                    InvoiceDate = DateTime.Parse("2010-11-01T05:00:00.000Z"),
                    BillingAddress = "Sønder Boulevard 51",
                    BillingCity = "Copenhagen",
                    BillingState = null,
                    BillingCountry = "Denmark",
                    BillingPostalCode = "1720",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 154,
                    CustomerId = 10,
                    InvoiceDate = DateTime.Parse("2010-11-14T06:00:00.000Z"),
                    BillingAddress = "Rua Dr. Falcão Filho, 155",
                    BillingCity = "São Paulo",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "01007-010",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 155,
                    CustomerId = 12,
                    InvoiceDate = DateTime.Parse("2010-11-14T06:00:00.000Z"),
                    BillingAddress = "Praça Pio X, 119",
                    BillingCity = "Rio de Janeiro",
                    BillingState = "RJ",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "20040-020",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 156,
                    CustomerId = 14,
                    InvoiceDate = DateTime.Parse("2010-11-15T06:00:00.000Z"),
                    BillingAddress = "8210 111 ST NW",
                    BillingCity = "Edmonton",
                    BillingState = "AB",
                    BillingCountry = "Canada",
                    BillingPostalCode = "T6G 2C7",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 157,
                    CustomerId = 18,
                    InvoiceDate = DateTime.Parse("2010-11-16T06:00:00.000Z"),
                    BillingAddress = "627 Broadway",
                    BillingCity = "New York",
                    BillingState = "NY",
                    BillingCountry = "USA",
                    BillingPostalCode = "10012-2612",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 158,
                    CustomerId = 24,
                    InvoiceDate = DateTime.Parse("2010-11-19T06:00:00.000Z"),
                    BillingAddress = "162 E Superior Street",
                    BillingCity = "Chicago",
                    BillingState = "IL",
                    BillingCountry = "USA",
                    BillingPostalCode = "60611",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 159,
                    CustomerId = 33,
                    InvoiceDate = DateTime.Parse("2010-11-24T06:00:00.000Z"),
                    BillingAddress = "5112 48 Street",
                    BillingCity = "Yellowknife",
                    BillingState = "NT",
                    BillingCountry = "Canada",
                    BillingPostalCode = "X1A 1N6",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 160,
                    CustomerId = 47,
                    InvoiceDate = DateTime.Parse("2010-12-02T06:00:00.000Z"),
                    BillingAddress = "Via Degli Scipioni, 43",
                    BillingCity = "Rome",
                    BillingState = "RM",
                    BillingCountry = "Italy",
                    BillingPostalCode = "00192",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 161,
                    CustomerId = 48,
                    InvoiceDate = DateTime.Parse("2010-12-15T06:00:00.000Z"),
                    BillingAddress = "Lijnbaansgracht 120bg",
                    BillingCity = "Amsterdam",
                    BillingState = "VV",
                    BillingCountry = "Netherlands",
                    BillingPostalCode = "1016",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 162,
                    CustomerId = 50,
                    InvoiceDate = DateTime.Parse("2010-12-15T06:00:00.000Z"),
                    BillingAddress = "C/ San Bernardo 85",
                    BillingCity = "Madrid",
                    BillingState = null,
                    BillingCountry = "Spain",
                    BillingPostalCode = "28015",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 163,
                    CustomerId = 52,
                    InvoiceDate = DateTime.Parse("2010-12-16T06:00:00.000Z"),
                    BillingAddress = "202 Hoxton Street",
                    BillingCity = "London",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "N1 5LH",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 164,
                    CustomerId = 56,
                    InvoiceDate = DateTime.Parse("2010-12-17T06:00:00.000Z"),
                    BillingAddress = "307 Macacha Güemes",
                    BillingCity = "Buenos Aires",
                    BillingState = null,
                    BillingCountry = "Argentina",
                    BillingPostalCode = "1106",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 165,
                    CustomerId = 3,
                    InvoiceDate = DateTime.Parse("2010-12-20T06:00:00.000Z"),
                    BillingAddress = "1498 rue Bélanger",
                    BillingCity = "Montréal",
                    BillingState = "QC",
                    BillingCountry = "Canada",
                    BillingPostalCode = "H2G 1A7",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 166,
                    CustomerId = 12,
                    InvoiceDate = DateTime.Parse("2010-12-25T06:00:00.000Z"),
                    BillingAddress = "Praça Pio X, 119",
                    BillingCity = "Rio de Janeiro",
                    BillingState = "RJ",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "20040-020",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 167,
                    CustomerId = 26,
                    InvoiceDate = DateTime.Parse("2011-01-02T06:00:00.000Z"),
                    BillingAddress = "2211 W Berry Street",
                    BillingCity = "Fort Worth",
                    BillingState = "TX",
                    BillingCountry = "USA",
                    BillingPostalCode = "76110",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 168,
                    CustomerId = 27,
                    InvoiceDate = DateTime.Parse("2011-01-15T06:00:00.000Z"),
                    BillingAddress = "1033 N Park Ave",
                    BillingCity = "Tucson",
                    BillingState = "AZ",
                    BillingCountry = "USA",
                    BillingPostalCode = "85719",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 169,
                    CustomerId = 29,
                    InvoiceDate = DateTime.Parse("2011-01-15T06:00:00.000Z"),
                    BillingAddress = "796 Dundas Street West",
                    BillingCity = "Toronto",
                    BillingState = "ON",
                    BillingCountry = "Canada",
                    BillingPostalCode = "M6J 1V1",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 170,
                    CustomerId = 31,
                    InvoiceDate = DateTime.Parse("2011-01-16T06:00:00.000Z"),
                    BillingAddress = "194A Chain Lake Drive",
                    BillingCity = "Halifax",
                    BillingState = "NS",
                    BillingCountry = "Canada",
                    BillingPostalCode = "B3S 1C5",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 171,
                    CustomerId = 35,
                    InvoiceDate = DateTime.Parse("2011-01-17T06:00:00.000Z"),
                    BillingAddress = "Rua dos Campeões Europeus de Viena, 4350",
                    BillingCity = "Porto",
                    BillingState = null,
                    BillingCountry = "Portugal",
                    BillingPostalCode = null,
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 172,
                    CustomerId = 41,
                    InvoiceDate = DateTime.Parse("2011-01-20T06:00:00.000Z"),
                    BillingAddress = "11, Place Bellecour",
                    BillingCity = "Lyon",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "69002",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 173,
                    CustomerId = 50,
                    InvoiceDate = DateTime.Parse("2011-01-25T06:00:00.000Z"),
                    BillingAddress = "C/ San Bernardo 85",
                    BillingCity = "Madrid",
                    BillingState = null,
                    BillingCountry = "Spain",
                    BillingPostalCode = "28015",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 174,
                    CustomerId = 5,
                    InvoiceDate = DateTime.Parse("2011-02-02T06:00:00.000Z"),
                    BillingAddress = "Klanova 9/506",
                    BillingCity = "Prague",
                    BillingState = null,
                    BillingCountry = "Czech Republic",
                    BillingPostalCode = "14700",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 175,
                    CustomerId = 6,
                    InvoiceDate = DateTime.Parse("2011-02-15T06:00:00.000Z"),
                    BillingAddress = "Rilská 3174/6",
                    BillingCity = "Prague",
                    BillingState = null,
                    BillingCountry = "Czech Republic",
                    BillingPostalCode = "14300",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 176,
                    CustomerId = 8,
                    InvoiceDate = DateTime.Parse("2011-02-15T06:00:00.000Z"),
                    BillingAddress = "Grétrystraat 63",
                    BillingCity = "Brussels",
                    BillingState = null,
                    BillingCountry = "Belgium",
                    BillingPostalCode = "1000",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 177,
                    CustomerId = 10,
                    InvoiceDate = DateTime.Parse("2011-02-16T06:00:00.000Z"),
                    BillingAddress = "Rua Dr. Falcão Filho, 155",
                    BillingCity = "São Paulo",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "01007-010",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 178,
                    CustomerId = 14,
                    InvoiceDate = DateTime.Parse("2011-02-17T06:00:00.000Z"),
                    BillingAddress = "8210 111 ST NW",
                    BillingCity = "Edmonton",
                    BillingState = "AB",
                    BillingCountry = "Canada",
                    BillingPostalCode = "T6G 2C7",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 179,
                    CustomerId = 20,
                    InvoiceDate = DateTime.Parse("2011-02-20T06:00:00.000Z"),
                    BillingAddress = "541 Del Medio Avenue",
                    BillingCity = "Mountain View",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "94040-111",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 180,
                    CustomerId = 29,
                    InvoiceDate = DateTime.Parse("2011-02-25T06:00:00.000Z"),
                    BillingAddress = "796 Dundas Street West",
                    BillingCity = "Toronto",
                    BillingState = "ON",
                    BillingCountry = "Canada",
                    BillingPostalCode = "M6J 1V1",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 181,
                    CustomerId = 43,
                    InvoiceDate = DateTime.Parse("2011-03-05T06:00:00.000Z"),
                    BillingAddress = "68, Rue Jouvence",
                    BillingCity = "Dijon",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "21000",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 182,
                    CustomerId = 44,
                    InvoiceDate = DateTime.Parse("2011-03-18T05:00:00.000Z"),
                    BillingAddress = "Porthaninkatu 9",
                    BillingCity = "Helsinki",
                    BillingState = null,
                    BillingCountry = "Finland",
                    BillingPostalCode = "00530",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 183,
                    CustomerId = 46,
                    InvoiceDate = DateTime.Parse("2011-03-18T05:00:00.000Z"),
                    BillingAddress = "3 Chatham Street",
                    BillingCity = "Dublin",
                    BillingState = "Dublin",
                    BillingCountry = "Ireland",
                    BillingPostalCode = null,
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 184,
                    CustomerId = 48,
                    InvoiceDate = DateTime.Parse("2011-03-19T05:00:00.000Z"),
                    BillingAddress = "Lijnbaansgracht 120bg",
                    BillingCity = "Amsterdam",
                    BillingState = "VV",
                    BillingCountry = "Netherlands",
                    BillingPostalCode = "1016",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 185,
                    CustomerId = 52,
                    InvoiceDate = DateTime.Parse("2011-03-20T05:00:00.000Z"),
                    BillingAddress = "202 Hoxton Street",
                    BillingCity = "London",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "N1 5LH",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 186,
                    CustomerId = 58,
                    InvoiceDate = DateTime.Parse("2011-03-23T05:00:00.000Z"),
                    BillingAddress = "12,Community Centre",
                    BillingCity = "Delhi",
                    BillingState = null,
                    BillingCountry = "India",
                    BillingPostalCode = "110017",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 187,
                    CustomerId = 8,
                    InvoiceDate = DateTime.Parse("2011-03-28T05:00:00.000Z"),
                    BillingAddress = "Grétrystraat 63",
                    BillingCity = "Brussels",
                    BillingState = null,
                    BillingCountry = "Belgium",
                    BillingPostalCode = "1000",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 188,
                    CustomerId = 22,
                    InvoiceDate = DateTime.Parse("2011-04-05T05:00:00.000Z"),
                    BillingAddress = "120 S Orange Ave",
                    BillingCity = "Orlando",
                    BillingState = "FL",
                    BillingCountry = "USA",
                    BillingPostalCode = "32801",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 189,
                    CustomerId = 23,
                    InvoiceDate = DateTime.Parse("2011-04-18T05:00:00.000Z"),
                    BillingAddress = "69 Salem Street",
                    BillingCity = "Boston",
                    BillingState = "MA",
                    BillingCountry = "USA",
                    BillingPostalCode = "2113",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 190,
                    CustomerId = 25,
                    InvoiceDate = DateTime.Parse("2011-04-18T05:00:00.000Z"),
                    BillingAddress = "319 N. Frances Street",
                    BillingCity = "Madison",
                    BillingState = "WI",
                    BillingCountry = "USA",
                    BillingPostalCode = "53703",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 191,
                    CustomerId = 27,
                    InvoiceDate = DateTime.Parse("2011-04-19T05:00:00.000Z"),
                    BillingAddress = "1033 N Park Ave",
                    BillingCity = "Tucson",
                    BillingState = "AZ",
                    BillingCountry = "USA",
                    BillingPostalCode = "85719",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 192,
                    CustomerId = 31,
                    InvoiceDate = DateTime.Parse("2011-04-20T05:00:00.000Z"),
                    BillingAddress = "194A Chain Lake Drive",
                    BillingCity = "Halifax",
                    BillingState = "NS",
                    BillingCountry = "Canada",
                    BillingPostalCode = "B3S 1C5",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 193,
                    CustomerId = 37,
                    InvoiceDate = DateTime.Parse("2011-04-23T05:00:00.000Z"),
                    BillingAddress = "Berger Straße 10",
                    BillingCity = "Frankfurt",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "60316",
                    Total = 14.91M
                },
                new Invoice
                {
                    InvoiceId = 194,
                    CustomerId = 46,
                    InvoiceDate = DateTime.Parse("2011-04-28T05:00:00.000Z"),
                    BillingAddress = "3 Chatham Street",
                    BillingCity = "Dublin",
                    BillingState = "Dublin",
                    BillingCountry = "Ireland",
                    BillingPostalCode = null,
                    Total = 21.86M
                },
                new Invoice
                {
                    InvoiceId = 195,
                    CustomerId = 1,
                    InvoiceDate = DateTime.Parse("2011-05-06T05:00:00.000Z"),
                    BillingAddress = "Av. Brigadeiro Faria Lima, 2170",
                    BillingCity = "São José dos Campos",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "12227-000",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 196,
                    CustomerId = 2,
                    InvoiceDate = DateTime.Parse("2011-05-19T05:00:00.000Z"),
                    BillingAddress = "Theodor-Heuss-Straße 34",
                    BillingCity = "Stuttgart",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "70174",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 197,
                    CustomerId = 4,
                    InvoiceDate = DateTime.Parse("2011-05-19T05:00:00.000Z"),
                    BillingAddress = "Ullevålsveien 14",
                    BillingCity = "Oslo",
                    BillingState = null,
                    BillingCountry = "Norway",
                    BillingPostalCode = "0171",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 198,
                    CustomerId = 6,
                    InvoiceDate = DateTime.Parse("2011-05-20T05:00:00.000Z"),
                    BillingAddress = "Rilská 3174/6",
                    BillingCity = "Prague",
                    BillingState = null,
                    BillingCountry = "Czech Republic",
                    BillingPostalCode = "14300",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 199,
                    CustomerId = 10,
                    InvoiceDate = DateTime.Parse("2011-05-21T05:00:00.000Z"),
                    BillingAddress = "Rua Dr. Falcão Filho, 155",
                    BillingCity = "São Paulo",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "01007-010",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 200,
                    CustomerId = 16,
                    InvoiceDate = DateTime.Parse("2011-05-24T05:00:00.000Z"),
                    BillingAddress = "1600 Amphitheatre Parkway",
                    BillingCity = "Mountain View",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "94043-1351",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 201,
                    CustomerId = 25,
                    InvoiceDate = DateTime.Parse("2011-05-29T05:00:00.000Z"),
                    BillingAddress = "319 N. Frances Street",
                    BillingCity = "Madison",
                    BillingState = "WI",
                    BillingCountry = "USA",
                    BillingPostalCode = "53703",
                    Total = 18.86M
                },
                new Invoice
                {
                    InvoiceId = 202,
                    CustomerId = 39,
                    InvoiceDate = DateTime.Parse("2011-06-06T05:00:00.000Z"),
                    BillingAddress = "4, Rue Milton",
                    BillingCity = "Paris",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "75009",
                    Total = 1.99M
                },
                new Invoice
                {
                    InvoiceId = 203,
                    CustomerId = 40,
                    InvoiceDate = DateTime.Parse("2011-06-19T05:00:00.000Z"),
                    BillingAddress = "8, Rue Hanovre",
                    BillingCity = "Paris",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "75002",
                    Total = 2.98M
                },
                new Invoice
                {
                    InvoiceId = 204,
                    CustomerId = 42,
                    InvoiceDate = DateTime.Parse("2011-06-19T05:00:00.000Z"),
                    BillingAddress = "9, Place Louis Barthou",
                    BillingCity = "Bordeaux",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "33000",
                    Total = 3.98M
                },
                new Invoice
                {
                    InvoiceId = 205,
                    CustomerId = 44,
                    InvoiceDate = DateTime.Parse("2011-06-20T05:00:00.000Z"),
                    BillingAddress = "Porthaninkatu 9",
                    BillingCity = "Helsinki",
                    BillingState = null,
                    BillingCountry = "Finland",
                    BillingPostalCode = "00530",
                    Total = 7.96M
                },
                new Invoice
                {
                    InvoiceId = 206,
                    CustomerId = 48,
                    InvoiceDate = DateTime.Parse("2011-06-21T05:00:00.000Z"),
                    BillingAddress = "Lijnbaansgracht 120bg",
                    BillingCity = "Amsterdam",
                    BillingState = "VV",
                    BillingCountry = "Netherlands",
                    BillingPostalCode = "1016",
                    Total = 8.94M
                },
                new Invoice
                {
                    InvoiceId = 207,
                    CustomerId = 54,
                    InvoiceDate = DateTime.Parse("2011-06-24T05:00:00.000Z"),
                    BillingAddress = "110 Raeburn Pl",
                    BillingCity = "Edinburgh ",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "EH4 1HH",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 208,
                    CustomerId = 4,
                    InvoiceDate = DateTime.Parse("2011-06-29T05:00:00.000Z"),
                    BillingAddress = "Ullevålsveien 14",
                    BillingCity = "Oslo",
                    BillingState = null,
                    BillingCountry = "Norway",
                    BillingPostalCode = "0171",
                    Total = 15.86M
                },
                new Invoice
                {
                    InvoiceId = 209,
                    CustomerId = 18,
                    InvoiceDate = DateTime.Parse("2011-07-07T05:00:00.000Z"),
                    BillingAddress = "627 Broadway",
                    BillingCity = "New York",
                    BillingState = "NY",
                    BillingCountry = "USA",
                    BillingPostalCode = "10012-2612",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 210,
                    CustomerId = 19,
                    InvoiceDate = DateTime.Parse("2011-07-20T05:00:00.000Z"),
                    BillingAddress = "1 Infinite Loop",
                    BillingCity = "Cupertino",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "95014",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 211,
                    CustomerId = 21,
                    InvoiceDate = DateTime.Parse("2011-07-20T05:00:00.000Z"),
                    BillingAddress = "801 W 4th Street",
                    BillingCity = "Reno",
                    BillingState = "NV",
                    BillingCountry = "USA",
                    BillingPostalCode = "89503",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 212,
                    CustomerId = 23,
                    InvoiceDate = DateTime.Parse("2011-07-21T05:00:00.000Z"),
                    BillingAddress = "69 Salem Street",
                    BillingCity = "Boston",
                    BillingState = "MA",
                    BillingCountry = "USA",
                    BillingPostalCode = "2113",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 213,
                    CustomerId = 27,
                    InvoiceDate = DateTime.Parse("2011-07-22T05:00:00.000Z"),
                    BillingAddress = "1033 N Park Ave",
                    BillingCity = "Tucson",
                    BillingState = "AZ",
                    BillingCountry = "USA",
                    BillingPostalCode = "85719",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 214,
                    CustomerId = 33,
                    InvoiceDate = DateTime.Parse("2011-07-25T05:00:00.000Z"),
                    BillingAddress = "5112 48 Street",
                    BillingCity = "Yellowknife",
                    BillingState = "NT",
                    BillingCountry = "Canada",
                    BillingPostalCode = "X1A 1N6",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 215,
                    CustomerId = 42,
                    InvoiceDate = DateTime.Parse("2011-07-30T05:00:00.000Z"),
                    BillingAddress = "9, Place Louis Barthou",
                    BillingCity = "Bordeaux",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "33000",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 216,
                    CustomerId = 56,
                    InvoiceDate = DateTime.Parse("2011-08-07T05:00:00.000Z"),
                    BillingAddress = "307 Macacha Güemes",
                    BillingCity = "Buenos Aires",
                    BillingState = null,
                    BillingCountry = "Argentina",
                    BillingPostalCode = "1106",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 217,
                    CustomerId = 57,
                    InvoiceDate = DateTime.Parse("2011-08-20T05:00:00.000Z"),
                    BillingAddress = "Calle Lira, 198",
                    BillingCity = "Santiago",
                    BillingState = null,
                    BillingCountry = "Chile",
                    BillingPostalCode = null,
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 218,
                    CustomerId = 59,
                    InvoiceDate = DateTime.Parse("2011-08-20T05:00:00.000Z"),
                    BillingAddress = "3,Raj Bhavan Road",
                    BillingCity = "Bangalore",
                    BillingState = null,
                    BillingCountry = "India",
                    BillingPostalCode = "560001",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 219,
                    CustomerId = 2,
                    InvoiceDate = DateTime.Parse("2011-08-21T05:00:00.000Z"),
                    BillingAddress = "Theodor-Heuss-Straße 34",
                    BillingCity = "Stuttgart",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "70174",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 220,
                    CustomerId = 6,
                    InvoiceDate = DateTime.Parse("2011-08-22T05:00:00.000Z"),
                    BillingAddress = "Rilská 3174/6",
                    BillingCity = "Prague",
                    BillingState = null,
                    BillingCountry = "Czech Republic",
                    BillingPostalCode = "14300",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 221,
                    CustomerId = 12,
                    InvoiceDate = DateTime.Parse("2011-08-25T05:00:00.000Z"),
                    BillingAddress = "Praça Pio X, 119",
                    BillingCity = "Rio de Janeiro",
                    BillingState = "RJ",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "20040-020",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 222,
                    CustomerId = 21,
                    InvoiceDate = DateTime.Parse("2011-08-30T05:00:00.000Z"),
                    BillingAddress = "801 W 4th Street",
                    BillingCity = "Reno",
                    BillingState = "NV",
                    BillingCountry = "USA",
                    BillingPostalCode = "89503",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 223,
                    CustomerId = 35,
                    InvoiceDate = DateTime.Parse("2011-09-07T05:00:00.000Z"),
                    BillingAddress = "Rua dos Campeões Europeus de Viena, 4350",
                    BillingCity = "Porto",
                    BillingState = null,
                    BillingCountry = "Portugal",
                    BillingPostalCode = null,
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 224,
                    CustomerId = 36,
                    InvoiceDate = DateTime.Parse("2011-09-20T05:00:00.000Z"),
                    BillingAddress = "Tauentzienstraße 8",
                    BillingCity = "Berlin",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "10789",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 225,
                    CustomerId = 38,
                    InvoiceDate = DateTime.Parse("2011-09-20T05:00:00.000Z"),
                    BillingAddress = "Barbarossastraße 19",
                    BillingCity = "Berlin",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "10779",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 226,
                    CustomerId = 40,
                    InvoiceDate = DateTime.Parse("2011-09-21T05:00:00.000Z"),
                    BillingAddress = "8, Rue Hanovre",
                    BillingCity = "Paris",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "75002",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 227,
                    CustomerId = 44,
                    InvoiceDate = DateTime.Parse("2011-09-22T05:00:00.000Z"),
                    BillingAddress = "Porthaninkatu 9",
                    BillingCity = "Helsinki",
                    BillingState = null,
                    BillingCountry = "Finland",
                    BillingPostalCode = "00530",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 228,
                    CustomerId = 50,
                    InvoiceDate = DateTime.Parse("2011-09-25T05:00:00.000Z"),
                    BillingAddress = "C/ San Bernardo 85",
                    BillingCity = "Madrid",
                    BillingState = null,
                    BillingCountry = "Spain",
                    BillingPostalCode = "28015",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 229,
                    CustomerId = 59,
                    InvoiceDate = DateTime.Parse("2011-09-30T05:00:00.000Z"),
                    BillingAddress = "3,Raj Bhavan Road",
                    BillingCity = "Bangalore",
                    BillingState = null,
                    BillingCountry = "India",
                    BillingPostalCode = "560001",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 230,
                    CustomerId = 14,
                    InvoiceDate = DateTime.Parse("2011-10-08T05:00:00.000Z"),
                    BillingAddress = "8210 111 ST NW",
                    BillingCity = "Edmonton",
                    BillingState = "AB",
                    BillingCountry = "Canada",
                    BillingPostalCode = "T6G 2C7",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 231,
                    CustomerId = 15,
                    InvoiceDate = DateTime.Parse("2011-10-21T05:00:00.000Z"),
                    BillingAddress = "700 W Pender Street",
                    BillingCity = "Vancouver",
                    BillingState = "BC",
                    BillingCountry = "Canada",
                    BillingPostalCode = "V6C 1G8",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 232,
                    CustomerId = 17,
                    InvoiceDate = DateTime.Parse("2011-10-21T05:00:00.000Z"),
                    BillingAddress = "1 Microsoft Way",
                    BillingCity = "Redmond",
                    BillingState = "WA",
                    BillingCountry = "USA",
                    BillingPostalCode = "98052-8300",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 233,
                    CustomerId = 19,
                    InvoiceDate = DateTime.Parse("2011-10-22T05:00:00.000Z"),
                    BillingAddress = "1 Infinite Loop",
                    BillingCity = "Cupertino",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "95014",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 234,
                    CustomerId = 23,
                    InvoiceDate = DateTime.Parse("2011-10-23T05:00:00.000Z"),
                    BillingAddress = "69 Salem Street",
                    BillingCity = "Boston",
                    BillingState = "MA",
                    BillingCountry = "USA",
                    BillingPostalCode = "2113",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 235,
                    CustomerId = 29,
                    InvoiceDate = DateTime.Parse("2011-10-26T05:00:00.000Z"),
                    BillingAddress = "796 Dundas Street West",
                    BillingCity = "Toronto",
                    BillingState = "ON",
                    BillingCountry = "Canada",
                    BillingPostalCode = "M6J 1V1",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 236,
                    CustomerId = 38,
                    InvoiceDate = DateTime.Parse("2011-10-31T05:00:00.000Z"),
                    BillingAddress = "Barbarossastraße 19",
                    BillingCity = "Berlin",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "10779",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 237,
                    CustomerId = 52,
                    InvoiceDate = DateTime.Parse("2011-11-08T06:00:00.000Z"),
                    BillingAddress = "202 Hoxton Street",
                    BillingCity = "London",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "N1 5LH",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 238,
                    CustomerId = 53,
                    InvoiceDate = DateTime.Parse("2011-11-21T06:00:00.000Z"),
                    BillingAddress = "113 Lupus St",
                    BillingCity = "London",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "SW1V 3EN",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 239,
                    CustomerId = 55,
                    InvoiceDate = DateTime.Parse("2011-11-21T06:00:00.000Z"),
                    BillingAddress = "421 Bourke Street",
                    BillingCity = "Sidney",
                    BillingState = "NSW",
                    BillingCountry = "Australia",
                    BillingPostalCode = "2010",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 240,
                    CustomerId = 57,
                    InvoiceDate = DateTime.Parse("2011-11-22T06:00:00.000Z"),
                    BillingAddress = "Calle Lira, 198",
                    BillingCity = "Santiago",
                    BillingState = null,
                    BillingCountry = "Chile",
                    BillingPostalCode = null,
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 241,
                    CustomerId = 2,
                    InvoiceDate = DateTime.Parse("2011-11-23T06:00:00.000Z"),
                    BillingAddress = "Theodor-Heuss-Straße 34",
                    BillingCity = "Stuttgart",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "70174",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 242,
                    CustomerId = 8,
                    InvoiceDate = DateTime.Parse("2011-11-26T06:00:00.000Z"),
                    BillingAddress = "Grétrystraat 63",
                    BillingCity = "Brussels",
                    BillingState = null,
                    BillingCountry = "Belgium",
                    BillingPostalCode = "1000",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 243,
                    CustomerId = 17,
                    InvoiceDate = DateTime.Parse("2011-12-01T06:00:00.000Z"),
                    BillingAddress = "1 Microsoft Way",
                    BillingCity = "Redmond",
                    BillingState = "WA",
                    BillingCountry = "USA",
                    BillingPostalCode = "98052-8300",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 244,
                    CustomerId = 31,
                    InvoiceDate = DateTime.Parse("2011-12-09T06:00:00.000Z"),
                    BillingAddress = "194A Chain Lake Drive",
                    BillingCity = "Halifax",
                    BillingState = "NS",
                    BillingCountry = "Canada",
                    BillingPostalCode = "B3S 1C5",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 245,
                    CustomerId = 32,
                    InvoiceDate = DateTime.Parse("2011-12-22T06:00:00.000Z"),
                    BillingAddress = "696 Osborne Street",
                    BillingCity = "Winnipeg",
                    BillingState = "MB",
                    BillingCountry = "Canada",
                    BillingPostalCode = "R3L 2B9",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 246,
                    CustomerId = 34,
                    InvoiceDate = DateTime.Parse("2011-12-22T06:00:00.000Z"),
                    BillingAddress = "Rua da Assunção 53",
                    BillingCity = "Lisbon",
                    BillingState = null,
                    BillingCountry = "Portugal",
                    BillingPostalCode = null,
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 247,
                    CustomerId = 36,
                    InvoiceDate = DateTime.Parse("2011-12-23T06:00:00.000Z"),
                    BillingAddress = "Tauentzienstraße 8",
                    BillingCity = "Berlin",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "10789",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 248,
                    CustomerId = 40,
                    InvoiceDate = DateTime.Parse("2011-12-24T06:00:00.000Z"),
                    BillingAddress = "8, Rue Hanovre",
                    BillingCity = "Paris",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "75002",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 249,
                    CustomerId = 46,
                    InvoiceDate = DateTime.Parse("2011-12-27T06:00:00.000Z"),
                    BillingAddress = "3 Chatham Street",
                    BillingCity = "Dublin",
                    BillingState = "Dublin",
                    BillingCountry = "Ireland",
                    BillingPostalCode = null,
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 250,
                    CustomerId = 55,
                    InvoiceDate = DateTime.Parse("2012-01-01T06:00:00.000Z"),
                    BillingAddress = "421 Bourke Street",
                    BillingCity = "Sidney",
                    BillingState = "NSW",
                    BillingCountry = "Australia",
                    BillingPostalCode = "2010",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 251,
                    CustomerId = 10,
                    InvoiceDate = DateTime.Parse("2012-01-09T06:00:00.000Z"),
                    BillingAddress = "Rua Dr. Falcão Filho, 155",
                    BillingCity = "São Paulo",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "01007-010",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 252,
                    CustomerId = 11,
                    InvoiceDate = DateTime.Parse("2012-01-22T06:00:00.000Z"),
                    BillingAddress = "Av. Paulista, 2022",
                    BillingCity = "São Paulo",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "01310-200",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 253,
                    CustomerId = 13,
                    InvoiceDate = DateTime.Parse("2012-01-22T06:00:00.000Z"),
                    BillingAddress = "Qe 7 Bloco G",
                    BillingCity = "Brasília",
                    BillingState = "DF",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "71020-677",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 254,
                    CustomerId = 15,
                    InvoiceDate = DateTime.Parse("2012-01-23T06:00:00.000Z"),
                    BillingAddress = "700 W Pender Street",
                    BillingCity = "Vancouver",
                    BillingState = "BC",
                    BillingCountry = "Canada",
                    BillingPostalCode = "V6C 1G8",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 255,
                    CustomerId = 19,
                    InvoiceDate = DateTime.Parse("2012-01-24T06:00:00.000Z"),
                    BillingAddress = "1 Infinite Loop",
                    BillingCity = "Cupertino",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "95014",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 256,
                    CustomerId = 25,
                    InvoiceDate = DateTime.Parse("2012-01-27T06:00:00.000Z"),
                    BillingAddress = "319 N. Frances Street",
                    BillingCity = "Madison",
                    BillingState = "WI",
                    BillingCountry = "USA",
                    BillingPostalCode = "53703",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 257,
                    CustomerId = 34,
                    InvoiceDate = DateTime.Parse("2012-02-01T06:00:00.000Z"),
                    BillingAddress = "Rua da Assunção 53",
                    BillingCity = "Lisbon",
                    BillingState = null,
                    BillingCountry = "Portugal",
                    BillingPostalCode = null,
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 258,
                    CustomerId = 48,
                    InvoiceDate = DateTime.Parse("2012-02-09T06:00:00.000Z"),
                    BillingAddress = "Lijnbaansgracht 120bg",
                    BillingCity = "Amsterdam",
                    BillingState = "VV",
                    BillingCountry = "Netherlands",
                    BillingPostalCode = "1016",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 259,
                    CustomerId = 49,
                    InvoiceDate = DateTime.Parse("2012-02-22T06:00:00.000Z"),
                    BillingAddress = "Ordynacka 10",
                    BillingCity = "Warsaw",
                    BillingState = null,
                    BillingCountry = "Poland",
                    BillingPostalCode = "00-358",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 260,
                    CustomerId = 51,
                    InvoiceDate = DateTime.Parse("2012-02-22T06:00:00.000Z"),
                    BillingAddress = "Celsiusg. 9",
                    BillingCity = "Stockholm",
                    BillingState = null,
                    BillingCountry = "Sweden",
                    BillingPostalCode = "11230",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 261,
                    CustomerId = 53,
                    InvoiceDate = DateTime.Parse("2012-02-23T06:00:00.000Z"),
                    BillingAddress = "113 Lupus St",
                    BillingCity = "London",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "SW1V 3EN",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 262,
                    CustomerId = 57,
                    InvoiceDate = DateTime.Parse("2012-02-24T06:00:00.000Z"),
                    BillingAddress = "Calle Lira, 198",
                    BillingCity = "Santiago",
                    BillingState = null,
                    BillingCountry = "Chile",
                    BillingPostalCode = null,
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 263,
                    CustomerId = 4,
                    InvoiceDate = DateTime.Parse("2012-02-27T06:00:00.000Z"),
                    BillingAddress = "Ullevålsveien 14",
                    BillingCity = "Oslo",
                    BillingState = null,
                    BillingCountry = "Norway",
                    BillingPostalCode = "0171",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 264,
                    CustomerId = 13,
                    InvoiceDate = DateTime.Parse("2012-03-03T06:00:00.000Z"),
                    BillingAddress = "Qe 7 Bloco G",
                    BillingCity = "Brasília",
                    BillingState = "DF",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "71020-677",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 265,
                    CustomerId = 27,
                    InvoiceDate = DateTime.Parse("2012-03-11T06:00:00.000Z"),
                    BillingAddress = "1033 N Park Ave",
                    BillingCity = "Tucson",
                    BillingState = "AZ",
                    BillingCountry = "USA",
                    BillingPostalCode = "85719",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 266,
                    CustomerId = 28,
                    InvoiceDate = DateTime.Parse("2012-03-24T05:00:00.000Z"),
                    BillingAddress = "302 S 700 E",
                    BillingCity = "Salt Lake City",
                    BillingState = "UT",
                    BillingCountry = "USA",
                    BillingPostalCode = "84102",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 267,
                    CustomerId = 30,
                    InvoiceDate = DateTime.Parse("2012-03-24T05:00:00.000Z"),
                    BillingAddress = "230 Elgin Street",
                    BillingCity = "Ottawa",
                    BillingState = "ON",
                    BillingCountry = "Canada",
                    BillingPostalCode = "K2P 1L7",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 268,
                    CustomerId = 32,
                    InvoiceDate = DateTime.Parse("2012-03-25T05:00:00.000Z"),
                    BillingAddress = "696 Osborne Street",
                    BillingCity = "Winnipeg",
                    BillingState = "MB",
                    BillingCountry = "Canada",
                    BillingPostalCode = "R3L 2B9",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 269,
                    CustomerId = 36,
                    InvoiceDate = DateTime.Parse("2012-03-26T05:00:00.000Z"),
                    BillingAddress = "Tauentzienstraße 8",
                    BillingCity = "Berlin",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "10789",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 270,
                    CustomerId = 42,
                    InvoiceDate = DateTime.Parse("2012-03-29T05:00:00.000Z"),
                    BillingAddress = "9, Place Louis Barthou",
                    BillingCity = "Bordeaux",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "33000",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 271,
                    CustomerId = 51,
                    InvoiceDate = DateTime.Parse("2012-04-03T05:00:00.000Z"),
                    BillingAddress = "Celsiusg. 9",
                    BillingCity = "Stockholm",
                    BillingState = null,
                    BillingCountry = "Sweden",
                    BillingPostalCode = "11230",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 272,
                    CustomerId = 6,
                    InvoiceDate = DateTime.Parse("2012-04-11T05:00:00.000Z"),
                    BillingAddress = "Rilská 3174/6",
                    BillingCity = "Prague",
                    BillingState = null,
                    BillingCountry = "Czech Republic",
                    BillingPostalCode = "14300",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 273,
                    CustomerId = 7,
                    InvoiceDate = DateTime.Parse("2012-04-24T05:00:00.000Z"),
                    BillingAddress = "Rotenturmstraße 4, 1010 Innere Stadt",
                    BillingCity = "Vienne",
                    BillingState = null,
                    BillingCountry = "Austria",
                    BillingPostalCode = "1010",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 274,
                    CustomerId = 9,
                    InvoiceDate = DateTime.Parse("2012-04-24T05:00:00.000Z"),
                    BillingAddress = "Sønder Boulevard 51",
                    BillingCity = "Copenhagen",
                    BillingState = null,
                    BillingCountry = "Denmark",
                    BillingPostalCode = "1720",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 275,
                    CustomerId = 11,
                    InvoiceDate = DateTime.Parse("2012-04-25T05:00:00.000Z"),
                    BillingAddress = "Av. Paulista, 2022",
                    BillingCity = "São Paulo",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "01310-200",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 276,
                    CustomerId = 15,
                    InvoiceDate = DateTime.Parse("2012-04-26T05:00:00.000Z"),
                    BillingAddress = "700 W Pender Street",
                    BillingCity = "Vancouver",
                    BillingState = "BC",
                    BillingCountry = "Canada",
                    BillingPostalCode = "V6C 1G8",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 277,
                    CustomerId = 21,
                    InvoiceDate = DateTime.Parse("2012-04-29T05:00:00.000Z"),
                    BillingAddress = "801 W 4th Street",
                    BillingCity = "Reno",
                    BillingState = "NV",
                    BillingCountry = "USA",
                    BillingPostalCode = "89503",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 278,
                    CustomerId = 30,
                    InvoiceDate = DateTime.Parse("2012-05-04T05:00:00.000Z"),
                    BillingAddress = "230 Elgin Street",
                    BillingCity = "Ottawa",
                    BillingState = "ON",
                    BillingCountry = "Canada",
                    BillingPostalCode = "K2P 1L7",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 279,
                    CustomerId = 44,
                    InvoiceDate = DateTime.Parse("2012-05-12T05:00:00.000Z"),
                    BillingAddress = "Porthaninkatu 9",
                    BillingCity = "Helsinki",
                    BillingState = null,
                    BillingCountry = "Finland",
                    BillingPostalCode = "00530",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 280,
                    CustomerId = 45,
                    InvoiceDate = DateTime.Parse("2012-05-25T05:00:00.000Z"),
                    BillingAddress = "Erzsébet krt. 58.",
                    BillingCity = "Budapest",
                    BillingState = null,
                    BillingCountry = "Hungary",
                    BillingPostalCode = "H-1073",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 281,
                    CustomerId = 47,
                    InvoiceDate = DateTime.Parse("2012-05-25T05:00:00.000Z"),
                    BillingAddress = "Via Degli Scipioni, 43",
                    BillingCity = "Rome",
                    BillingState = "RM",
                    BillingCountry = "Italy",
                    BillingPostalCode = "00192",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 282,
                    CustomerId = 49,
                    InvoiceDate = DateTime.Parse("2012-05-26T05:00:00.000Z"),
                    BillingAddress = "Ordynacka 10",
                    BillingCity = "Warsaw",
                    BillingState = null,
                    BillingCountry = "Poland",
                    BillingPostalCode = "00-358",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 283,
                    CustomerId = 53,
                    InvoiceDate = DateTime.Parse("2012-05-27T05:00:00.000Z"),
                    BillingAddress = "113 Lupus St",
                    BillingCity = "London",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "SW1V 3EN",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 284,
                    CustomerId = 59,
                    InvoiceDate = DateTime.Parse("2012-05-30T05:00:00.000Z"),
                    BillingAddress = "3,Raj Bhavan Road",
                    BillingCity = "Bangalore",
                    BillingState = null,
                    BillingCountry = "India",
                    BillingPostalCode = "560001",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 285,
                    CustomerId = 9,
                    InvoiceDate = DateTime.Parse("2012-06-04T05:00:00.000Z"),
                    BillingAddress = "Sønder Boulevard 51",
                    BillingCity = "Copenhagen",
                    BillingState = null,
                    BillingCountry = "Denmark",
                    BillingPostalCode = "1720",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 286,
                    CustomerId = 23,
                    InvoiceDate = DateTime.Parse("2012-06-12T05:00:00.000Z"),
                    BillingAddress = "69 Salem Street",
                    BillingCity = "Boston",
                    BillingState = "MA",
                    BillingCountry = "USA",
                    BillingPostalCode = "2113",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 287,
                    CustomerId = 24,
                    InvoiceDate = DateTime.Parse("2012-06-25T05:00:00.000Z"),
                    BillingAddress = "162 E Superior Street",
                    BillingCity = "Chicago",
                    BillingState = "IL",
                    BillingCountry = "USA",
                    BillingPostalCode = "60611",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 288,
                    CustomerId = 26,
                    InvoiceDate = DateTime.Parse("2012-06-25T05:00:00.000Z"),
                    BillingAddress = "2211 W Berry Street",
                    BillingCity = "Fort Worth",
                    BillingState = "TX",
                    BillingCountry = "USA",
                    BillingPostalCode = "76110",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 289,
                    CustomerId = 28,
                    InvoiceDate = DateTime.Parse("2012-06-26T05:00:00.000Z"),
                    BillingAddress = "302 S 700 E",
                    BillingCity = "Salt Lake City",
                    BillingState = "UT",
                    BillingCountry = "USA",
                    BillingPostalCode = "84102",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 290,
                    CustomerId = 32,
                    InvoiceDate = DateTime.Parse("2012-06-27T05:00:00.000Z"),
                    BillingAddress = "696 Osborne Street",
                    BillingCity = "Winnipeg",
                    BillingState = "MB",
                    BillingCountry = "Canada",
                    BillingPostalCode = "R3L 2B9",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 291,
                    CustomerId = 38,
                    InvoiceDate = DateTime.Parse("2012-06-30T05:00:00.000Z"),
                    BillingAddress = "Barbarossastraße 19",
                    BillingCity = "Berlin",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "10779",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 292,
                    CustomerId = 47,
                    InvoiceDate = DateTime.Parse("2012-07-05T05:00:00.000Z"),
                    BillingAddress = "Via Degli Scipioni, 43",
                    BillingCity = "Rome",
                    BillingState = "RM",
                    BillingCountry = "Italy",
                    BillingPostalCode = "00192",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 293,
                    CustomerId = 2,
                    InvoiceDate = DateTime.Parse("2012-07-13T05:00:00.000Z"),
                    BillingAddress = "Theodor-Heuss-Straße 34",
                    BillingCity = "Stuttgart",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "70174",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 294,
                    CustomerId = 3,
                    InvoiceDate = DateTime.Parse("2012-07-26T05:00:00.000Z"),
                    BillingAddress = "1498 rue Bélanger",
                    BillingCity = "Montréal",
                    BillingState = "QC",
                    BillingCountry = "Canada",
                    BillingPostalCode = "H2G 1A7",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 295,
                    CustomerId = 5,
                    InvoiceDate = DateTime.Parse("2012-07-26T05:00:00.000Z"),
                    BillingAddress = "Klanova 9/506",
                    BillingCity = "Prague",
                    BillingState = null,
                    BillingCountry = "Czech Republic",
                    BillingPostalCode = "14700",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 296,
                    CustomerId = 7,
                    InvoiceDate = DateTime.Parse("2012-07-27T05:00:00.000Z"),
                    BillingAddress = "Rotenturmstraße 4, 1010 Innere Stadt",
                    BillingCity = "Vienne",
                    BillingState = null,
                    BillingCountry = "Austria",
                    BillingPostalCode = "1010",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 297,
                    CustomerId = 11,
                    InvoiceDate = DateTime.Parse("2012-07-28T05:00:00.000Z"),
                    BillingAddress = "Av. Paulista, 2022",
                    BillingCity = "São Paulo",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "01310-200",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 298,
                    CustomerId = 17,
                    InvoiceDate = DateTime.Parse("2012-07-31T05:00:00.000Z"),
                    BillingAddress = "1 Microsoft Way",
                    BillingCity = "Redmond",
                    BillingState = "WA",
                    BillingCountry = "USA",
                    BillingPostalCode = "98052-8300",
                    Total = 10.91M
                },
                new Invoice
                {
                    InvoiceId = 299,
                    CustomerId = 26,
                    InvoiceDate = DateTime.Parse("2012-08-05T05:00:00.000Z"),
                    BillingAddress = "2211 W Berry Street",
                    BillingCity = "Fort Worth",
                    BillingState = "TX",
                    BillingCountry = "USA",
                    BillingPostalCode = "76110",
                    Total = 23.86M
                },
                new Invoice
                {
                    InvoiceId = 300,
                    CustomerId = 40,
                    InvoiceDate = DateTime.Parse("2012-08-13T05:00:00.000Z"),
                    BillingAddress = "8, Rue Hanovre",
                    BillingCity = "Paris",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "75002",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 301,
                    CustomerId = 41,
                    InvoiceDate = DateTime.Parse("2012-08-26T05:00:00.000Z"),
                    BillingAddress = "11, Place Bellecour",
                    BillingCity = "Lyon",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "69002",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 302,
                    CustomerId = 43,
                    InvoiceDate = DateTime.Parse("2012-08-26T05:00:00.000Z"),
                    BillingAddress = "68, Rue Jouvence",
                    BillingCity = "Dijon",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "21000",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 303,
                    CustomerId = 45,
                    InvoiceDate = DateTime.Parse("2012-08-27T05:00:00.000Z"),
                    BillingAddress = "Erzsébet krt. 58.",
                    BillingCity = "Budapest",
                    BillingState = null,
                    BillingCountry = "Hungary",
                    BillingPostalCode = "H-1073",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 304,
                    CustomerId = 49,
                    InvoiceDate = DateTime.Parse("2012-08-28T05:00:00.000Z"),
                    BillingAddress = "Ordynacka 10",
                    BillingCity = "Warsaw",
                    BillingState = null,
                    BillingCountry = "Poland",
                    BillingPostalCode = "00-358",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 305,
                    CustomerId = 55,
                    InvoiceDate = DateTime.Parse("2012-08-31T05:00:00.000Z"),
                    BillingAddress = "421 Bourke Street",
                    BillingCity = "Sidney",
                    BillingState = "NSW",
                    BillingCountry = "Australia",
                    BillingPostalCode = "2010",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 306,
                    CustomerId = 5,
                    InvoiceDate = DateTime.Parse("2012-09-05T05:00:00.000Z"),
                    BillingAddress = "Klanova 9/506",
                    BillingCity = "Prague",
                    BillingState = null,
                    BillingCountry = "Czech Republic",
                    BillingPostalCode = "14700",
                    Total = 16.86M
                },
                new Invoice
                {
                    InvoiceId = 307,
                    CustomerId = 19,
                    InvoiceDate = DateTime.Parse("2012-09-13T05:00:00.000Z"),
                    BillingAddress = "1 Infinite Loop",
                    BillingCity = "Cupertino",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "95014",
                    Total = 1.99M
                },
                new Invoice
                {
                    InvoiceId = 308,
                    CustomerId = 20,
                    InvoiceDate = DateTime.Parse("2012-09-26T05:00:00.000Z"),
                    BillingAddress = "541 Del Medio Avenue",
                    BillingCity = "Mountain View",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "94040-111",
                    Total = 3.98M
                },
                new Invoice
                {
                    InvoiceId = 309,
                    CustomerId = 22,
                    InvoiceDate = DateTime.Parse("2012-09-26T05:00:00.000Z"),
                    BillingAddress = "120 S Orange Ave",
                    BillingCity = "Orlando",
                    BillingState = "FL",
                    BillingCountry = "USA",
                    BillingPostalCode = "32801",
                    Total = 3.98M
                },
                new Invoice
                {
                    InvoiceId = 310,
                    CustomerId = 24,
                    InvoiceDate = DateTime.Parse("2012-09-27T05:00:00.000Z"),
                    BillingAddress = "162 E Superior Street",
                    BillingCity = "Chicago",
                    BillingState = "IL",
                    BillingCountry = "USA",
                    BillingPostalCode = "60611",
                    Total = 7.96M
                },
                new Invoice
                {
                    InvoiceId = 311,
                    CustomerId = 28,
                    InvoiceDate = DateTime.Parse("2012-09-28T05:00:00.000Z"),
                    BillingAddress = "302 S 700 E",
                    BillingCity = "Salt Lake City",
                    BillingState = "UT",
                    BillingCountry = "USA",
                    BillingPostalCode = "84102",
                    Total = 11.94M
                },
                new Invoice
                {
                    InvoiceId = 312,
                    CustomerId = 34,
                    InvoiceDate = DateTime.Parse("2012-10-01T05:00:00.000Z"),
                    BillingAddress = "Rua da Assunção 53",
                    BillingCity = "Lisbon",
                    BillingState = null,
                    BillingCountry = "Portugal",
                    BillingPostalCode = null,
                    Total = 10.91M
                },
                new Invoice
                {
                    InvoiceId = 313,
                    CustomerId = 43,
                    InvoiceDate = DateTime.Parse("2012-10-06T05:00:00.000Z"),
                    BillingAddress = "68, Rue Jouvence",
                    BillingCity = "Dijon",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "21000",
                    Total = 16.86M
                },
                new Invoice
                {
                    InvoiceId = 314,
                    CustomerId = 57,
                    InvoiceDate = DateTime.Parse("2012-10-14T05:00:00.000Z"),
                    BillingAddress = "Calle Lira, 198",
                    BillingCity = "Santiago",
                    BillingState = null,
                    BillingCountry = "Chile",
                    BillingPostalCode = null,
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 315,
                    CustomerId = 58,
                    InvoiceDate = DateTime.Parse("2012-10-27T05:00:00.000Z"),
                    BillingAddress = "12,Community Centre",
                    BillingCity = "Delhi",
                    BillingState = null,
                    BillingCountry = "India",
                    BillingPostalCode = "110017",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 316,
                    CustomerId = 1,
                    InvoiceDate = DateTime.Parse("2012-10-27T05:00:00.000Z"),
                    BillingAddress = "Av. Brigadeiro Faria Lima, 2170",
                    BillingCity = "São José dos Campos",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "12227-000",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 317,
                    CustomerId = 3,
                    InvoiceDate = DateTime.Parse("2012-10-28T05:00:00.000Z"),
                    BillingAddress = "1498 rue Bélanger",
                    BillingCity = "Montréal",
                    BillingState = "QC",
                    BillingCountry = "Canada",
                    BillingPostalCode = "H2G 1A7",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 318,
                    CustomerId = 7,
                    InvoiceDate = DateTime.Parse("2012-10-29T05:00:00.000Z"),
                    BillingAddress = "Rotenturmstraße 4, 1010 Innere Stadt",
                    BillingCity = "Vienne",
                    BillingState = null,
                    BillingCountry = "Austria",
                    BillingPostalCode = "1010",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 319,
                    CustomerId = 13,
                    InvoiceDate = DateTime.Parse("2012-11-01T05:00:00.000Z"),
                    BillingAddress = "Qe 7 Bloco G",
                    BillingCity = "Brasília",
                    BillingState = "DF",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "71020-677",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 320,
                    CustomerId = 22,
                    InvoiceDate = DateTime.Parse("2012-11-06T06:00:00.000Z"),
                    BillingAddress = "120 S Orange Ave",
                    BillingCity = "Orlando",
                    BillingState = "FL",
                    BillingCountry = "USA",
                    BillingPostalCode = "32801",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 321,
                    CustomerId = 36,
                    InvoiceDate = DateTime.Parse("2012-11-14T06:00:00.000Z"),
                    BillingAddress = "Tauentzienstraße 8",
                    BillingCity = "Berlin",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "10789",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 322,
                    CustomerId = 37,
                    InvoiceDate = DateTime.Parse("2012-11-27T06:00:00.000Z"),
                    BillingAddress = "Berger Straße 10",
                    BillingCity = "Frankfurt",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "60316",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 323,
                    CustomerId = 39,
                    InvoiceDate = DateTime.Parse("2012-11-27T06:00:00.000Z"),
                    BillingAddress = "4, Rue Milton",
                    BillingCity = "Paris",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "75009",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 324,
                    CustomerId = 41,
                    InvoiceDate = DateTime.Parse("2012-11-28T06:00:00.000Z"),
                    BillingAddress = "11, Place Bellecour",
                    BillingCity = "Lyon",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "69002",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 325,
                    CustomerId = 45,
                    InvoiceDate = DateTime.Parse("2012-11-29T06:00:00.000Z"),
                    BillingAddress = "Erzsébet krt. 58.",
                    BillingCity = "Budapest",
                    BillingState = null,
                    BillingCountry = "Hungary",
                    BillingPostalCode = "H-1073",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 326,
                    CustomerId = 51,
                    InvoiceDate = DateTime.Parse("2012-12-02T06:00:00.000Z"),
                    BillingAddress = "Celsiusg. 9",
                    BillingCity = "Stockholm",
                    BillingState = null,
                    BillingCountry = "Sweden",
                    BillingPostalCode = "11230",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 327,
                    CustomerId = 1,
                    InvoiceDate = DateTime.Parse("2012-12-07T06:00:00.000Z"),
                    BillingAddress = "Av. Brigadeiro Faria Lima, 2170",
                    BillingCity = "São José dos Campos",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "12227-000",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 328,
                    CustomerId = 15,
                    InvoiceDate = DateTime.Parse("2012-12-15T06:00:00.000Z"),
                    BillingAddress = "700 W Pender Street",
                    BillingCity = "Vancouver",
                    BillingState = "BC",
                    BillingCountry = "Canada",
                    BillingPostalCode = "V6C 1G8",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 329,
                    CustomerId = 16,
                    InvoiceDate = DateTime.Parse("2012-12-28T06:00:00.000Z"),
                    BillingAddress = "1600 Amphitheatre Parkway",
                    BillingCity = "Mountain View",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "94043-1351",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 330,
                    CustomerId = 18,
                    InvoiceDate = DateTime.Parse("2012-12-28T06:00:00.000Z"),
                    BillingAddress = "627 Broadway",
                    BillingCity = "New York",
                    BillingState = "NY",
                    BillingCountry = "USA",
                    BillingPostalCode = "10012-2612",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 331,
                    CustomerId = 20,
                    InvoiceDate = DateTime.Parse("2012-12-29T06:00:00.000Z"),
                    BillingAddress = "541 Del Medio Avenue",
                    BillingCity = "Mountain View",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "94040-111",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 332,
                    CustomerId = 24,
                    InvoiceDate = DateTime.Parse("2012-12-30T06:00:00.000Z"),
                    BillingAddress = "162 E Superior Street",
                    BillingCity = "Chicago",
                    BillingState = "IL",
                    BillingCountry = "USA",
                    BillingPostalCode = "60611",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 333,
                    CustomerId = 30,
                    InvoiceDate = DateTime.Parse("2013-01-02T06:00:00.000Z"),
                    BillingAddress = "230 Elgin Street",
                    BillingCity = "Ottawa",
                    BillingState = "ON",
                    BillingCountry = "Canada",
                    BillingPostalCode = "K2P 1L7",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 334,
                    CustomerId = 39,
                    InvoiceDate = DateTime.Parse("2013-01-07T06:00:00.000Z"),
                    BillingAddress = "4, Rue Milton",
                    BillingCity = "Paris",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "75009",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 335,
                    CustomerId = 53,
                    InvoiceDate = DateTime.Parse("2013-01-15T06:00:00.000Z"),
                    BillingAddress = "113 Lupus St",
                    BillingCity = "London",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "SW1V 3EN",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 336,
                    CustomerId = 54,
                    InvoiceDate = DateTime.Parse("2013-01-28T06:00:00.000Z"),
                    BillingAddress = "110 Raeburn Pl",
                    BillingCity = "Edinburgh ",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "EH4 1HH",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 337,
                    CustomerId = 56,
                    InvoiceDate = DateTime.Parse("2013-01-28T06:00:00.000Z"),
                    BillingAddress = "307 Macacha Güemes",
                    BillingCity = "Buenos Aires",
                    BillingState = null,
                    BillingCountry = "Argentina",
                    BillingPostalCode = "1106",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 338,
                    CustomerId = 58,
                    InvoiceDate = DateTime.Parse("2013-01-29T06:00:00.000Z"),
                    BillingAddress = "12,Community Centre",
                    BillingCity = "Delhi",
                    BillingState = null,
                    BillingCountry = "India",
                    BillingPostalCode = "110017",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 339,
                    CustomerId = 3,
                    InvoiceDate = DateTime.Parse("2013-01-30T06:00:00.000Z"),
                    BillingAddress = "1498 rue Bélanger",
                    BillingCity = "Montréal",
                    BillingState = "QC",
                    BillingCountry = "Canada",
                    BillingPostalCode = "H2G 1A7",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 340,
                    CustomerId = 9,
                    InvoiceDate = DateTime.Parse("2013-02-02T06:00:00.000Z"),
                    BillingAddress = "Sønder Boulevard 51",
                    BillingCity = "Copenhagen",
                    BillingState = null,
                    BillingCountry = "Denmark",
                    BillingPostalCode = "1720",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 341,
                    CustomerId = 18,
                    InvoiceDate = DateTime.Parse("2013-02-07T06:00:00.000Z"),
                    BillingAddress = "627 Broadway",
                    BillingCity = "New York",
                    BillingState = "NY",
                    BillingCountry = "USA",
                    BillingPostalCode = "10012-2612",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 342,
                    CustomerId = 32,
                    InvoiceDate = DateTime.Parse("2013-02-15T06:00:00.000Z"),
                    BillingAddress = "696 Osborne Street",
                    BillingCity = "Winnipeg",
                    BillingState = "MB",
                    BillingCountry = "Canada",
                    BillingPostalCode = "R3L 2B9",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 343,
                    CustomerId = 33,
                    InvoiceDate = DateTime.Parse("2013-02-28T06:00:00.000Z"),
                    BillingAddress = "5112 48 Street",
                    BillingCity = "Yellowknife",
                    BillingState = "NT",
                    BillingCountry = "Canada",
                    BillingPostalCode = "X1A 1N6",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 344,
                    CustomerId = 35,
                    InvoiceDate = DateTime.Parse("2013-02-28T06:00:00.000Z"),
                    BillingAddress = "Rua dos Campeões Europeus de Viena, 4350",
                    BillingCity = "Porto",
                    BillingState = null,
                    BillingCountry = "Portugal",
                    BillingPostalCode = null,
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 345,
                    CustomerId = 37,
                    InvoiceDate = DateTime.Parse("2013-03-01T06:00:00.000Z"),
                    BillingAddress = "Berger Straße 10",
                    BillingCity = "Frankfurt",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "60316",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 346,
                    CustomerId = 41,
                    InvoiceDate = DateTime.Parse("2013-03-02T06:00:00.000Z"),
                    BillingAddress = "11, Place Bellecour",
                    BillingCity = "Lyon",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "69002",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 347,
                    CustomerId = 47,
                    InvoiceDate = DateTime.Parse("2013-03-05T06:00:00.000Z"),
                    BillingAddress = "Via Degli Scipioni, 43",
                    BillingCity = "Rome",
                    BillingState = "RM",
                    BillingCountry = "Italy",
                    BillingPostalCode = "00192",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 348,
                    CustomerId = 56,
                    InvoiceDate = DateTime.Parse("2013-03-10T06:00:00.000Z"),
                    BillingAddress = "307 Macacha Güemes",
                    BillingCity = "Buenos Aires",
                    BillingState = null,
                    BillingCountry = "Argentina",
                    BillingPostalCode = "1106",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 349,
                    CustomerId = 11,
                    InvoiceDate = DateTime.Parse("2013-03-18T05:00:00.000Z"),
                    BillingAddress = "Av. Paulista, 2022",
                    BillingCity = "São Paulo",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "01310-200",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 350,
                    CustomerId = 12,
                    InvoiceDate = DateTime.Parse("2013-03-31T05:00:00.000Z"),
                    BillingAddress = "Praça Pio X, 119",
                    BillingCity = "Rio de Janeiro",
                    BillingState = "RJ",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "20040-020",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 351,
                    CustomerId = 14,
                    InvoiceDate = DateTime.Parse("2013-03-31T05:00:00.000Z"),
                    BillingAddress = "8210 111 ST NW",
                    BillingCity = "Edmonton",
                    BillingState = "AB",
                    BillingCountry = "Canada",
                    BillingPostalCode = "T6G 2C7",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 352,
                    CustomerId = 16,
                    InvoiceDate = DateTime.Parse("2013-04-01T05:00:00.000Z"),
                    BillingAddress = "1600 Amphitheatre Parkway",
                    BillingCity = "Mountain View",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "94043-1351",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 353,
                    CustomerId = 20,
                    InvoiceDate = DateTime.Parse("2013-04-02T05:00:00.000Z"),
                    BillingAddress = "541 Del Medio Avenue",
                    BillingCity = "Mountain View",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "94040-111",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 354,
                    CustomerId = 26,
                    InvoiceDate = DateTime.Parse("2013-04-05T05:00:00.000Z"),
                    BillingAddress = "2211 W Berry Street",
                    BillingCity = "Fort Worth",
                    BillingState = "TX",
                    BillingCountry = "USA",
                    BillingPostalCode = "76110",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 355,
                    CustomerId = 35,
                    InvoiceDate = DateTime.Parse("2013-04-10T05:00:00.000Z"),
                    BillingAddress = "Rua dos Campeões Europeus de Viena, 4350",
                    BillingCity = "Porto",
                    BillingState = null,
                    BillingCountry = "Portugal",
                    BillingPostalCode = null,
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 356,
                    CustomerId = 49,
                    InvoiceDate = DateTime.Parse("2013-04-18T05:00:00.000Z"),
                    BillingAddress = "Ordynacka 10",
                    BillingCity = "Warsaw",
                    BillingState = null,
                    BillingCountry = "Poland",
                    BillingPostalCode = "00-358",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 357,
                    CustomerId = 50,
                    InvoiceDate = DateTime.Parse("2013-05-01T05:00:00.000Z"),
                    BillingAddress = "C/ San Bernardo 85",
                    BillingCity = "Madrid",
                    BillingState = null,
                    BillingCountry = "Spain",
                    BillingPostalCode = "28015",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 358,
                    CustomerId = 52,
                    InvoiceDate = DateTime.Parse("2013-05-01T05:00:00.000Z"),
                    BillingAddress = "202 Hoxton Street",
                    BillingCity = "London",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "N1 5LH",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 359,
                    CustomerId = 54,
                    InvoiceDate = DateTime.Parse("2013-05-02T05:00:00.000Z"),
                    BillingAddress = "110 Raeburn Pl",
                    BillingCity = "Edinburgh ",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "EH4 1HH",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 360,
                    CustomerId = 58,
                    InvoiceDate = DateTime.Parse("2013-05-03T05:00:00.000Z"),
                    BillingAddress = "12,Community Centre",
                    BillingCity = "Delhi",
                    BillingState = null,
                    BillingCountry = "India",
                    BillingPostalCode = "110017",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 361,
                    CustomerId = 5,
                    InvoiceDate = DateTime.Parse("2013-05-06T05:00:00.000Z"),
                    BillingAddress = "Klanova 9/506",
                    BillingCity = "Prague",
                    BillingState = null,
                    BillingCountry = "Czech Republic",
                    BillingPostalCode = "14700",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 362,
                    CustomerId = 14,
                    InvoiceDate = DateTime.Parse("2013-05-11T05:00:00.000Z"),
                    BillingAddress = "8210 111 ST NW",
                    BillingCity = "Edmonton",
                    BillingState = "AB",
                    BillingCountry = "Canada",
                    BillingPostalCode = "T6G 2C7",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 363,
                    CustomerId = 28,
                    InvoiceDate = DateTime.Parse("2013-05-19T05:00:00.000Z"),
                    BillingAddress = "302 S 700 E",
                    BillingCity = "Salt Lake City",
                    BillingState = "UT",
                    BillingCountry = "USA",
                    BillingPostalCode = "84102",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 364,
                    CustomerId = 29,
                    InvoiceDate = DateTime.Parse("2013-06-01T05:00:00.000Z"),
                    BillingAddress = "796 Dundas Street West",
                    BillingCity = "Toronto",
                    BillingState = "ON",
                    BillingCountry = "Canada",
                    BillingPostalCode = "M6J 1V1",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 365,
                    CustomerId = 31,
                    InvoiceDate = DateTime.Parse("2013-06-01T05:00:00.000Z"),
                    BillingAddress = "194A Chain Lake Drive",
                    BillingCity = "Halifax",
                    BillingState = "NS",
                    BillingCountry = "Canada",
                    BillingPostalCode = "B3S 1C5",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 366,
                    CustomerId = 33,
                    InvoiceDate = DateTime.Parse("2013-06-02T05:00:00.000Z"),
                    BillingAddress = "5112 48 Street",
                    BillingCity = "Yellowknife",
                    BillingState = "NT",
                    BillingCountry = "Canada",
                    BillingPostalCode = "X1A 1N6",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 367,
                    CustomerId = 37,
                    InvoiceDate = DateTime.Parse("2013-06-03T05:00:00.000Z"),
                    BillingAddress = "Berger Straße 10",
                    BillingCity = "Frankfurt",
                    BillingState = null,
                    BillingCountry = "Germany",
                    BillingPostalCode = "60316",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 368,
                    CustomerId = 43,
                    InvoiceDate = DateTime.Parse("2013-06-06T05:00:00.000Z"),
                    BillingAddress = "68, Rue Jouvence",
                    BillingCity = "Dijon",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "21000",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 369,
                    CustomerId = 52,
                    InvoiceDate = DateTime.Parse("2013-06-11T05:00:00.000Z"),
                    BillingAddress = "202 Hoxton Street",
                    BillingCity = "London",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "N1 5LH",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 370,
                    CustomerId = 7,
                    InvoiceDate = DateTime.Parse("2013-06-19T05:00:00.000Z"),
                    BillingAddress = "Rotenturmstraße 4, 1010 Innere Stadt",
                    BillingCity = "Vienne",
                    BillingState = null,
                    BillingCountry = "Austria",
                    BillingPostalCode = "1010",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 371,
                    CustomerId = 8,
                    InvoiceDate = DateTime.Parse("2013-07-02T05:00:00.000Z"),
                    BillingAddress = "Grétrystraat 63",
                    BillingCity = "Brussels",
                    BillingState = null,
                    BillingCountry = "Belgium",
                    BillingPostalCode = "1000",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 372,
                    CustomerId = 10,
                    InvoiceDate = DateTime.Parse("2013-07-02T05:00:00.000Z"),
                    BillingAddress = "Rua Dr. Falcão Filho, 155",
                    BillingCity = "São Paulo",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "01007-010",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 373,
                    CustomerId = 12,
                    InvoiceDate = DateTime.Parse("2013-07-03T05:00:00.000Z"),
                    BillingAddress = "Praça Pio X, 119",
                    BillingCity = "Rio de Janeiro",
                    BillingState = "RJ",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "20040-020",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 374,
                    CustomerId = 16,
                    InvoiceDate = DateTime.Parse("2013-07-04T05:00:00.000Z"),
                    BillingAddress = "1600 Amphitheatre Parkway",
                    BillingCity = "Mountain View",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "94043-1351",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 375,
                    CustomerId = 22,
                    InvoiceDate = DateTime.Parse("2013-07-07T05:00:00.000Z"),
                    BillingAddress = "120 S Orange Ave",
                    BillingCity = "Orlando",
                    BillingState = "FL",
                    BillingCountry = "USA",
                    BillingPostalCode = "32801",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 376,
                    CustomerId = 31,
                    InvoiceDate = DateTime.Parse("2013-07-12T05:00:00.000Z"),
                    BillingAddress = "194A Chain Lake Drive",
                    BillingCity = "Halifax",
                    BillingState = "NS",
                    BillingCountry = "Canada",
                    BillingPostalCode = "B3S 1C5",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 377,
                    CustomerId = 45,
                    InvoiceDate = DateTime.Parse("2013-07-20T05:00:00.000Z"),
                    BillingAddress = "Erzsébet krt. 58.",
                    BillingCity = "Budapest",
                    BillingState = null,
                    BillingCountry = "Hungary",
                    BillingPostalCode = "H-1073",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 378,
                    CustomerId = 46,
                    InvoiceDate = DateTime.Parse("2013-08-02T05:00:00.000Z"),
                    BillingAddress = "3 Chatham Street",
                    BillingCity = "Dublin",
                    BillingState = "Dublin",
                    BillingCountry = "Ireland",
                    BillingPostalCode = null,
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 379,
                    CustomerId = 48,
                    InvoiceDate = DateTime.Parse("2013-08-02T05:00:00.000Z"),
                    BillingAddress = "Lijnbaansgracht 120bg",
                    BillingCity = "Amsterdam",
                    BillingState = "VV",
                    BillingCountry = "Netherlands",
                    BillingPostalCode = "1016",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 380,
                    CustomerId = 50,
                    InvoiceDate = DateTime.Parse("2013-08-03T05:00:00.000Z"),
                    BillingAddress = "C/ San Bernardo 85",
                    BillingCity = "Madrid",
                    BillingState = null,
                    BillingCountry = "Spain",
                    BillingPostalCode = "28015",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 381,
                    CustomerId = 54,
                    InvoiceDate = DateTime.Parse("2013-08-04T05:00:00.000Z"),
                    BillingAddress = "110 Raeburn Pl",
                    BillingCity = "Edinburgh ",
                    BillingState = null,
                    BillingCountry = "United Kingdom",
                    BillingPostalCode = "EH4 1HH",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 382,
                    CustomerId = 1,
                    InvoiceDate = DateTime.Parse("2013-08-07T05:00:00.000Z"),
                    BillingAddress = "Av. Brigadeiro Faria Lima, 2170",
                    BillingCity = "São José dos Campos",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "12227-000",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 383,
                    CustomerId = 10,
                    InvoiceDate = DateTime.Parse("2013-08-12T05:00:00.000Z"),
                    BillingAddress = "Rua Dr. Falcão Filho, 155",
                    BillingCity = "São Paulo",
                    BillingState = "SP",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "01007-010",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 384,
                    CustomerId = 24,
                    InvoiceDate = DateTime.Parse("2013-08-20T05:00:00.000Z"),
                    BillingAddress = "162 E Superior Street",
                    BillingCity = "Chicago",
                    BillingState = "IL",
                    BillingCountry = "USA",
                    BillingPostalCode = "60611",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 385,
                    CustomerId = 25,
                    InvoiceDate = DateTime.Parse("2013-09-02T05:00:00.000Z"),
                    BillingAddress = "319 N. Frances Street",
                    BillingCity = "Madison",
                    BillingState = "WI",
                    BillingCountry = "USA",
                    BillingPostalCode = "53703",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 386,
                    CustomerId = 27,
                    InvoiceDate = DateTime.Parse("2013-09-02T05:00:00.000Z"),
                    BillingAddress = "1033 N Park Ave",
                    BillingCity = "Tucson",
                    BillingState = "AZ",
                    BillingCountry = "USA",
                    BillingPostalCode = "85719",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 387,
                    CustomerId = 29,
                    InvoiceDate = DateTime.Parse("2013-09-03T05:00:00.000Z"),
                    BillingAddress = "796 Dundas Street West",
                    BillingCity = "Toronto",
                    BillingState = "ON",
                    BillingCountry = "Canada",
                    BillingPostalCode = "M6J 1V1",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 388,
                    CustomerId = 33,
                    InvoiceDate = DateTime.Parse("2013-09-04T05:00:00.000Z"),
                    BillingAddress = "5112 48 Street",
                    BillingCity = "Yellowknife",
                    BillingState = "NT",
                    BillingCountry = "Canada",
                    BillingPostalCode = "X1A 1N6",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 389,
                    CustomerId = 39,
                    InvoiceDate = DateTime.Parse("2013-09-07T05:00:00.000Z"),
                    BillingAddress = "4, Rue Milton",
                    BillingCity = "Paris",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "75009",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 390,
                    CustomerId = 48,
                    InvoiceDate = DateTime.Parse("2013-09-12T05:00:00.000Z"),
                    BillingAddress = "Lijnbaansgracht 120bg",
                    BillingCity = "Amsterdam",
                    BillingState = "VV",
                    BillingCountry = "Netherlands",
                    BillingPostalCode = "1016",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 391,
                    CustomerId = 3,
                    InvoiceDate = DateTime.Parse("2013-09-20T05:00:00.000Z"),
                    BillingAddress = "1498 rue Bélanger",
                    BillingCity = "Montréal",
                    BillingState = "QC",
                    BillingCountry = "Canada",
                    BillingPostalCode = "H2G 1A7",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 392,
                    CustomerId = 4,
                    InvoiceDate = DateTime.Parse("2013-10-03T05:00:00.000Z"),
                    BillingAddress = "Ullevålsveien 14",
                    BillingCity = "Oslo",
                    BillingState = null,
                    BillingCountry = "Norway",
                    BillingPostalCode = "0171",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 393,
                    CustomerId = 6,
                    InvoiceDate = DateTime.Parse("2013-10-03T05:00:00.000Z"),
                    BillingAddress = "Rilská 3174/6",
                    BillingCity = "Prague",
                    BillingState = null,
                    BillingCountry = "Czech Republic",
                    BillingPostalCode = "14300",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 394,
                    CustomerId = 8,
                    InvoiceDate = DateTime.Parse("2013-10-04T05:00:00.000Z"),
                    BillingAddress = "Grétrystraat 63",
                    BillingCity = "Brussels",
                    BillingState = null,
                    BillingCountry = "Belgium",
                    BillingPostalCode = "1000",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 395,
                    CustomerId = 12,
                    InvoiceDate = DateTime.Parse("2013-10-05T05:00:00.000Z"),
                    BillingAddress = "Praça Pio X, 119",
                    BillingCity = "Rio de Janeiro",
                    BillingState = "RJ",
                    BillingCountry = "Brazil",
                    BillingPostalCode = "20040-020",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 396,
                    CustomerId = 18,
                    InvoiceDate = DateTime.Parse("2013-10-08T05:00:00.000Z"),
                    BillingAddress = "627 Broadway",
                    BillingCity = "New York",
                    BillingState = "NY",
                    BillingCountry = "USA",
                    BillingPostalCode = "10012-2612",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 397,
                    CustomerId = 27,
                    InvoiceDate = DateTime.Parse("2013-10-13T05:00:00.000Z"),
                    BillingAddress = "1033 N Park Ave",
                    BillingCity = "Tucson",
                    BillingState = "AZ",
                    BillingCountry = "USA",
                    BillingPostalCode = "85719",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 398,
                    CustomerId = 41,
                    InvoiceDate = DateTime.Parse("2013-10-21T05:00:00.000Z"),
                    BillingAddress = "11, Place Bellecour",
                    BillingCity = "Lyon",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "69002",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 399,
                    CustomerId = 42,
                    InvoiceDate = DateTime.Parse("2013-11-03T05:00:00.000Z"),
                    BillingAddress = "9, Place Louis Barthou",
                    BillingCity = "Bordeaux",
                    BillingState = null,
                    BillingCountry = "France",
                    BillingPostalCode = "33000",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 400,
                    CustomerId = 44,
                    InvoiceDate = DateTime.Parse("2013-11-03T05:00:00.000Z"),
                    BillingAddress = "Porthaninkatu 9",
                    BillingCity = "Helsinki",
                    BillingState = null,
                    BillingCountry = "Finland",
                    BillingPostalCode = "00530",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 401,
                    CustomerId = 46,
                    InvoiceDate = DateTime.Parse("2013-11-04T06:00:00.000Z"),
                    BillingAddress = "3 Chatham Street",
                    BillingCity = "Dublin",
                    BillingState = "Dublin",
                    BillingCountry = "Ireland",
                    BillingPostalCode = null,
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 402,
                    CustomerId = 50,
                    InvoiceDate = DateTime.Parse("2013-11-05T06:00:00.000Z"),
                    BillingAddress = "C/ San Bernardo 85",
                    BillingCity = "Madrid",
                    BillingState = null,
                    BillingCountry = "Spain",
                    BillingPostalCode = "28015",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 403,
                    CustomerId = 56,
                    InvoiceDate = DateTime.Parse("2013-11-08T06:00:00.000Z"),
                    BillingAddress = "307 Macacha Güemes",
                    BillingCity = "Buenos Aires",
                    BillingState = null,
                    BillingCountry = "Argentina",
                    BillingPostalCode = "1106",
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 404,
                    CustomerId = 6,
                    InvoiceDate = DateTime.Parse("2013-11-13T06:00:00.000Z"),
                    BillingAddress = "Rilská 3174/6",
                    BillingCity = "Prague",
                    BillingState = null,
                    BillingCountry = "Czech Republic",
                    BillingPostalCode = "14300",
                    Total = 25.86M
                },
                new Invoice
                {
                    InvoiceId = 405,
                    CustomerId = 20,
                    InvoiceDate = DateTime.Parse("2013-11-21T06:00:00.000Z"),
                    BillingAddress = "541 Del Medio Avenue",
                    BillingCity = "Mountain View",
                    BillingState = "CA",
                    BillingCountry = "USA",
                    BillingPostalCode = "94040-111",
                    Total = 0.99M
                },
                new Invoice
                {
                    InvoiceId = 406,
                    CustomerId = 21,
                    InvoiceDate = DateTime.Parse("2013-12-04T06:00:00.000Z"),
                    BillingAddress = "801 W 4th Street",
                    BillingCity = "Reno",
                    BillingState = "NV",
                    BillingCountry = "USA",
                    BillingPostalCode = "89503",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 407,
                    CustomerId = 23,
                    InvoiceDate = DateTime.Parse("2013-12-04T06:00:00.000Z"),
                    BillingAddress = "69 Salem Street",
                    BillingCity = "Boston",
                    BillingState = "MA",
                    BillingCountry = "USA",
                    BillingPostalCode = "2113",
                    Total = 1.98M
                },
                new Invoice
                {
                    InvoiceId = 408,
                    CustomerId = 25,
                    InvoiceDate = DateTime.Parse("2013-12-05T06:00:00.000Z"),
                    BillingAddress = "319 N. Frances Street",
                    BillingCity = "Madison",
                    BillingState = "WI",
                    BillingCountry = "USA",
                    BillingPostalCode = "53703",
                    Total = 3.96M
                },
                new Invoice
                {
                    InvoiceId = 409,
                    CustomerId = 29,
                    InvoiceDate = DateTime.Parse("2013-12-06T06:00:00.000Z"),
                    BillingAddress = "796 Dundas Street West",
                    BillingCity = "Toronto",
                    BillingState = "ON",
                    BillingCountry = "Canada",
                    BillingPostalCode = "M6J 1V1",
                    Total = 5.94M
                },
                new Invoice
                {
                    InvoiceId = 410,
                    CustomerId = 35,
                    InvoiceDate = DateTime.Parse("2013-12-09T06:00:00.000Z"),
                    BillingAddress = "Rua dos Campeões Europeus de Viena, 4350",
                    BillingCity = "Porto",
                    BillingState = null,
                    BillingCountry = "Portugal",
                    BillingPostalCode = null,
                    Total = 8.91M
                },
                new Invoice
                {
                    InvoiceId = 411,
                    CustomerId = 44,
                    InvoiceDate = DateTime.Parse("2013-12-14T06:00:00.000Z"),
                    BillingAddress = "Porthaninkatu 9",
                    BillingCity = "Helsinki",
                    BillingState = null,
                    BillingCountry = "Finland",
                    BillingPostalCode = "00530",
                    Total = 13.86M
                },
                new Invoice
                {
                    InvoiceId = 412,
                    CustomerId = 58,
                    InvoiceDate = DateTime.Parse("2013-12-22T06:00:00.000Z"),
                    BillingAddress = "12,Community Centre",
                    BillingCity = "Delhi",
                    BillingState = null,
                    BillingCountry = "India",
                    BillingPostalCode = "110017",
                    Total = 1.99M
                }
            );
        }
    }
}