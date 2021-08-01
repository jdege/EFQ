using Microsoft.EntityFrameworkCore.Migrations;

namespace EFQ.Web.Migrations
{
    public partial class FirstInvoiceQuery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StoredQuery",
                columns: new[] { "StoredQueryId", "Area", "BaseTable", "Context", "Description", "Name", "Query", "StoredQueryJson" },
                values: new object[] { 9, "FieldMatch", "Invoice", null, "When we're running queries against the Invoice table, we use fields from the Invoice table", "Match invoices", "EFQBuilder.Equal(\"BillingCountry\", \"Germany\");", "{\"EFQType\":\"Equal\",\"FieldName\":\"BillingCountry\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantString\":\"Germany\",\"AggregateList\":[]},\"AggregateList\":[]}" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 9);
        }
    }
}
