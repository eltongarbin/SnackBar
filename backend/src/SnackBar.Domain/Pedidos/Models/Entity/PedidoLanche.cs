using SnackBar.Domain.Core.Models;
using SnackBar.Domain.Lanches;
using System;
using System.Collections.Generic;
using FluentValidation;

namespace SnackBar.Domain.Pedidos.Models.Entity
{
    public class PedidoLanche : Entity<PedidoLanche>
    {
        public Guid PedidoId { get; private set; }
        public Guid LancheId { get; private set; }
        public decimal Valor { get; private set; }

        public virtual Pedido Pedido { get; private set; }
        public virtual Lanche Lanche { get; private set; }

        public virtual ICollection<LancheCustomizado> LanchesCustomizados { get; set; }

        // Culpa do EF
        protected PedidoLanche() { }

        public PedidoLanche(Guid id,
                            Guid pedidoId,
                            Guid lancheId,
                            ICollection<LancheCustomizado> lanchesCustomizados)
        {
            Id = id;
            PedidoId = pedidoId;
            LancheId = lancheId;
            LanchesCustomizados = lanchesCustomizados;
        }

        // Validações
        public override bool IsValid()
        {
            RuleFor(e => e.LanchesCustomizados)
                .NotNull()
                .Must(e => e.Count > 0)
                .WithMessage("Precisa ser fornecido a composição do lanche.");

            ValidationResult = Validate(this);

            foreach (var pedidoLanche in LanchesCustomizados)
            {
                foreach (var error in pedidoLanche.ValidationResult.Errors)
                {
                    ValidationResult.Errors.Add(error);
                }
            }

            return ValidationResult.IsValid;
        }

        public static class PedidoLancheFactory
        {
            public static PedidoLanche Criar(Guid pedidoId,
                                             Guid lancheId)
            {
                var pedidoLanche = new PedidoLanche()
                {
                    Id = Guid.NewGuid(),
                    PedidoId = pedidoId,
                    LancheId = lancheId,
                    LanchesCustomizados = new List<LancheCustomizado>()
                };

                return pedidoLanche;
            }

            public static PedidoLanche Criar(Pedido pedido,
                                             Lanche lanche)
            {
                var pedidoLanche = new PedidoLanche()
                {
                    Id = Guid.NewGuid(),
                    PedidoId = pedido.Id,
                    LancheId = lanche.Id,
                    Pedido = pedido,
                    Lanche = lanche,
                    LanchesCustomizados = new List<LancheCustomizado>()
                };

                return pedidoLanche;
            }
        }
    }
}
