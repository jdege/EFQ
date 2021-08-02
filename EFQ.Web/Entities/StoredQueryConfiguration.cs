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

            builder.Property(e => e.BaseTable)
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
                    BaseTable = nameof(Track),
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
                    BaseTable = nameof(Track),
                    Name = "Match on a foreign key",
                    Query = "EFQBuilder.Equal(\"AlbumId\", 1)",
                    Context = null,
                    Description = "EFQBuilder.Equal returns records that have fields that are equal to the matching value.<br/>If fieldname specifies a non-unique field, multiple records will be returned",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"AlbumId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantInt\":1,\"AggregateList\":[]},\"AggregateList\":[]}"
                },
                new StoredQuery
                {
                    StoredQueryId = 3,
                    BaseTable = nameof(Track),
                    Area = StoredQuery.StoredQueryArea.NavigationProperty.ToString(),
                    Name = "All tracks with an Album by Artist 1",
                    Query = "EFQBuilder.Equal(\"Album.ArtistId\", 1)",
                    Context = null,
                    Description = @"
<p>If there is a one-to-one or many-to-one relationship between the base table and the child table, the Entity Framework navigation property will be a single object of the child table's entity type.
<p>In the Chinook database, we have this kind of relationship between Track and Album. 
<p>To match a field in this kind of relationship, use tablename.fieldname. E.g., ""Album.ArtistId"".
",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"Album.ArtistId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantInt\":1,\"AggregateList\":[]},\"AggregateList\":[]}"
                },
                new StoredQuery
                {
                    StoredQueryId = 4,
                    BaseTable = nameof(Track),
                    Area = StoredQuery.StoredQueryArea.NavigationProperty.ToString(),
                    Name = "All tracks with an Invoice with Customer 1",
                    Context = null,
                    Query = "EFQBuilder.Any(\"InvoiceLines\", EFQBuilder.Equal(\"Invoice.CustomerId\", 1))",
                    Description = @"
<p>If there is a one-to-many or many-to-many relationship between the base table and the child table, the Entity Framework navigation property will be an ICollection of the child table's entity type.
<p>In the Chinook database, we have this kind of relationship between Track and InvoiceLine. 
<p>To match a field in this kind of relationship, Use EFQBuilder.Any(), passing as a second parameter another EFQ that targets the child table.
",
                    StoredQueryJson = "{\"EFQType\":\"Any\",\"FieldName\":\"InvoiceLines\",\"InnerCriteria\":{\"EFQType\":\"Equal\",\"FieldName\":\"Invoice.CustomerId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantInt\":1,\"AggregateList\":[]},\"AggregateList\":[]},\"AggregateList\":[]}"
                },
                new StoredQuery
                {
                    StoredQueryId = 5,
                    BaseTable = nameof(Track),
                    Area = StoredQuery.StoredQueryArea.ParameterizedValues.ToString(),
                    Name = "Search with a parameterized value",
                    Query = "EFQBuilder.Equal(\"TrackId\", \"{{context:trackid}}\")",
                    Context = "{\"trackid\" : 2}",
                    Description = "To run a stored query using parameters, set the matching value to \"{{context:&lt;fieldname&gt;}}\", and pass a dictionary containing \"&lt;fieldname&gt;\".",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"TrackId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"{{context:trackid}}\",\"AggregateList\":[]},\"AggregateList\":[]}"
                },
                new StoredQuery
                {
                    StoredQueryId = 6,
                    BaseTable = nameof(Track),
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
                    BaseTable = nameof(Track),
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
                    BaseTable = nameof(Track),
                    Area = StoredQuery.StoredQueryArea.FieldMatch.ToString(),
                    Name = "Match a range using Between()",
                    Query = "EFQBuilder.Between(\"Composer\", \"M\", \"N\")",
                    Context = null,
                    Description = "To match ranges you can use EFQBuilder.Between()",
                    StoredQueryJson = "{\"EFQType\":\"And\",\"AggregateList\":[{\"EFQType\":\"GreaterThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"M\",\"AggregateList\":[]},\"AggregateList\":[]},{\"EFQType\":\"LessThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"N\",\"AggregateList\":[]},\"AggregateList\":[]}]}"
                },
                new StoredQuery
                {
                    StoredQueryId = 9,
                    BaseTable = nameof(Invoice),
                    Area = StoredQuery.StoredQueryArea.FieldMatch.ToString(),
                    Name = "Match invoices",
                    Query = "EFQBuilder.Equal(\"BillingCountry\", \"Germany\");",
                    Context = null,
                    Description = "When we're running queries against the Invoice table, we use fields from the Invoice table",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"BillingCountry\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"Germany\",\"AggregateList\":[]},\"AggregateList\":[]}"
                },
                new StoredQuery
                {
                    StoredQueryId = 10,
                    BaseTable = nameof(Invoice),
                    Area = StoredQuery.StoredQueryArea.FieldMatch.ToString(),
                    Name = "Match dates",
                    Query = "EFQBuilder.LessThanOrEqual(\"InvoiceDate\", DateTime.Parse(\"2009-01-31\"))",
                    Context = null,
                    Description = "When we're matching against date fields we can pass DateTime objects",
                    StoredQueryJson = "{\"EFQType\":\"LessThanOrEqual\",\"FieldName\":\"InvoiceDate\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantDateTime\":\"2009-01-31T00:00:00\",\"AggregateList\":[]},\"AggregateList\":[]}"
                }
            );
        }
    }
}
