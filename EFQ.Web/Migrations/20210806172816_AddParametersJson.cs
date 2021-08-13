using Microsoft.EntityFrameworkCore.Migrations;

namespace JDege.EFQ.Web.Migrations
{
    public partial class AddParametersJson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Context",
                table: "StoredQuery",
                newName: "ParametersJson");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 5,
                column: "ParametersJson",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParametersJson",
                table: "StoredQuery",
                newName: "Context");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 5,
                column: "Context",
                value: "{\"trackid\" : {\"Constant\":\"int:2\"}}");
        }
    }
}
