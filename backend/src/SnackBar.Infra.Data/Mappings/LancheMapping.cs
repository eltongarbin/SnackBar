using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SnackBar.Domain.Lanches;
using SnackBar.Infra.Data.Extensions;

namespace SnackBar.Infra.Data.Mappings
{
    public class LancheMapping : EntityTypeConfiguration<Lanche>
    {
        public override void Map(EntityTypeBuilder<Lanche> builder)
        {
            builder.ToTable("Lanches")
                .Ignore(e => e.ValidationResult)
                .Ignore(e => e.CascadeMode);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Valor)
                .IsRequired();
        }
    }
}
