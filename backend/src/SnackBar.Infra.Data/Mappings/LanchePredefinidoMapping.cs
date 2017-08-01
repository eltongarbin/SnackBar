using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SnackBar.Domain.Lanches.Models.Entity;
using SnackBar.Infra.Data.Extensions;

namespace SnackBar.Infra.Data.Mappings
{
    public class LanchePredefinidoMapping : EntityTypeConfiguration<LanchePredefinido>
    {
        public override void Map(EntityTypeBuilder<LanchePredefinido> builder)
        {
            builder.ToTable("LanchesPredefinidos")
                .Ignore(e => e.ValidationResult)
                .Ignore(e => e.CascadeMode);

            builder.HasOne(e => e.Lanche)
                .WithMany(e => e.LanchesPredefinidos)
                .HasForeignKey(e => e.LancheId)
                .IsRequired();

            builder.HasOne(e => e.Ingrediente)
                .WithMany(e => e.LanchesPredefinidos)
                .HasForeignKey(e => e.IngredienteId)
                .IsRequired();
        }
    }
}
