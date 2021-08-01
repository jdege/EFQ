using Microsoft.EntityFrameworkCore.Migrations;

namespace EFQ.Web.Migrations
{
    public partial class UpdateNavigationPropertiesText3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 3,
                column: "Description",
                value: "\n<p>If there is a one-to-one or many-to-one relationship between the base table and the child table, the Entity Framework navigation property will be a single object of the child table's entity type.\n<p>In the Chinook database, we have this kind of relationship between Track and Album. \n<p>To match a field in this kind of relationship, use tablename.fieldname. E.g., \"Album.ArtistId\".\n");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 3,
                column: "Description",
                value: "\n<p>If there is a one-to-one or many-to-one relationship between the base table and the child table, the Entity Framework navigation property will be a single object of the child table's entity type.\n<p>In the Chinook database, we have this kind of relationship between Track and Album. \n<p>To match a field in this kind of relationship, use tablename - dot - fieldname. E.g., \"Album.ArtistId\".\n");
        }
    }
}
