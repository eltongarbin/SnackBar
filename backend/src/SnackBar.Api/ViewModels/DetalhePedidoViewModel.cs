using System;
using System.Collections.Generic;

namespace SnackBar.Api.ViewModels
{
    public class DetalhePedidoViewModel
    {
        public Guid Id { get; set; }
        public string Cliente { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public DateTime? DataEntrega { get; set; }
        public decimal ValorTotal { get; set; }

        public IEnumerable<LancheViewModel> Lanches { get; set; }
    }
}