using System;
using System.Collections.Generic;

namespace SnackBar.Domain.Pedidos.Commands
{
    public class RealizarPedidoCommand : BasePedidoCommand
    {
        public IEnumerable<IncluirPedidoLancheCommand> IncluirPedidoLancheListCommand { get; private set; }

        public RealizarPedidoCommand(string cliente,
                                     IEnumerable<IncluirPedidoLancheCommand> incluirPedidoLancheListCommand)
        {
            Cliente = cliente;
            IncluirPedidoLancheListCommand = incluirPedidoLancheListCommand;
        }

        public void SetarPedidoId(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
