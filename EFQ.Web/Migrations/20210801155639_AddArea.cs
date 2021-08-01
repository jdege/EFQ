using Microsoft.EntityFrameworkCore.Migrations;

namespace EFQ.Web.Migrations
{
    public partial class AddArea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "StoredQuery",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 1,
                column: "Area",
                value: "FieldMatch");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 2,
                column: "Area",
                value: "FieldMatch");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 3,
                column: "Area",
                value: "NavigationProperty");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 4,
                column: "Area",
                value: "NavigationProperty");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 5,
                column: "Area",
                value: "ParamaterizedValues");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "StoredQuery");
        }
    }
}
