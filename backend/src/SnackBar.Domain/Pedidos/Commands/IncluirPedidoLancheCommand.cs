using SnackBar.Domain.Core.Commands;
using SnackBar.Domain.Ingredientes;
using System;
using System.Collections.Generic;

namespace SnackBar.Domain.Pedidos.Commands
{
    public class IncluirPedidoLancheCommand : Command
    {
        public Guid PedidoId { get; private set; }
        public Guid LancheId { get; private set; }
        public IEnumerable<Ingrediente> Ingredientes { get; private set; }

        public IncluirPedidoLancheCommand(Guid pedidoId, 
                                          Guid lancheId, 
                                          IEnumerable<Ingrediente> ingredientes)
        {
            PedidoId = pedidoId;
            LancheId = lancheId;
            Ingredientes = ingredientes;

            AggregateId = pedidoId;
        }
    }
}
