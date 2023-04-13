using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotaMarket.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketHistories_Users_UserId",
                table: "MarketHistories");

            migrationBuilder.DropIndex(
                name: "IX_MarketHistories_UserId",
                table: "MarketHistories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MarketHistories");

            migrationBuilder.AddColumn<Guid>(
                name: "ActionHistoryId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MarketHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ItemAction",
                table: "MarketHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "MarketHistories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Market",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Market",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ItemHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "ItemHistories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Inventory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Inventory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ActionHistoryId",
                table: "Users",
                column: "ActionHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MarketHistories_ActionHistoryId",
                table: "Users",
                column: "ActionHistoryId",
                principalTable: "MarketHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MarketHistories_ActionHistoryId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ActionHistoryId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ActionHistoryId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MarketHistories");

            migrationBuilder.DropColumn(
                name: "ItemAction",
                table: "MarketHistories");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "MarketHistories");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Market");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Market");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ItemHistories");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "ItemHistories");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Inventory");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "MarketHistories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MarketHistories_UserId",
                table: "MarketHistories",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketHistories_Users_UserId",
                table: "MarketHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
