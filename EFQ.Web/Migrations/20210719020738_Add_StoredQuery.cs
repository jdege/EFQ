using Microsoft.EntityFrameworkCore.Migrations;

namespace EFQ.Web.Migrations
{
    public partial class Add_StoredQuery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoredQuery",
                columns: table => new
                {
                    StoredQueryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    BaseTableName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StoredQueryJson = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoredQuery", x => x.StoredQueryId);
                });

            migrationBuilder.InsertData(
                table: "StoredQuery",
                columns: new[] { "StoredQueryId", "BaseTableName", "Description", "Name", "StoredQueryJson" },
                values: new object[] { 1, "Album", "Albums by Iron Maiden", "Iron Maiden Albums", "{\"SelectionComparison\":\"Equal\",\"FieldName\":\"ArtistId\",\"RightHandSide\":{\"SelectionComparison\":\"Constant\",\"ConstantValue\":90,\"AggregateList\":[]},\"AggregateList\":[]}" });

            migrationBuilder.InsertData(
                table: "StoredQuery",
                columns: new[] { "StoredQueryId", "BaseTableName", "Description", "Name", "StoredQueryJson" },
                values: new object[] { 2, "Album", "Albums by Led Zeppelin", "Led Zeppelin", "{\"SelectionComparison\":\"Equal\",\"FieldName\":\"ArtistId\",\"RightHandSide\":{\"SelectionComparison\":\"Constant\",\"ConstantValue\":22,\"AggregateList\":[]},\"AggregateList\":[]}" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoredQuery");
        }
    }
}
