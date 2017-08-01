using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SnackBar.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lanches",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lanches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cliente = table.Column<string>(maxLength: 150, nullable: false),
                    DataCancelamento = table.Column<DateTime>(nullable: true),
                    DataEntrega = table.Column<DateTime>(nullable: true),
                    DataPedido = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanchesPredefinidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IngredienteId = table.Column<Guid>(nullable: false),
                    LancheId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanchesPredefinidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanchesPredefinidos_Ingredientes_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanchesPredefinidos_Lanches_LancheId",
                        column: x => x.LancheId,
                        principalTable: "Lanches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidosLanches",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LancheId = table.Column<Guid>(nullable: false),
                    PedidoId = table.Column<Guid>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosLanches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosLanches_Lanches_LancheId",
                        column: x => x.LancheId,
                        principalTable: "Lanches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidosLanches_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanchesCustomizados",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IngredienteId = table.Column<Guid>(nullable: false),
                    PedidoLancheId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanchesCustomizados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanchesCustomizados_Ingredientes_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanchesCustomizados_PedidosLanches_PedidoLancheId",
                        column: x => x.PedidoLancheId,
                        principalTable: "PedidosLanches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanchesPredefinidos_IngredienteId",
                table: "LanchesPredefinidos",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_LanchesPredefinidos_LancheId",
                table: "LanchesPredefinidos",
                column: "LancheId");

            migrationBuilder.CreateIndex(
                name: "IX_LanchesCustomizados_IngredienteId",
                table: "LanchesCustomizados",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_LanchesCustomizados_PedidoLancheId",
                table: "LanchesCustomizados",
                column: "PedidoLancheId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosLanches_LancheId",
                table: "PedidosLanches",
                column: "LancheId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosLanches_PedidoId",
                table: "PedidosLanches",
                column: "PedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanchesPredefinidos");

            migrationBuilder.DropTable(
                name: "LanchesCustomizados");

            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "PedidosLanches");

            migrationBuilder.DropTable(
                name: "Lanches");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
