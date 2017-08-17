using MediatR;
using System;

namespace SnackBar.Domain.Pedidos.Events
{
    public class PedidoEventHandler :
        INotificationHandler<PedidoRealizadoEvent>
    {
        public void Handle(PedidoRealizadoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pedido realizado com sucesso.");
        }
    }
}
