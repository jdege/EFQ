using Microsoft.EntityFrameworkCore.Migrations;

namespace EFQ.Web.Migrations
{
    public partial class ParameterizedStringSearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StoredQuery",
                columns: new[] { "StoredQueryId", "Area", "BaseTable", "Description", "Name", "ParametersJson", "Query", "StoredQueryJson" },
                values: new object[] { 13, "ParameterizedValues", "Track", "To run a stored query using parameters, set the matching value to \"{{context:&lt;fieldname&gt;}}\", and pass a dictionary containing \"&lt;fieldname&gt;\".", "Search with a parameterized value", "[{\"Name\":\"Matching Value\", \"Key\":\"match\", \"Type\":\"STRING\",\"DropdownUrl\":null}]", "EFQBuilder.Or(EFQBuilder.Contains(\"Composer\", \"{{Context:match}}\"), EFQBuilder.Contains(\"Album.Title\", \"{{Context:match}}\"), EFQBuilder.Contains(\"Album.Artist.Name\", \"{{Context:match}}\"))", "{\"EFQType\":\"Or\",\"AggregateList\":[{\"EFQType\":\"Contains\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:{{Context:match}}\"}},{\"EFQType\":\"Contains\",\"FieldName\":\"Album.Title\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:{{Context:match}}\"}},{\"EFQType\":\"Contains\",\"FieldName\":\"Album.Artist.Name\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:{{Context:match}}\"}}]}" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 13);
        }
    }
}
