using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SnackBar.Domain.Pedidos;
using SnackBar.Infra.Data.Extensions;

namespace SnackBar.Infra.Data.Mappings
{
    public class PedidoMapping : EntityTypeConfiguration<Pedido>
    {
        public override void Map(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos")
                .Ignore(e => e.ValidationResult)
                .Ignore(e => e.CascadeMode);

            builder.Property(e => e.Cliente)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
