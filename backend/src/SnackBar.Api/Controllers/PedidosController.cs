using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SnackBar.Api.ViewModels;
using SnackBar.Domain.Core.Notifications;
using SnackBar.Domain.Interfaces;
using SnackBar.Domain.Pedidos.Commands;
using SnackBar.Domain.Pedidos.Repository;
using System;
using System.Collections.Generic;

namespace SnackBar.Api.Controllers
{
    public class PedidosController : BaseController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IMapper _mapper;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController(INotificationHandler<DomainNotification> notifications, 
                                 IMediatorHandler mediator, 
                                 IMapper mapper,
                                 IPedidoRepository pedidoRepository) 
            : base(notifications, mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        [Route("pedidos")]
        public IEnumerable<PedidoViewModel> Get()
        {
            return _mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoRepository.ObterTodos());
        }

        [HttpGet]
        [Route("pedidos/{id:guid}")]
        public DetalhePedidoViewModel Get(Guid id, int version)
        {
            return _mapper.Map<DetalhePedidoViewModel>(_pedidoRepository.ObterPorId(id));
        }

        [HttpPost]
        [Route("pedidos")]
        public IActionResult Post([FromBody] DetalhePedidoViewModel eventoViewModel)
        {
            var pedidoCommand = _mapper.Map<RealizarPedidoCommand>(eventoViewModel);
            _mediator.EnviarComando(pedidoCommand);

            return Response(pedidoCommand);
        }

        [HttpGet]
        [Route("pedidos/ingredientes")]
        public IEnumerable<IngredienteViewModel> ObterIngredientes()
        {
            return _mapper.Map<IEnumerable<IngredienteViewModel>>(_pedidoRepository.ObterIngredientes());
        }

        [HttpGet]
        [Route("pedidos/lanches-cardapio")]
        public IEnumerable<LancheViewModel> ObterLanchesCardapio()
        {
            return _mapper.Map<IEnumerable<LancheViewModel>>(_pedidoRepository.ObterLanchesCardapio());
        }
    }
}
