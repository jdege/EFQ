using Microsoft.EntityFrameworkCore.Migrations;

namespace EFQ.Web.Migrations
{
    public partial class AddParameterizedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StoredQuery",
                columns: new[] { "StoredQueryId", "Area", "BaseTable", "Description", "Name", "ParametersJson", "Query", "StoredQueryJson" },
                values: new object[] { 12, "ParameterizedValues", "Invoice", "To run a stored query using parameters, set the matching value to \"{{context:&lt;fieldname&gt;}}\", and pass a dictionary containing \"&lt;fieldname&gt;\".", "Search with a parameterized value", "[{\"Name\":\"From Date\", \"Key\":\"fromdt\", \"Type\":\"DATE\",\"DropdownUrl\":null}, {\"Name\":\"To Date\", \"Key\":\"todt\", \"Type\":\"DATE\", \"DropdownUrl\":null}]", "EFQBuilder.Equal(\"Album.ArtistId\", \"{{context:artistid}}\")", "{\"EFQType\":\"And\", \"AggregateList\":[{\"EFQType\":\"GreaterThanOrEqual\", \"FieldName\":\"InvoiceDate\", \"RightHandSide\":{\"EFQType\":\"Constant\", \"ConstantValue\":\"{{context:fromdt}}\"}}, {\"EFQType\":\"LessThanOrEqual\", \"FieldName\":\"Composer\", \"RightHandSide\":{\"EFQType\":\"Constant\", \"ConstantValue\":\"{{context:todt}}\"}}]}" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StoredQuery",
                keyColumn: "StoredQueryId",
                keyValue: 12);
        }
    }
}
