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

        public virtual ICollection<LancheCustomizado> LanchesCustomizados { get; private set; }

        // Culpa do EF
        protected PedidoLanche() { }

        public PedidoLanche(Guid id,
                            Guid pedidoId,
                            Lanche lanche,
                            ICollection<LancheCustomizado> lanchesCustomizados)
        {
            Id = id;
            PedidoId = pedidoId;
            LancheId = lanche.Id;
            Lanche = lanche;
            LanchesCustomizados = lanchesCustomizados;
        }

        // Validações
        public override bool IsValid()
        {
            return true;
        }
    }
}
