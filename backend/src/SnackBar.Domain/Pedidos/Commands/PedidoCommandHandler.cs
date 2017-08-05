using SnackBar.Domain.CommandHandlers;
using SnackBar.Domain.Core.Bus;
using SnackBar.Domain.Core.Events;
using SnackBar.Domain.Core.Notifications;
using SnackBar.Domain.Interfaces;
using SnackBar.Domain.Pedidos.Events;
using SnackBar.Domain.Pedidos.Models.Entity;
using SnackBar.Domain.Pedidos.Repository;
using System.Collections.Generic;
using System.Linq;
using SnackBar.Domain.Pedidos.Models.Logic.Desconto;

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

            PreencherEntidadesFilhas(ref pedido, message.IncluirPedidoLancheListCommand);

            VerificarPromocaoLanches(ref pedido);

            if (!PedidoValido(pedido))
                return;

            _pedidoRepository.Adicionar(pedido);

            if (Commit())
            {
                _bus.RaiseEvent(new PedidoRealizadoEvent(pedido.Id,
                                                         pedido.Cliente,
                                                         pedido.DataPedido,
                                                         pedido.ValorTotal));
            }
        }

        private void VerificarPromocaoLanches(ref Pedido pedido)
        {
            foreach (var pedidoLanche in pedido.PedidosLanches)
            {
                var lanche = _pedidoRepository.ObterLancheCardapioPorId(pedidoLanche.LancheId);
                var pedidoLancheVerificar = PedidoLanche.PedidoLancheFactory.Criar(pedido, lanche);

                foreach (var customizado in pedidoLanche.LanchesCustomizados)
                {
                    var ingrediente = _pedidoRepository.ObterIngredientePorId(customizado.IngredienteId);
                    pedidoLancheVerificar.LanchesCustomizados.Add(LancheCustomizado.LancheCustomizadoFactory.Criar(pedidoLanche,
                                                                                                                   ingrediente));
                }

                var promocao = PromocaoPedidoLanche.PromocaoPedidoLancheFactory.Calcular(pedidoLancheVerificar);
                var valor = pedidoLancheVerificar.LanchesCustomizados.Select(lc => lc.Ingrediente).Sum(i => i.Valor);

                pedidoLanche.CalcularValorTotal(valor, promocao.Descricao, promocao.Desconto);
            }

            pedido.CalcularValorTotal();
        }

        private void PreencherEntidadesFilhas(ref Pedido pedido,
                                              IEnumerable<IncluirPedidoLancheCommand> incluirPedidoLancheListCommand)
        {
            foreach (var command in incluirPedidoLancheListCommand)
            {
                var lanche = _pedidoRepository.ObterLancheCardapioPorId(command.LancheId);
                if (lanche == null)
                {
                    _bus.RaiseEvent(new DomainNotification(command.MessageType, "Lanche não encontrado no cardápio."));
                    return;
                }

                var pedidoLanche = PedidoLanche.PedidoLancheFactory.Criar(command.PedidoId, command.LancheId);

                foreach (var ingredienteId in command.IngredienteIdList)
                {
                    var ingrediente = _pedidoRepository.ObterIngredientePorId(ingredienteId);
                    if (ingrediente == null)
                    {
                        _bus.RaiseEvent(new DomainNotification(command.MessageType, "Ingrediente não encontrado."));
                        return;
                    }

                    pedidoLanche.LanchesCustomizados.Add(LancheCustomizado.LancheCustomizadoFactory.Criar(pedidoLanche.Id,
                                                                                                          ingredienteId));
                }

                pedido.PedidosLanches.Add(pedidoLanche);
            }
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
