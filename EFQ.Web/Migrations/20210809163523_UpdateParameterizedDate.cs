using Microsoft.EntityFrameworkCore.Migrations;

namespace EFQ.Web.Migrations
{
    public partial class UpdateParameterizedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 12,
                columns: new[] { "Query", "StoredQueryJson" },
                values: new object[] { "EFQBuilder.Between(\"InvoiceDate\", new EFQ.Constant(\"{{Context:fromdt}}\"), new EFQ.Constant(\"{{Context:todt}}\"))", "{\"EFQType\":\"And\",\"AggregateList\":[{\"EFQType\":\"GreaterThanOrEqual\",\"FieldName\":\"InvoiceDate\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:{{Context:fromdt}}\"}},{\"EFQType\":\"LessThanOrEqual\",\"FieldName\":\"InvoiceDate\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantValue\":\"STR:{{Context:todt}}\"}}]}" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 12,
                columns: new[] { "Query", "StoredQueryJson" },
                values: new object[] { "EFQBuilder.Equal(\"Album.ArtistId\", \"{{context:artistid}}\")", "{\"EFQType\":\"And\", \"AggregateList\":[{\"EFQType\":\"GreaterThanOrEqual\", \"FieldName\":\"InvoiceDate\", \"RightHandSide\":{\"EFQType\":\"Constant\", \"ConstantValue\":\"{{context:fromdt}}\"}}, {\"EFQType\":\"LessThanOrEqual\", \"FieldName\":\"Composer\", \"RightHandSide\":{\"EFQType\":\"Constant\", \"ConstantValue\":\"{{context:todt}}\"}}]}" });
        }
    }
}
