using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SnackBar.Domain.Ingredientes;
using SnackBar.Domain.Lanches;
using SnackBar.Domain.Lanches.Models.Entity;
using SnackBar.Domain.Pedidos;
using SnackBar.Domain.Pedidos.Models.Entity;
using SnackBar.Infra.Data.Extensions;
using SnackBar.Infra.Data.Mappings;
using System.IO;

namespace SnackBar.Infra.Data.Context
{
    public class SnackBarContext : DbContext
    {
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<LancheCustomizado> LanchesCustomizados { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<LanchePredefinido> LanchesPredefinidos { get; set; }
        public DbSet<PedidoLanche> PedidosLanches { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        public SnackBarContext(DbContextOptions<SnackBarContext> options)
            : base(options) { }

        public SnackBarContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new IngredienteMapping());
            modelBuilder.AddConfiguration(new LancheCustomizadoMapping());
            modelBuilder.AddConfiguration(new LancheMapping());
            modelBuilder.AddConfiguration(new LanchePredefinidoMapping());
            modelBuilder.AddConfiguration(new PedidoLancheMapping());
            modelBuilder.AddConfiguration(new PedidoMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}