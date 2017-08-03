using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SnackBar.Api.ViewModels;
using SnackBar.Domain.Core.Bus;
using SnackBar.Domain.Core.Notifications;
using SnackBar.Domain.Pedidos.Repository;
using System.Collections.Generic;

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
        [Route("pedidos/ingredientes")]
        public IEnumerable<IngredienteViewModel> ObterIngredientes()
        {
            return _mapper.Map<IEnumerable<IngredienteViewModel>>(_pedidoRepository.ObterIngredientes());
        }
    }
}
