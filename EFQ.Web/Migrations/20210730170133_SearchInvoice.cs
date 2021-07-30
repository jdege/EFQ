using Microsoft.EntityFrameworkCore.Migrations;

namespace EFQ.Web.Migrations
{
    public partial class SearchInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 2,
                column: "Name",
                value: "All Tracks for Album 1");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 3,
                column: "Name",
                value: "All tracks with an Album by Artist 1");

            migrationBuilder.InsertData(
                table: "StoredQuery",
                columns: new[] { "StoredQueryId", "Description", "Name", "Query", "StoredQueryJson" },
                values: new object[] { 4, "To find all tracks for all albums with a given artist", "All tracks with an Invoice with Customer 1", "EFQBuilder.Any(\"InvoiceLines\", EFQBuilder.Equal(\"Invoice.CustomerId\", 1))", "{\"EFQType\":\"Any\",\"FieldName\":\"InvoiceLines\",\"InnerCriteria\":{\"EFQType\":\"Equal\",\"FieldName\":\"Invoice.CustomerId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantInt\":1,\"AggregateList\":[]},\"AggregateList\":[]},\"AggregateList\":[]}" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 2,
                column: "Name",
                value: "Search by Album");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 3,
                column: "Name",
                value: "Search by Artist");
        }
    }
}
