using Microsoft.EntityFrameworkCore.Migrations;

namespace EFQ.Web.Migrations
{
    public partial class AddContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Context",
                table: "StoredQuery",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: true);

            migrationBuilder.InsertData(
                table: "StoredQuery",
                columns: new[] { "StoredQueryId", "Context", "Description", "Name", "Query", "StoredQueryJson" },
                values: new object[] { 5, "{\"trackid\" : 2}", "To run a stored query using parameters, set the matching value to \"{{context:&lt;fieldname&gt;}}\", and pass a dictionary containing \"&lt;fieldname&gt;\".", "Search with a paramaterized value", "EFQBuilder.Equal(\"TrackId\", \"{{context:trackid}}\")", "{\"EFQType\":\"Equal\",\"FieldName\":\"TrackId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantInt\":1,\"AggregateList\":[]},\"AggregateList\":[]}" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Context",
                table: "StoredQuery");
        }
    }
}
