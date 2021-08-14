using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JDege.EFQ.Web.Entities
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

            builder.Property(e => e.Description)
                .HasMaxLength(int.MaxValue);

            builder.Property(e => e.StoredQueryJson)
                .IsRequired()
                .HasMaxLength(int.MaxValue);

            builder.Property(e => e.ParametersJson)
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
                    Description = "EFQBuilder.Equal returns records that have fields that are equal to the matching value.<br/>If the fieldname is the primary key, only one record will be returned",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"TrackId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"INT:1\"}}",
                    ParametersJson = null
                },
                new StoredQuery
                {
                    StoredQueryId = 2,
                    Area = StoredQuery.StoredQueryArea.FieldMatch.ToString(),
                    BaseTable = nameof(Track),
                    Name = "Match on a foreign key",
                    Query = "EFQBuilder.Equal(\"AlbumId\", 1)",
                    Description = "EFQBuilder.Equal returns records that have fields that are equal to the matching value.<br/>If fieldname specifies a non-unique field, multiple records will be returned",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"AlbumId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"INT:1\"}}",
                    ParametersJson = null
                },
                new StoredQuery
                {
                    StoredQueryId = 3,
                    BaseTable = nameof(Track),
                    Area = StoredQuery.StoredQueryArea.NavigationProperty.ToString(),
                    Name = "All tracks with an Album by Artist 1",
                    Query = "EFQBuilder.Equal(\"Album.ArtistId\", 1)",
                    Description = @"
<p>If there is a one-to-one or many-to-one relationship between the base table and the child table, the Entity Framework navigation property will be a single object of the child table's entity type.
<p>In the Chinook database, we have this kind of relationship between Track and Album. 
<p>To match a field in this kind of relationship, use tablename.fieldname. E.g., ""Album.ArtistId"".
",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"Album.ArtistId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"INT:1\"}}",
                    ParametersJson = null
                },
                new StoredQuery
                {
                    StoredQueryId = 4,
                    BaseTable = nameof(Track),
                    Area = StoredQuery.StoredQueryArea.NavigationProperty.ToString(),
                    Name = "All tracks with an Invoice with Customer 1",
                    Query = "EFQBuilder.Any(\"InvoiceLines\", EFQBuilder.Equal(\"Invoice.CustomerId\", 1))",
                    Description = @"
<p>If there is a one-to-many or many-to-many relationship between the base table and the child table, the Entity Framework navigation property will be an ICollection of the child table's entity type.
<p>In the Chinook database, we have this kind of relationship between Track and InvoiceLine. 
<p>To match a field in this kind of relationship, Use EFQBuilder.Any(), passing as a second parameter another EFQ that targets the child table.
",
                    StoredQueryJson = "{\"EFQType\":\"Any\",\"FieldName\":\"InvoiceLines\",\"InnerCriteria\":{\"EFQType\":\"Equal\",\"FieldName\":\"Invoice.CustomerId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"INT:1\"}}}",
                    ParametersJson = null
                },
                new StoredQuery
                {
                    StoredQueryId = 5,
                    BaseTable = nameof(Track),
                    Area = StoredQuery.StoredQueryArea.ParameterizedValues.ToString(),
                    Name = "Search with a parameterized value",
                    Query = "EFQBuilder.Equal(\"Album.ArtistId\", \"{{context:artistid}}\")",
                    Description = "This query is searching for all Tracks that have an album with an ArtistId that matches what the user selects.",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"Album.ArtistId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:{{context:artistid}}\"}}",
                    ParametersJson = "[{\"Name\":\"Artist\",\"Key\":\"artistid\",\"Type\":null,\"DropdownUrl\":\"/api/Artist/GetDropdown\"}]"
                },
                new StoredQuery
                {
                    StoredQueryId = 6,
                    BaseTable = nameof(Track),
                    Area = StoredQuery.StoredQueryArea.FieldMatch.ToString(),
                    Name = "Match on a string value",
                    Query = "EFQBuilder.Equal(\"Composer\", \"Miles Davis\")",
                    Description = "Match on a string value pass a string value",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:Miles Davis\"}}",
                    ParametersJson = null
                },
                new StoredQuery
                {
                    StoredQueryId = 7,
                    BaseTable = nameof(Track),
                    Area = StoredQuery.StoredQueryArea.FieldMatch.ToString(),
                    Name = "Match a range using And()",
                    Query = "EFQBuilder.And(EFQBuilder.GreaterThanOrEqual(\"Composer\", \"M\"), EFQBuilder.LessThanOrEqual(\"Composer\", \"O\"))",
                    Description = "To match ranges you can use EFQBuilder.And()",
                    StoredQueryJson = "{\"EFQType\":\"And\",\"AggregateList\":[{\"EFQType\":\"GreaterThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:M\"}},{\"EFQType\":\"LessThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:O\"}}]}",
                    ParametersJson = null
                },
                new StoredQuery
                {
                    StoredQueryId = 8,
                    BaseTable = nameof(Track),
                    Area = StoredQuery.StoredQueryArea.FieldMatch.ToString(),
                    Name = "Match a range using Between()",
                    Query = "EFQBuilder.Between(\"Composer\", \"M\", \"N\")",
                    Description = "To match ranges you can use EFQBuilder.Between()",
                    StoredQueryJson = "{\"EFQType\":\"And\",\"AggregateList\":[{\"EFQType\":\"GreaterThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:M\"}},{\"EFQType\":\"LessThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:N\"}}]}",
                    ParametersJson = null
                },
                new StoredQuery
                {
                    StoredQueryId = 9,
                    BaseTable = nameof(Invoice),
                    Area = StoredQuery.StoredQueryArea.FieldMatch.ToString(),
                    Name = "Match invoices",
                    Query = "EFQBuilder.Equal(\"BillingCountry\", \"Germany\")",
                    Description = "When we're running queries against the Invoice table, we use fields from the Invoice table",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"BillingCountry\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:Germany\"}}",
                    ParametersJson = null
                },
                new StoredQuery
                {
                    StoredQueryId = 10,
                    BaseTable = nameof(Invoice),
                    Area = StoredQuery.StoredQueryArea.FieldMatch.ToString(),
                    Name = "Match dates",
                    Query = "EFQBuilder.LessThanOrEqual(\"InvoiceDate\", DateTime.Parse(\"2009-01-31\"))",
                    Description = "When we're matching against date fields we can pass DateTime objects",
                    StoredQueryJson = "{\"EFQType\":\"LessThanOrEqual\",\"FieldName\":\"InvoiceDate\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"DT:2009-01-31T00:00:00.0000000\"}}",
                    ParametersJson = null
                },
                new StoredQuery
                {
                    StoredQueryId = 11,
                    BaseTable = nameof(Invoice),
                    Area = StoredQuery.StoredQueryArea.FieldMatch.ToString(),
                    Name = "Match last 30 days",
                    Query = "EFQBuilder.GreaterThanOrEqual(\"InvoiceDate\", EFQBuilder.Add(\"{{NOW:DATE}}\", new EFQ.Constant(TimeSpan.FromDays(-30))))",
                    Description = "To match against the last 30 days, we can use {{NOW:DATE}} to include the current datetime, and EFQ.Add() to subtract 30 days",
                    StoredQueryJson = "{\"EFQType\":\"GreaterThanOrEqual\",\"FieldName\":\"InvoiceDate\",\"RightHandSide\":{\"EFQType\":\"Add\",\"AggregateList\":[{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:{{NOW:DATE}}\"},{\"EFQType\":\"Constant\",\"ConstantValue\":\"TSP:-30.00:00:00\"}]}}",
                    ParametersJson = null
                },
                new StoredQuery
                {
                    StoredQueryId = 12,
                    BaseTable = nameof(Invoice),
                    Area = StoredQuery.StoredQueryArea.ParameterizedValues.ToString(),
                    Name = "Search with a parameterized value",
                    Query = "EFQBuilder.Between(\"InvoiceDate\", new EFQ.Constant(\"{{Context:fromdt}}\"), new EFQ.Constant(\"{{Context:todt}}\"))",
                    Description = "This query is searching for all Invoices that have an InvoiceDate between the fromdt and todt values that are entered by the user.",
                    StoredQueryJson = "{\"EFQType\":\"And\",\"AggregateList\":[{\"EFQType\":\"GreaterThanOrEqual\",\"FieldName\":\"InvoiceDate\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:{{Context:fromdt}}\"}},{\"EFQType\":\"LessThanOrEqual\",\"FieldName\":\"InvoiceDate\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:{{Context:todt}}\"}}]}",
                    ParametersJson = "[{\"Name\":\"From Date\", \"Key\":\"fromdt\", \"Type\":\"DATE\",\"DropdownUrl\":null}, {\"Name\":\"To Date\", \"Key\":\"todt\", \"Type\":\"DATE\", \"DropdownUrl\":null}]"
                },
                new StoredQuery
                {
                    StoredQueryId = 13,
                    BaseTable = nameof(Track),
                    Area = StoredQuery.StoredQueryArea.ParameterizedValues.ToString(),
                    Name = "Search with a parameterized value",
                    Query = "EFQBuilder.Or(EFQBuilder.Contains(\"Composer\", \"{{Context:match}}\"), EFQBuilder.Contains(\"Album.Title\", \"{{Context:match}}\"), EFQBuilder.Contains(\"Album.Artist.Name\", \"{{Context:match}}\"))",
                    Description = "This query searches for all Tracks that have a Composer, an Album.Title, or an Artist.Name that contain the search string provided by the user.",
                    StoredQueryJson = "{\"EFQType\":\"Or\",\"AggregateList\":[{\"EFQType\":\"Contains\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:{{Context:match}}\"}},{\"EFQType\":\"Contains\",\"FieldName\":\"Album.Title\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:{{Context:match}}\"}},{\"EFQType\":\"Contains\",\"FieldName\":\"Album.Artist.Name\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:{{Context:match}}\"}}]}",
                    ParametersJson = "[{\"Name\":\"Matching Value\", \"Key\":\"match\", \"Type\":\"STRING\",\"DropdownUrl\":null}]"
                },
                new StoredQuery
                {
                    StoredQueryId = 14,
                    BaseTable = nameof(Track),
                    Area = StoredQuery.StoredQueryArea.FieldMatch.ToString(),
                    Name = "Match Composers within...",
                    Query = "EFQBuilder.ContainedIn(\"Composer\", new[] { \"Steve Harris\", \"Miles Davis\" })",
                    Description = "This query searches for all Tracks where the Composer is within the provided array.",
                    StoredQueryJson = "{\"EFQType\":\"Or\",\"AggregateList\":[{\"EFQType\":\"Equal\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:Steve Harris\"}},{\"EFQType\":\"Equal\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:Miles Davis\"}}]}",
                    ParametersJson = null
                }
            );
        }
    }
}