using Microsoft.EntityFrameworkCore.Migrations;

namespace JDege.EFQ.Web.Migrations
{
    public partial class ContainsInExample2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 14,
                column: "Description",
                value: "This query searches for all Tracks where the Composer is within the provided array.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 14,
                column: "Description",
                value: "This query searches for all Tracks that have a Composer, an Album.Title, or an Artist.Name that contain the search string provided by the user.");
        }
    }
}
