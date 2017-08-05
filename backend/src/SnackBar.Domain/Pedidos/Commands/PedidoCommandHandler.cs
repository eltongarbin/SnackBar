using SnackBar.Domain.CommandHandlers;
using SnackBar.Domain.Core.Bus;
using SnackBar.Domain.Core.Events;
using SnackBar.Domain.Core.Notifications;
using SnackBar.Domain.Interfaces;
using SnackBar.Domain.Pedidos.Repository;
using System;
using System.Linq;
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

            if (!PedidoValido(pedido))
                return;

            if (!EntidadesFilhasExistente(pedido, message.MessageType))
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

        private bool EntidadesFilhasExistente(Pedido pedido, string messageType)
        {
            foreach (var pedidoLanche in pedido.PedidosLanches)
            {
                if (!PedidoLancheExistente(pedidoLanche, messageType))
                    return false;
            }

            return true;
        }

        private bool PedidoLancheExistente(PedidoLanche pedidoLanche, string messageType)
        {
            if (!LancheExistente(pedidoLanche.LancheId))
            {
                _bus.RaiseEvent(new DomainNotification(messageType, "Lanche não encontrado no cardápio."));
                return false;
            }

            foreach (var ingredienteId in pedidoLanche.LanchesCustomizados.Select(lc => lc.IngredienteId))
            {
                if (!IngredienteExistente(ingredienteId))
                {
                    _bus.RaiseEvent(new DomainNotification(messageType, "Ingrediente não encontrado."));
                    return false;
                }
            }

            return true;
        }

        private bool IngredienteExistente(Guid id)
        {
            var ingrediente = _pedidoRepository.ObterIngredientePorId(id);

            return (ingrediente != null);
        }

        private bool LancheExistente(Guid id)
        {
            var lanche = _pedidoRepository.ObterLancheCardapioPorId(id);

            return (lanche != null);
        }

        private bool PedidoValido(Pedido pedido)
        {
            if (pedido.IsValid())
                return true;

            NotificarValidacoesErro(pedido.ValidationResult);
            return false;
        }
    }
}
