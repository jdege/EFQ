using Microsoft.EntityFrameworkCore.Migrations;

namespace EFQ.Web.Migrations
{
    public partial class ExtendDescriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "To find a single record given the primary key, use .Equal() with the name of the primary key field and the primary value.", "Search for a single Track" });

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 2,
                column: "Description",
                value: "To find all records that equal a specific value of a field in the parent table, use .Equal() with the field name and the value.");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 3,
                column: "Description",
                value: "To find all records that equal a specific value of a field on a child table, use .Equal() with the child table name - dot - field name and the value.");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 4,
                column: "Description",
                value: "Track has a many-to-many relationship with Invoice, through the InvoiceLines intersection table. To find all Track records that have an Invoice record for a given customer, use .Any(), with the name of the intersection table and a query that will execute on the intersection table.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "To find a given track", "Search for a Track" });

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 2,
                column: "Description",
                value: "To find all tracks for a given album");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 3,
                column: "Description",
                value: "To find all tracks for all albums with a given artist");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 4,
                column: "Description",
                value: "To find all tracks for all albums with a given artist");
        }
    }
}
