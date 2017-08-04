using SnackBar.Domain.Core.Models;
using SnackBar.Domain.Ingredientes;
using System;

namespace SnackBar.Domain.Lanches.Models.Entity
{
    public class LanchePredefinido : Entity<LanchePredefinido>
    {
        public Guid LancheId { get; set; }
        public Guid IngredienteId { get; set; }

        public virtual Lanche Lanche { get; private set; }
        public virtual Ingrediente Ingrediente { get; private set; }

        // Culpa do EF
        protected LanchePredefinido() { }

        public LanchePredefinido(Lanche lanche, 
                                 Ingrediente ingrediente)
        {
            Id = Guid.NewGuid();
            LancheId = lanche.Id;
            IngredienteId = ingrediente.Id;
            Lanche = lanche;
            Ingrediente = ingrediente;
        }

        // Validações
        public override bool IsValid()
        {
            return true;
        }
    }
}
