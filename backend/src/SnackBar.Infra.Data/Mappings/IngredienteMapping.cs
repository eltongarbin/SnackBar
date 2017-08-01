using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SnackBar.Domain.Ingredientes;
using SnackBar.Infra.Data.Extensions;

namespace SnackBar.Infra.Data.Mappings
{
    public class IngredienteMapping : EntityTypeConfiguration<Ingrediente>
    {
        public override void Map(EntityTypeBuilder<Ingrediente> builder)
        {
            builder.ToTable("Ingredientes")
                .Ignore(e => e.ValidationResult)
                .Ignore(e => e.CascadeMode);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Valor)
                .IsRequired();
        }
    }
}