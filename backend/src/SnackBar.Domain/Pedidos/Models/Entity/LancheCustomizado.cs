using SnackBar.Domain.Core.Models;
using SnackBar.Domain.Ingredientes;
using System;

namespace SnackBar.Domain.Pedidos.Models.Entity
{
    public class LancheCustomizado : Entity<LancheCustomizado>
    {
        public Guid PedidoLancheId { get; private set; }
        public Guid IngredienteId { get; private set; }

        public virtual PedidoLanche PedidoLanche { get; private set; }
        public virtual Ingrediente Ingrediente { get; private set; }

        // Culpa do EF
        protected LancheCustomizado() { }

        public LancheCustomizado(Guid id,
                                 Guid pedidoLancheId,
                                 Guid ingredienteLancheId)
        {
            Id = id;
            PedidoLancheId = pedidoLancheId;
            IngredienteId = ingredienteLancheId;
        }

        // Validações
        public override bool IsValid()
        {
            ValidationResult = Validate(this);

            foreach (var error in Ingrediente.ValidationResult.Errors)
            {
                ValidationResult.Errors.Add(error);
            }

            return ValidationResult.IsValid;
        }
    }
}
