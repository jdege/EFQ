using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFQ.Web.Entities
{
    internal class StoredQueryConfiguration : IEntityTypeConfiguration<StoredQuery>
    {
        public void Configure(EntityTypeBuilder<StoredQuery> builder)
        {
            builder.ToTable("StoredQuery");

            builder.Property(e => e.Area)
                .IsRequired()
                .HasMaxLength(200);

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
                    Area = StoredQuery.StoredQueryArea.FieldMatch.ToString(),
                    Name = "Match on primary key",
                    Query = "EFQBuilder.Equal(\"TrackId\", 1)",
                    Context = null,
                    Description = "EFQBuilder.Equal returns records that have fields that are equal to the matching value.<br/>If the fieldname is the primary key, only one record will be returned",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"TrackId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantInt\":1,\"AggregateList\":[]},\"AggregateList\":[]}"
                },
                new StoredQuery
                {
                    StoredQueryId = 2,
                    Area = StoredQuery.StoredQueryArea.FieldMatch.ToString(),
                    Name = "Match on a foreign key",
                    Query = "EFQBuilder.Equal(\"AlbumId\", 1)",
                    Context = null,
                    Description = "EFQBuilder.Equal returns records that have fields that are equal to the matching value.<br/>If fieldname specifies a non-unique field, multiple records will be returned",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"AlbumId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantInt\":1,\"AggregateList\":[]},\"AggregateList\":[]}"
                },
                new StoredQuery
                {
                    StoredQueryId = 3,
                    Area = StoredQuery.StoredQueryArea.NavigationProperty.ToString(),
                    Name = "All tracks with an Album by Artist 1",
                    Query = "EFQBuilder.Equal(\"Album.ArtistId\", 1)",
                    Context = null,
                    Description = @"To find all records that equal a specific value of a field on a child table, use .Equal() with the child table name - dot - field name and the value.",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"Album.ArtistId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantInt\":1,\"AggregateList\":[]},\"AggregateList\":[]}"
                },
                new StoredQuery
                {
                    StoredQueryId = 4,
                    Area = StoredQuery.StoredQueryArea.NavigationProperty.ToString(),
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
                    Area = StoredQuery.StoredQueryArea.ParamaterizedValues.ToString(),
                    Name = "Search with a paramaterized value",
                    Query = "EFQBuilder.Equal(\"TrackId\", \"{{context:trackid}}\")",
                    Context = "{\"trackid\" : 2}",
                    Description = "To run a stored query using parameters, set the matching value to \"{{context:&lt;fieldname&gt;}}\", and pass a dictionary containing \"&lt;fieldname&gt;\".",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"TrackId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"{{context:trackid}}\",\"AggregateList\":[]},\"AggregateList\":[]}"
                },
                new StoredQuery
                {
                    StoredQueryId = 6,
                    Area = StoredQuery.StoredQueryArea.FieldMatch.ToString(),
                    Name = "Match on a string value",
                    Query = "EFQBuilder.Equal(\"Composer\", \"Miles Davis\")",
                    Context = null,
                    Description = "Match on a string value pass a string value",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"Miles Davis\",\"AggregateList\":[]},\"AggregateList\":[]}"
                },
                new StoredQuery
                {
                    StoredQueryId = 7,
                    Area = StoredQuery.StoredQueryArea.FieldMatch.ToString(),
                    Name = "Match a range using And()",
                    Query = "EFQBuilder.And(EFQBuilder.GreaterThanOrEqual(\"Composer\", \"M\"), EFQBuilder.LessThanOrEqual(\"Composer\", \"O\"))",
                    Context = null,
                    Description = "To match ranges you can use EFQBuilder.And()",
                    StoredQueryJson = "{\"EFQType\":\"And\",\"AggregateList\":[{\"EFQType\":\"GreaterThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"M\",\"AggregateList\":[]},\"AggregateList\":[]},{\"EFQType\":\"LessThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"O\",\"AggregateList\":[]},\"AggregateList\":[]}]}"
                },
                new StoredQuery
                {
                    StoredQueryId = 8,
                    Area = StoredQuery.StoredQueryArea.FieldMatch.ToString(),
                    Name = "Match a range using Between()",
                    Query = "EFQBuilder.Between(\"Composer\", \"M\", \"N\")",
                    Context = null,
                    Description = "To match ranges you can use EFQBuilder.Between()",
                    StoredQueryJson = "{\"EFQType\":\"And\",\"AggregateList\":[{\"EFQType\":\"GreaterThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"M\",\"AggregateList\":[]},\"AggregateList\":[]},{\"EFQType\":\"LessThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"N\",\"AggregateList\":[]},\"AggregateList\":[]}]}"
                }
            );
        }
    }
}
