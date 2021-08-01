using Microsoft.EntityFrameworkCore.Migrations;

namespace EFQ.Web.Migrations
{
    public partial class UpdateNavigationPropertiesText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 3,
                column: "Description",
                value: "\n<p>If there is a one-to-one or many-to-one relationship between the base table and the child table, the Entity Framework navigation property will be a single object of the child table's entity type.\n<p>In the Chinook database, we have this kind of relationship between Track and Album. \n<p>To match a field in this kind of relationship, use tablename - dot - fieldname. E.g., \"Album.ArtistId\".\n");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 4,
                column: "Description",
                value: "\n<p>If there is a ont-to-many or many-to-many relationship between the base table and the child table, the Entity Framework navigation property will be an ICollection of the child table's entity type.\n<p>In the Chinook database, we have this kind of relationship between Track and InvoiceLine. \n<p>To match a field in this kind of relationship, Use EFQBuilder.Any(), passing as a second parameter another EFQ that targets the child table.\n");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 10,
                column: "Name",
                value: "Match dates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                value: "Track has a many-to-many relationship with Invoice, through the InvoiceLines intersection table.\n                    <br />To find all Track records that have an Invoice record for a given customer, use .Any(), with the name of the intersection table and a query that will execute on the intersection table.");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 10,
                column: "Name",
                value: "Mathing dates");
        }
    }
}
