using System;
using System.Collections.Generic;

namespace SnackBar.Api.ViewModels
{
    public class LancheViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public IEnumerable<IngredienteViewModel> Ingredientes { get; set; }

        public LancheViewModel()
        {
            Id = Guid.NewGuid();
            Ingredientes = new List<IngredienteViewModel>();
        }
    }
}
