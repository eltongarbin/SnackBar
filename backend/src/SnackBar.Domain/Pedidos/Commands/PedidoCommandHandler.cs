using SnackBar.Domain.CommandHandlers;
using SnackBar.Domain.Core.Bus;
using SnackBar.Domain.Core.Events;
using SnackBar.Domain.Core.Notifications;
using SnackBar.Domain.Interfaces;
using SnackBar.Domain.Pedidos.Repository;
using System;
using SnackBar.Domain.Pedidos.Events;
using SnackBar.Domain.Pedidos.Models.Entity;

namespace SnackBar.Domain.Pedidos.Commands
{
    public class PedidoCommandHandler : CommandHandler,
        IHandler<RealizarPedidoCommand>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IBus _bus;

        public PedidoCommandHandler(IPedidoRepository pedidoRepository,
                                    IUnitOfWork uow,
                                    IBus bus,
                                    IDomainNotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _pedidoRepository = pedidoRepository;
            _bus = bus;
        }

        public void Handle(RealizarPedidoCommand message)
        {
            var pedido = Pedido.PedidoFactory.Criar(message.Cliente);
            message.SetarPedidoId(pedido.Id);

            foreach (var lanche in message.IncluirPedidoLancheListCommand)
            {
                var pedidoLanche = PedidoLanche.PedidoLancheFactory.Criar(pedido.Id, lanche.LancheId);

                foreach (var ingrediente in lanche.Ingredientes)
                {
                    pedidoLanche.LanchesCustomizados.Add(new LancheCustomizado(Guid.NewGuid(), pedidoLanche.Id, ingrediente.Id));
                }

                pedido.PedidosLanches.Add(pedidoLanche);
            }

            if (!PedidoInvalido(pedido))
                return;

            _pedidoRepository.Adicionar(pedido);

            if (Commit())
            {
                _bus.RaiseEvent(new PedidoRealizadoEvent(pedido.Id,
                                                         pedido.Cliente,
                                                         pedido.DataPedido,
                                                         pedido.Valor));
            }
        }

        private bool PedidoInvalido(Pedido pedido)
        {
            if (pedido.IsValid())
                return true;

            NotificarValidacoesErro(pedido.ValidationResult);
            return false;
        }
    }
}
