using Microsoft.EntityFrameworkCore.Migrations;

namespace EFQ.Web.Migrations
{
    public partial class UpdateNavigationPropertiesText2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 4,
                column: "Description",
                value: "\n<p>If there is a one-to-many or many-to-many relationship between the base table and the child table, the Entity Framework navigation property will be an ICollection of the child table's entity type.\n<p>In the Chinook database, we have this kind of relationship between Track and InvoiceLine. \n<p>To match a field in this kind of relationship, Use EFQBuilder.Any(), passing as a second parameter another EFQ that targets the child table.\n");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 4,
                column: "Description",
                value: "\n<p>If there is a ont-to-many or many-to-many relationship between the base table and the child table, the Entity Framework navigation property will be an ICollection of the child table's entity type.\n<p>In the Chinook database, we have this kind of relationship between Track and InvoiceLine. \n<p>To match a field in this kind of relationship, Use EFQBuilder.Any(), passing as a second parameter another EFQ that targets the child table.\n");
        }
    }
}
