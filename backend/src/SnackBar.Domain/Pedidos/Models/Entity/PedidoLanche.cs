using SnackBar.Domain.Core.Models;
using SnackBar.Domain.Lanches;
using System;
using System.Collections.Generic;

namespace SnackBar.Domain.Pedidos.Models.Entity
{
    public class PedidoLanche : Entity<PedidoLanche>
    {
        public Guid PedidoId { get; private set; }
        public Guid LancheId { get; private set; }
        public decimal Valor { get; private set; }

        public virtual Pedido Pedido { get; private set; }
        public virtual Lanche Lanche { get; private set; }

        public virtual ICollection<LancheCustomizado> LanchesCustomizados { get; set; }

        // Culpa do EF
        protected PedidoLanche() { }

        public PedidoLanche(Pedido pedido,
                            Lanche lanche)
        {
            Id = Guid.NewGuid();
            PedidoId = pedido.Id;
            LancheId = lanche.Id;
            Pedido = pedido;
            Lanche = lanche;
        }

        // Validações
        public override bool IsValid()
        {
            return true;
        }
    }
}
