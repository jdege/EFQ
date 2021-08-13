using Microsoft.EntityFrameworkCore.Migrations;

namespace JDege.EFQ.Web.Migrations
{
    public partial class FirstParametersJson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 5,
                columns: new[] { "ParametersJson", "Query", "StoredQueryJson" },
                values: new object[] { "[{\"Name\":\"Artist\",\"Key\":\"artistid\",\"Type\":null,\"DropdownUrl\":\"/api/Artist/GetDropdown\"}]", "EFQBuilder.Equal(\"Album.ArtistId\", \"{{context:artistid}}\")", "{\"EFQType\":\"Equal\",\"FieldName\":\"Album.ArtistId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:{{context:artistid}}\"}}" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 5,
                columns: new[] { "ParametersJson", "Query", "StoredQueryJson" },
                values: new object[] { null, "EFQBuilder.Equal(\"TrackId\", \"{{context:trackid}}\")", "{\"EFQType\":\"Equal\",\"FieldName\":\"TrackId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:{{context:trackid}}\"}}" });
        }
    }
}
