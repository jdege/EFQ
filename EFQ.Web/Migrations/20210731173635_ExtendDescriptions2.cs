using Microsoft.EntityFrameworkCore.Migrations;

namespace EFQ.Web.Migrations
{
    public partial class ExtendDescriptions2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 4,
                column: "Description",
                value: "Track has a many-to-many relationship with Invoice, through the InvoiceLines intersection table.\n                    <br />To find all Track records that have an Invoice record for a given customer, use .Any(), with the name of the intersection table and a query that will execute on the intersection table.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 4,
                column: "Description",
                value: "Track has a many-to-many relationship with Invoice, through the InvoiceLines intersection table. To find all Track records that have an Invoice record for a given customer, use .Any(), with the name of the intersection table and a query that will execute on the intersection table.");
        }
    }
}
