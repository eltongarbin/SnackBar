using SnackBar.Domain.Core.Models;
using SnackBar.Domain.Ingredientes;
using System;

namespace SnackBar.Domain.Lanches.Models.Entity
{
    public class LanchePredefinido : Entity<LanchePredefinido>
    {
        public Guid LancheId { get; private set; }
        public Guid IngredienteId { get; private set; }

        public virtual Lanche Lanche { get; private set; }
        public virtual Ingrediente Ingrediente { get; private set; }

        // Culpa do EF
        protected LanchePredefinido() { }

        public LanchePredefinido(Guid lancheId, 
                                 Guid ingredienteId)
        {
            LancheId = lancheId;
            IngredienteId = ingredienteId;
        }

        // Validações
        public override bool IsValid()
        {
            return true;
        }
    }
}
