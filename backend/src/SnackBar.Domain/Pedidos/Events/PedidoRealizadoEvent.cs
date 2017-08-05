using System;

namespace SnackBar.Domain.Pedidos.Events
{
    public class PedidoRealizadoEvent : BasePedidoEvent
    {
        public PedidoRealizadoEvent(Guid id,
                                    string cliente,
                                    DateTime dataPedido,
                                    decimal valor)
        {
            Id = id;
            Cliente = cliente;
            DataPedido = dataPedido;
            Valor = valor;

            AggregateId = id;
        }
    }
}
