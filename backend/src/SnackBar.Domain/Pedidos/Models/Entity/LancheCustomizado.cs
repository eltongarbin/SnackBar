using System;
using SnackBar.Domain.Core.Models;
using SnackBar.Domain.Ingredientes;

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
            return true;
        }
    }
}
