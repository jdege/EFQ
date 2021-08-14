using Microsoft.EntityFrameworkCore.Migrations;

namespace JDege.EFQ.Web.Migrations
{
    public partial class ContainsInExample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StoredQuery",
                columns: new[] { "StoredQueryId", "Area", "BaseTable", "Description", "Name", "ParametersJson", "Query", "StoredQueryJson" },
                values: new object[] { 14, "FieldMatch", "Track", "This query searches for all Tracks that have a Composer, an Album.Title, or an Artist.Name that contain the search string provided by the user.", "Match Composers within...", null, "EFQBuilder.ContainedIn(\"Composer\", new[] { \"Steve Harris\", \"Miles Davis\" })", "{\"EFQType\":\"Or\",\"AggregateList\":[{\"EFQType\":\"Equal\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:Steve Harris\"}},{\"EFQType\":\"Equal\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:Miles Davis\"}}]}" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 14);
        }
    }
}
