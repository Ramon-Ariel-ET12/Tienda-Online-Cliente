using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class AddForeignKeyCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Categoria_CategoriaId",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_CategoriaId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Producto");

            migrationBuilder.AddColumn<Guid>(
                name: "IdCategoria",
                table: "Producto",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdCategoria",
                table: "Producto",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Categoria_IdCategoria",
                table: "Producto",
                column: "IdCategoria",
                principalTable: "Categoria",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Categoria_IdCategoria",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_IdCategoria",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Producto");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoriaId",
                table: "Producto",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_CategoriaId",
                table: "Producto",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Categoria_CategoriaId",
                table: "Producto",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
