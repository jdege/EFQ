using Microsoft.EntityFrameworkCore.Migrations;

namespace EFQ.Web.Migrations
{
    public partial class AddArea3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 1,
                column: "Name",
                value: "Match on primary key");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 2,
                column: "Name",
                value: "Match on a foreign key");

            migrationBuilder.InsertData(
                table: "StoredQuery",
                columns: new[] { "StoredQueryId", "Area", "Context", "Description", "Name", "Query", "StoredQueryJson" },
                values: new object[,]
                {
                    { 6, "FieldMatch", null, "Match on a string value pass a string value", "Match on a string value", "EFQBuilder.Equal(\"Composer\", \"Miles Davis\")", "{\"EFQType\":\"Equal\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"Miles Davis\",\"AggregateList\":[]},\"AggregateList\":[]}" },
                    { 7, "FieldMatch", null, "To match ranges you can use EFQBuilder.And()", "Match a range using And()", "EFQBuilder.And(EFQBuilder.GreaterThanOrEqual(\"Composer\", \"M\"), EFQBuilder.LessThanOrEqual(\"Composer\", \"O\"))", "{\"EFQType\":\"And\",\"AggregateList\":[{\"EFQType\":\"GreaterThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"M\",\"AggregateList\":[]},\"AggregateList\":[]},{\"EFQType\":\"LessThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"O\",\"AggregateList\":[]},\"AggregateList\":[]}]}" },
                    { 8, "FieldMatch", null, "To match ranges you can use EFQBuilder.Between()", "Match a range using Between()", "EFQBuilder.Between(\"Composer\", \"M\", \"N\")", "{\"EFQType\":\"And\",\"AggregateList\":[{\"EFQType\":\"GreaterThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"M\",\"AggregateList\":[]},\"AggregateList\":[]},{\"EFQType\":\"LessThanOrEqual\",\"FieldName\":\"Composer\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"N\",\"AggregateList\":[]},\"AggregateList\":[]}]}" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 1,
                column: "Name",
                value: "Search for a single Track");

            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 2,
                column: "Name",
                value: "All Tracks for Album 1");
        }
    }
}
