using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotaMarket.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Users_UserId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemHistories_Users_FromId",
                table: "ItemHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemHistories_Users_ToId",
                table: "ItemHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Inventory_InventoryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Market_MarketId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_MarketHistories_UserId",
                table: "MarketHistories");

            migrationBuilder.DropIndex(
                name: "IX_Items_InventoryId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_MarketId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_ItemHistories_FromId",
                table: "ItemHistories");

            migrationBuilder.DropIndex(
                name: "IX_ItemHistories_ToId",
                table: "ItemHistories");

            migrationBuilder.DropColumn(
                name: "BuyId",
                table: "MarketHistories");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "MarketHistories");

            migrationBuilder.DropColumn(
                name: "MarketId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "FromId",
                table: "ItemHistories");

            migrationBuilder.DropColumn(
                name: "ToId",
                table: "ItemHistories");

            migrationBuilder.RenameColumn(
                name: "NameItem",
                table: "Items",
                newName: "Name");

            migrationBuilder.AlterColumn<Guid>(
                name: "InventoryId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "MarketHistories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "Market",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<decimal>(
                name: "ItemPrice",
                table: "Items",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "ItemAction",
                table: "ItemHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "BuyerId",
                table: "ItemHistories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SellerId",
                table: "ItemHistories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Inventory",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "Inventory",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemsId",
                table: "Inventory",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_InventoryId",
                table: "Users",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketHistories_UserId",
                table: "MarketHistories",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Market_ItemId",
                table: "Market",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ItemsId",
                table: "Inventory",
                column: "ItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Items_ItemsId",
                table: "Inventory",
                column: "ItemsId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Users_UserId",
                table: "Inventory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Market_Items_ItemId",
                table: "Market",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Inventory_InventoryId",
                table: "Users",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Items_ItemsId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Users_UserId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Market_Items_ItemId",
                table: "Market");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Inventory_InventoryId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_InventoryId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_MarketHistories_UserId",
                table: "MarketHistories");

            migrationBuilder.DropIndex(
                name: "IX_Market_ItemId",
                table: "Market");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_ItemsId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "MarketHistories");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "ItemHistories");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "ItemHistories");

            migrationBuilder.DropColumn(
                name: "ItemsId",
                table: "Inventory");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Items",
                newName: "NameItem");

            migrationBuilder.AlterColumn<Guid>(
                name: "InventoryId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BuyId",
                table: "MarketHistories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SaleId",
                table: "MarketHistories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "Market",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ItemPrice",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MarketId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemAction",
                table: "ItemHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FromId",
                table: "ItemHistories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ToId",
                table: "ItemHistories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Inventory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "Inventory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MarketHistories_UserId",
                table: "MarketHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_InventoryId",
                table: "Items",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_MarketId",
                table: "Items",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemHistories_FromId",
                table: "ItemHistories",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemHistories_ToId",
                table: "ItemHistories",
                column: "ToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Users_UserId",
                table: "Inventory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemHistories_Users_FromId",
                table: "ItemHistories",
                column: "FromId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemHistories_Users_ToId",
                table: "ItemHistories",
                column: "ToId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Inventory_InventoryId",
                table: "Items",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Market_MarketId",
                table: "Items",
                column: "MarketId",
                principalTable: "Market",
                principalColumn: "Id");
        }
    }
}
