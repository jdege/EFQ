using Microsoft.EntityFrameworkCore.Migrations;

namespace EFQ.Web.Migrations
{
    public partial class AddArea2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 1,
                column: "Description",
                value: "EFQBuilder.Equal returns records that have fields that are equal to the matching value.<br/>If the fieldname is the primary key, only one record will be returned");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 2,
                column: "Description",
                value: "EFQBuilder.Equal returns records that have fields that are equal to the matching value.<br/>If fieldname specifies a non-unique field, multiple records will be returned");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 1,
                column: "Description",
                value: "To find a single record given the primary key, use .Equal() with the name of the primary key field and the primary value.");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 2,
                column: "Description",
                value: "To find all records that equal a specific value of a field in the parent table, use .Equal() with the field name and the value.");
        }
    }
}
