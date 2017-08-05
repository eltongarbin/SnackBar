using System;
using SnackBar.Domain.Core.Events;

namespace SnackBar.Domain.Pedidos.Events
{
    public class PedidoEventHandler :
        IHandler<PedidoRealizadoEvent>
    {
        public void Handle(PedidoRealizadoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pedido realizado com sucesso.");
        }
    }
}
