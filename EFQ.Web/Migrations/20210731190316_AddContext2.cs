using Microsoft.EntityFrameworkCore.Migrations;

namespace EFQ.Web.Migrations
{
    public partial class AddContext2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 5,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"Equal\",\"FieldName\":\"TrackId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"{{context:trackid}}\",\"AggregateList\":[]},\"AggregateList\":[]}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 5,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"Equal\",\"FieldName\":\"TrackId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantInt\":1,\"AggregateList\":[]},\"AggregateList\":[]}");
        }
    }
}
