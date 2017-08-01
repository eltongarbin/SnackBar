using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SnackBar.Domain.Pedidos.Models.Entity;
using SnackBar.Infra.Data.Extensions;

namespace SnackBar.Infra.Data.Mappings
{
    public class LancheCustomizadoMapping : EntityTypeConfiguration<LancheCustomizado>
    {
        public override void Map(EntityTypeBuilder<LancheCustomizado> builder)
        {
            builder.ToTable("LanchesCustomizados")
                .Ignore(e => e.ValidationResult)
                .Ignore(e => e.CascadeMode);

            builder.HasOne(e => e.PedidoLanche)
                .WithMany(e => e.LanchesCustomizados)
                .HasForeignKey(e => e.PedidoLancheId)
                .IsRequired();

            builder.HasOne(e => e.Ingrediente)
                .WithMany(e => e.LanchesCustomizados)
                .HasForeignKey(e => e.IngredienteId)
                .IsRequired();
        }
    }
}