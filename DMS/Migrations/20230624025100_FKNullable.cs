﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMS.Migrations
{
    /// <inheritdoc />
    public partial class FKNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Entregas_idEntrega",
                table: "Pedidos");

            migrationBuilder.AlterColumn<int>(
                name: "idEntrega",
                table: "Pedidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Entregas_idEntrega",
                table: "Pedidos",
                column: "idEntrega",
                principalTable: "Entregas",
                principalColumn: "IdEntrega");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Entregas_idEntrega",
                table: "Pedidos");

            migrationBuilder.AlterColumn<int>(
                name: "idEntrega",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Entregas_idEntrega",
                table: "Pedidos",
                column: "idEntrega",
                principalTable: "Entregas",
                principalColumn: "IdEntrega",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
