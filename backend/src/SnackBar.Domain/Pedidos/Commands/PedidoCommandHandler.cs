using MediatR;
using SnackBar.Domain.Core.Notifications;
using SnackBar.Domain.Handlers;
using SnackBar.Domain.Interfaces;
using SnackBar.Domain.Pedidos.Events;
using SnackBar.Domain.Pedidos.Models.Entity;
using SnackBar.Domain.Pedidos.Models.Logic.Desconto;
using SnackBar.Domain.Pedidos.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SnackBar.Domain.Pedidos.Commands
{
    public class PedidoCommandHandler : CommandHandler,
        INotificationHandler<RealizarPedidoCommand>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMediatorHandler _mediator;

        public PedidoCommandHandler(IPedidoRepository pedidoRepository,
                                    IUnitOfWork uow,
                                    IMediatorHandler mediator,
                                    INotificationHandler<DomainNotification> notifications)
            : base(uow, mediator, notifications)
        {
            _pedidoRepository = pedidoRepository;
            _mediator = mediator;
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
                _mediator.PublicarEvento(new PedidoRealizadoEvent(pedido.Id,
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
                    _mediator.PublicarEvento(new DomainNotification(command.MessageType, "Lanche não encontrado no cardápio."));
                    return;
                }

                var pedidoLanche = PedidoLanche.PedidoLancheFactory.Criar(command.PedidoId, command.LancheId);

                foreach (var ingredienteId in command.IngredienteIdList)
                {
                    var ingrediente = _pedidoRepository.ObterIngredientePorId(ingredienteId);
                    if (ingrediente == null)
                    {
                        _mediator.PublicarEvento(new DomainNotification(command.MessageType, "Ingrediente não encontrado."));
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
