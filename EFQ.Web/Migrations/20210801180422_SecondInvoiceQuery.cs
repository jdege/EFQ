using Microsoft.EntityFrameworkCore.Migrations;

namespace EFQ.Web.Migrations
{
    public partial class SecondInvoiceQuery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StoredQuery",
                columns: new[] { "StoredQueryId", "Area", "BaseTable", "Context", "Description", "Name", "Query", "StoredQueryJson" },
                values: new object[] { 10, "FieldMatch", "Invoice", null, "When we're matching against date fields we can pass DateTime objects", "Mathing dates", "EFQBuilder.LessThanOrEqual(\"InvoiceDate\", DateTime.Parse(\"2009-01-31\"))", "{\"EFQType\":\"LessThanOrEqual\",\"FieldName\":\"InvoiceDate\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantDateTime\":\"2009-01-31T00:00:00\",\"AggregateList\":[]},\"AggregateList\":[]}" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 10);
        }
    }
}
