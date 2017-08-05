using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SnackBar.Infra.Data.Migrations
{
    public partial class Promocao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Pedidos",
                newName: "ValorTotal");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "PedidosLanches",
                newName: "ValorTotal");

            migrationBuilder.AddColumn<decimal>(
                name: "Desconto",
                table: "PedidosLanches",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Promocao",
                table: "PedidosLanches",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desconto",
                table: "PedidosLanches");

            migrationBuilder.DropColumn(
                name: "Promocao",
                table: "PedidosLanches");

            migrationBuilder.RenameColumn(
                name: "ValorTotal",
                table: "Pedidos",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "ValorTotal",
                table: "PedidosLanches",
                newName: "Valor");
        }
    }
}
