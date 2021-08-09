using Microsoft.EntityFrameworkCore.Migrations;

namespace EFQ.Web.Migrations
{
    public partial class AddMatchLast30Days : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StoredQuery",
                columns: new[] { "StoredQueryId", "Area", "BaseTable", "Description", "Name", "ParametersJson", "Query", "StoredQueryJson" },
                values: new object[] { 11, "FieldMatch", "Invoice", "To match against the last 30 days, we can use {{NOW:DATE}} to include the current datetime, and EFQ.Add() to subtract 30 days", "Match last 30 days", null, "EFQBuilder.GreaterThanOrEqual(\"InvoiceDate\", EFQBuilder.Add(\"{{NOW:DATE}}\", new EFQ.Constant(TimeSpan.FromDays(-30))))", "{\"EFQType\":\"GreaterThanOrEqual\",\"FieldName\":\"InvoiceDate\",\"RightHandSide\":{\"EFQType\":\"Add\",\"AggregateList\":[{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:{{NOW:DATE}}\"},{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:JDege.EFQ.EFQ\\u002BConstant\"}]}}" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 11);
        }
    }
}
