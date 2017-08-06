using System;

namespace SnackBar.Api.ViewModels
{
    public class PedidoViewModel
    {
        public Guid Id { get; set; }
        public string Cliente { get; set; }
        public decimal ValorTotal { get; set; }
        public int QtLanches { get; set; }
        public string Status { get; set; }
        public DateTime DataStatus { get; set; }
    }
}
