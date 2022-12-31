using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Infrastrure.EFCore.Migrations
{
    public partial class InitialInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WareHouses",
                columns: table => new
                {
                    KeyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    InStock = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouses", x => x.KeyId);
                });

            migrationBuilder.CreateTable(
                name: "Oprations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WareHouseID = table.Column<long>(type: "bigint", nullable: false),
                    TypeOperation = table.Column<bool>(type: "bit", nullable: false),
                    Count = table.Column<long>(type: "bigint", nullable: false),
                    Characteristic = table.Column<long>(type: "bigint", nullable: false),
                    OprationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentCount = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oprations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oprations_WareHouses_WareHouseID",
                        column: x => x.WareHouseID,
                        principalTable: "WareHouses",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oprations_WareHouseID",
                table: "Oprations",
                column: "WareHouseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oprations");

            migrationBuilder.DropTable(
                name: "WareHouses");
        }
    }
}
