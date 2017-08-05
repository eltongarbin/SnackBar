using SnackBar.Domain.Core.Commands;
using System;
using System.Collections.Generic;

namespace SnackBar.Domain.Pedidos.Commands
{
    public class IncluirPedidoLancheCommand : Command
    {
        public Guid PedidoId { get; private set; }
        public Guid LancheId { get; private set; }
        public IEnumerable<Guid> IngredienteIdList { get; private set; }

        public IncluirPedidoLancheCommand(Guid pedidoId, 
                                          Guid lancheId, 
                                          IEnumerable<Guid> ingredienteIdList)
        {
            PedidoId = pedidoId;
            LancheId = lancheId;
            IngredienteIdList = ingredienteIdList;

            AggregateId = pedidoId;
        }
    }
}
