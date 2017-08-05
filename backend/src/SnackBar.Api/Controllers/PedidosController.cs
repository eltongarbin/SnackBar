using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SnackBar.Api.ViewModels;
using SnackBar.Domain.Core.Bus;
using SnackBar.Domain.Core.Notifications;
using SnackBar.Domain.Pedidos.Repository;
using System.Collections.Generic;
using SnackBar.Domain.Pedidos.Commands;

namespace SnackBar.Api.Controllers
{
    public class PedidosController : BaseController
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController(IDomainNotificationHandler<DomainNotification> notifications, 
                                 IBus bus, 
                                 IMapper mapper,
                                 IPedidoRepository pedidoRepository) 
            : base(notifications, bus)
        {
            _bus = bus;
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
            _bus.SendCommand(pedidoCommand);

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
