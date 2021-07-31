using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFQ.Web.Entities
{
    internal class StoredQueryConfiguration : IEntityTypeConfiguration<StoredQuery>
    {
        public void Configure(EntityTypeBuilder<StoredQuery> builder)
        {
            builder.ToTable("StoredQuery");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Query)
                .HasMaxLength(int.MaxValue);

            builder.Property(e => e.Context)
                .HasMaxLength(int.MaxValue);

            builder.Property(e => e.Description)
                .HasMaxLength(int.MaxValue);

            builder.Property(e => e.StoredQueryJson)
                .IsRequired()
                .HasMaxLength(int.MaxValue);

            seedData(builder);
        }

        private void seedData(EntityTypeBuilder<StoredQuery> builder)
        {
            builder.HasData(
                new StoredQuery
                {
                    StoredQueryId = 1,
                    Name = "Search for a single Track",
                    Query = "EFQBuilder.Equal(\"TrackId\", 1)",
                    Context = null,
                    Description = @"To find a single record given the primary key, use .Equal() with the name of the primary key field and the primary value.",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"TrackId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantInt\":1,\"AggregateList\":[]},\"AggregateList\":[]}"
                },
                new StoredQuery
                {
                    StoredQueryId = 2,
                    Name = "All Tracks for Album 1",
                    Query = "EFQBuilder.Equal(\"AlbumId\", 1)",
                    Context = null,
                    Description = @"To find all records that equal a specific value of a field in the parent table, use .Equal() with the field name and the value.",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"AlbumId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantInt\":1,\"AggregateList\":[]},\"AggregateList\":[]}"
                },
                new StoredQuery
                {
                    StoredQueryId = 3,
                    Name = "All tracks with an Album by Artist 1",
                    Query = "EFQBuilder.Equal(\"Album.ArtistId\", 1)",
                    Context = null,
                    Description = @"To find all records that equal a specific value of a field on a child table, use .Equal() with the child table name - dot - field name and the value.",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"Album.ArtistId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantInt\":1,\"AggregateList\":[]},\"AggregateList\":[]}"
                },
                new StoredQuery
                {
                    StoredQueryId = 4,
                    Name = "All tracks with an Invoice with Customer 1",
                    Context = null,
                    Query = "EFQBuilder.Any(\"InvoiceLines\", EFQBuilder.Equal(\"Invoice.CustomerId\", 1))",
                    Description = @"Track has a many-to-many relationship with Invoice, through the InvoiceLines intersection table.
                    <br />To find all Track records that have an Invoice record for a given customer, use .Any(), with the name of the intersection table and a query that will execute on the intersection table.",
                    StoredQueryJson = "{\"EFQType\":\"Any\",\"FieldName\":\"InvoiceLines\",\"InnerCriteria\":{\"EFQType\":\"Equal\",\"FieldName\":\"Invoice.CustomerId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantInt\":1,\"AggregateList\":[]},\"AggregateList\":[]},\"AggregateList\":[]}"
                },
                new StoredQuery
                {
                    StoredQueryId = 5,
                    Name = "Search with a paramaterized value",
                    Query = "EFQBuilder.Equal(\"TrackId\", \"{{context:trackid}}\")",
                    Context = "{\"trackid\" : 2}",
                    Description = "To run a stored query using parameters, set the matching value to \"{{context:&lt;fieldname&gt;}}\", and pass a dictionary containing \"&lt;fieldname&gt;\".",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"TrackId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"{{context:trackid}}\",\"AggregateList\":[]},\"AggregateList\":[]}"
                }
            );
        }
    }
}
