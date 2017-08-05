using System;

namespace SnackBar.Domain.Pedidos.Events
{
    public class PedidoRealizadoEvent : BasePedidoEvent
    {
        public PedidoRealizadoEvent(Guid id,
                                    string cliente,
                                    DateTime dataPedido,
                                    decimal valorTotal)
        {
            Id = id;
            Cliente = cliente;
            DataPedido = dataPedido;
            ValorTotal = valorTotal;

            AggregateId = id;
        }
    }
}
