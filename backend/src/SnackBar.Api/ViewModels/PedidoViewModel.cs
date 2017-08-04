using System;
using System.Collections.Generic;
using System.Linq;

namespace SnackBar.Api.ViewModels
{
    public class PedidoViewModel
    {
        public Guid Id { get; set; }
        public string Cliente { get; set; }
        public decimal ValorTotal { get; set; }

        public int QtLanches
        {
            get { return Lanches.Count(); }
        }

        public IEnumerable<LancheViewModel> Lanches { get; set; }
    }
}
