using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SnackBar.Infra.Data.Context;

namespace SnackBar.Infra.Data.Migrations
{
    [DbContext(typeof(SnackBarContext))]
    [Migration("20170808100943_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SnackBar.Domain.Ingredientes.Ingrediente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("SnackBar.Domain.Lanches.Lanche", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.ToTable("Lanches");
                });

            modelBuilder.Entity("SnackBar.Domain.Lanches.Models.Entity.LanchePredefinido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("IngredienteId");

                    b.Property<Guid>("LancheId");

                    b.HasKey("Id");

                    b.HasIndex("IngredienteId");

                    b.HasIndex("LancheId");

                    b.ToTable("LanchesPredefinidos");
                });

            modelBuilder.Entity("SnackBar.Domain.Pedidos.Models.Entity.LancheCustomizado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("IngredienteId");

                    b.Property<Guid>("PedidoLancheId");

                    b.HasKey("Id");

                    b.HasIndex("IngredienteId");

                    b.HasIndex("PedidoLancheId");

                    b.ToTable("LanchesCustomizados");
                });

            modelBuilder.Entity("SnackBar.Domain.Pedidos.Models.Entity.PedidoLanche", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Desconto");

                    b.Property<Guid>("LancheId");

                    b.Property<Guid>("PedidoId");

                    b.Property<string>("Promocao")
                        .HasMaxLength(20);

                    b.Property<decimal>("ValorTotal");

                    b.HasKey("Id");

                    b.HasIndex("LancheId");

                    b.HasIndex("PedidoId");

                    b.ToTable("PedidosLanches");
                });

            modelBuilder.Entity("SnackBar.Domain.Pedidos.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<DateTime?>("DataCancelamento");

                    b.Property<DateTime?>("DataEntrega");

                    b.Property<DateTime>("DataPedido");

                    b.Property<decimal>("ValorTotal");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("SnackBar.Domain.Lanches.Models.Entity.LanchePredefinido", b =>
                {
                    b.HasOne("SnackBar.Domain.Ingredientes.Ingrediente", "Ingrediente")
                        .WithMany("LanchesPredefinidos")
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SnackBar.Domain.Lanches.Lanche", "Lanche")
                        .WithMany("LanchesPredefinidos")
                        .HasForeignKey("LancheId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SnackBar.Domain.Pedidos.Models.Entity.LancheCustomizado", b =>
                {
                    b.HasOne("SnackBar.Domain.Ingredientes.Ingrediente", "Ingrediente")
                        .WithMany("LanchesCustomizados")
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SnackBar.Domain.Pedidos.Models.Entity.PedidoLanche", "PedidoLanche")
                        .WithMany("LanchesCustomizados")
                        .HasForeignKey("PedidoLancheId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SnackBar.Domain.Pedidos.Models.Entity.PedidoLanche", b =>
                {
                    b.HasOne("SnackBar.Domain.Lanches.Lanche", "Lanche")
                        .WithMany("PedidosLanches")
                        .HasForeignKey("LancheId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SnackBar.Domain.Pedidos.Pedido", "Pedido")
                        .WithMany("PedidosLanches")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
