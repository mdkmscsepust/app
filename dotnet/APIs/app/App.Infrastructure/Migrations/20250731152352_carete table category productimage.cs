using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Infrastructure.Migrations;

/// <inheritdoc />
public partial class caretetablecategoryproductimage : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Products",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(100)",
            oldMaxLength: 100);

        migrationBuilder.AddColumn<int>(
            name: "CategoryId",
            table: "Products",
            type: "integer",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<decimal>(
            name: "Price",
            table: "Products",
            type: "numeric",
            nullable: false,
            defaultValue: 0m);

        migrationBuilder.CreateTable(
            name: "Categories",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Categories", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ProductImages",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                ImageUrl = table.Column<string>(type: "text", nullable: false),
                ProductId = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ProductImages", x => x.Id);
                table.ForeignKey(
                    name: "FK_ProductImages_Products_ProductId",
                    column: x => x.ProductId,
                    principalTable: "Products",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Products_CategoryId",
            table: "Products",
            column: "CategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_ProductImages_ProductId",
            table: "ProductImages",
            column: "ProductId");

        migrationBuilder.AddForeignKey(
            name: "FK_Products_Categories_CategoryId",
            table: "Products",
            column: "CategoryId",
            principalTable: "Categories",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Products_Categories_CategoryId",
            table: "Products");

        migrationBuilder.DropTable(
            name: "Categories");

        migrationBuilder.DropTable(
            name: "ProductImages");

        migrationBuilder.DropIndex(
            name: "IX_Products_CategoryId",
            table: "Products");

        migrationBuilder.DropColumn(
            name: "CategoryId",
            table: "Products");

        migrationBuilder.DropColumn(
            name: "Price",
            table: "Products");

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Products",
            type: "character varying(100)",
            maxLength: 100,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");
    }
}
