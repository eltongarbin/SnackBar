using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SnackBar.Domain.Pedidos.Models.Entity;
using SnackBar.Infra.Data.Extensions;

namespace SnackBar.Infra.Data.Mappings
{
    public class PedidoLancheMapping : EntityTypeConfiguration<PedidoLanche>
    {
        public override void Map(EntityTypeBuilder<PedidoLanche> builder)
        {
            builder.ToTable("PedidosLanches")
                .Ignore(e => e.ValidationResult)
                .Ignore(e => e.CascadeMode);

            builder.HasOne(e => e.Pedido)
                .WithMany(e => e.PedidosLanches)
                .HasForeignKey(e => e.PedidoId)
                .IsRequired();

            builder.HasOne(e => e.Lanche)
                .WithMany(e => e.PedidosLanches)
                .HasForeignKey(e => e.LancheId)
                .IsRequired();

            builder.Property(e => e.Promocao)
                .HasMaxLength(20);
        }
    }
}