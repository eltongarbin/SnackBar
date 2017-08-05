using SnackBar.Domain.Core.Events;
using System;

namespace SnackBar.Domain.Pedidos.Events
{
    public abstract class BasePedidoEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Cliente { get; protected set; }
        public DateTime DataPedido { get; protected set; }
        public DateTime? DataEntrega { get; protected set; }
        public DateTime? DataCancelamento { get; protected set; }
        public decimal Valor { get; protected set; }
    }
}
