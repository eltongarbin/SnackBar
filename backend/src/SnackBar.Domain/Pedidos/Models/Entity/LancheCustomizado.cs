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

        public static class LancheCustomizadoFactory
        {
            public static LancheCustomizado Criar(Guid pedidoLancheId,
                                                  Guid ingredienteLancheId)
            {
                var lancheCustomizado = new LancheCustomizado()
                {
                    PedidoLancheId = pedidoLancheId,
                    IngredienteId = ingredienteLancheId
                };

                return lancheCustomizado;
            }

            public static LancheCustomizado Criar(PedidoLanche pedidoLanche,
                                                  Ingrediente ingrediente)
            {
                var lancheCustomizado = new LancheCustomizado()
                {
                    PedidoLancheId = pedidoLanche.Id,
                    IngredienteId = ingrediente.Id,
                    PedidoLanche = pedidoLanche,
                    Ingrediente = ingrediente
                };

                return lancheCustomizado;
            }
        }
    }
}
