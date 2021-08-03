using Microsoft.EntityFrameworkCore.Migrations;

namespace EFQ.Web.Migrations
{
    public partial class UpdateStoredQueries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 1,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"Equal\",\"FieldName\":\"TrackId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"INT:1\"}}");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 2,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"Equal\",\"FieldName\":\"AlbumId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"INT:1\"}}");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 3,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"Equal\",\"FieldName\":\"Album.ArtistId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"INT:1\"}}");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 4,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"Any\",\"FieldName\":\"InvoiceLines\",\"InnerCriteria\":{\"EFQType\":\"Equal\",\"FieldName\":\"Invoice.CustomerId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"INT:1\"}}}");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 5,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"Equal\",\"FieldName\":\"TrackId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:{{context:trackid}}\"}}");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 6,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"Equal\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:Miles Davis\"}}");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 7,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"And\",\"AggregateList\":[{\"EFQType\":\"GreaterThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:M\"}},{\"EFQType\":\"LessThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:O\"}}]}");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 8,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"And\",\"AggregateList\":[{\"EFQType\":\"GreaterThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:M\"}},{\"EFQType\":\"LessThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:N\"}}]}");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 9,
                columns: new[] { "Query", "StoredQueryJson" },
                values: new object[] { "EFQBuilder.Equal(\"BillingCountry\", \"Germany\")", "{\"EFQType\":\"Equal\",\"FieldName\":\"BillingCountry\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:Germany\"}}" });

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 10,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"LessThanOrEqual\",\"FieldName\":\"InvoiceDate\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"DT:2009-01-31T00:00:00.0000000\"}}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 1,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"Equal\",\"FieldName\":\"TrackId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantInt\":1,\"AggregateList\":[]},\"AggregateList\":[]}");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 2,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"Equal\",\"FieldName\":\"AlbumId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantInt\":1,\"AggregateList\":[]},\"AggregateList\":[]}");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 3,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"Equal\",\"FieldName\":\"Album.ArtistId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantInt\":1,\"AggregateList\":[]},\"AggregateList\":[]}");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 4,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"Any\",\"FieldName\":\"InvoiceLines\",\"InnerCriteria\":{\"EFQType\":\"Equal\",\"FieldName\":\"Invoice.CustomerId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantInt\":1,\"AggregateList\":[]},\"AggregateList\":[]},\"AggregateList\":[]}");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 5,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"Equal\",\"FieldName\":\"TrackId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"{{context:trackid}}\",\"AggregateList\":[]},\"AggregateList\":[]}");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 6,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"Equal\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"Miles Davis\",\"AggregateList\":[]},\"AggregateList\":[]}");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 7,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"And\",\"AggregateList\":[{\"EFQType\":\"GreaterThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"M\",\"AggregateList\":[]},\"AggregateList\":[]},{\"EFQType\":\"LessThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"O\",\"AggregateList\":[]},\"AggregateList\":[]}]}");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 8,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"And\",\"AggregateList\":[{\"EFQType\":\"GreaterThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"M\",\"AggregateList\":[]},\"AggregateList\":[]},{\"EFQType\":\"LessThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"N\",\"AggregateList\":[]},\"AggregateList\":[]}]}");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 9,
                columns: new[] { "Query", "StoredQueryJson" },
                values: new object[] { "EFQBuilder.Equal(\"BillingCountry\", \"Germany\");", "{\"EFQType\":\"Equal\",\"FieldName\":\"BillingCountry\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"Germany\",\"AggregateList\":[]},\"AggregateList\":[]}" });

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 10,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"LessThanOrEqual\",\"FieldName\":\"InvoiceDate\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantDateTime\":\"2009-01-31T00:00:00\",\"AggregateList\":[]},\"AggregateList\":[]}");
        }
    }
}
