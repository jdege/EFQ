using Microsoft.EntityFrameworkCore.Migrations;

namespace JDege.EFQ.Web.Migrations
{
    public partial class FixTimespanSerialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 11,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"GreaterThanOrEqual\",\"FieldName\":\"InvoiceDate\",\"RightHandSide\":{\"EFQType\":\"Add\",\"AggregateList\":[{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:{{NOW:DATE}}\"},{\"EFQType\":\"Constant\",\"ConstantValue\":\"TSP:-30.00:00:00\"}]}}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 11,
                column: "StoredQueryJson",
                value: "{\"EFQType\":\"GreaterThanOrEqual\",\"FieldName\":\"InvoiceDate\",\"RightHandSide\":{\"EFQType\":\"Add\",\"AggregateList\":[{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:{{NOW:DATE}}\"},{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:JDege.EFQ.EFQ\\u002BConstant\"}]}}");
        }
    }
}
