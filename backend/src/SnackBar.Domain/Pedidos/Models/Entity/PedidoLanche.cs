using SnackBar.Domain.Core.Models;
using SnackBar.Domain.Lanches;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace SnackBar.Domain.Pedidos.Models.Entity
{
    public class PedidoLanche : Entity<PedidoLanche>
    {
        public Guid PedidoId { get; private set; }
        public Guid LancheId { get; private set; }
        public decimal ValorTotal { get; private set; }
        public string Promocao { get; private set; }
        public decimal Desconto { get; private set; }

        public virtual Pedido Pedido { get; private set; }
        public virtual Lanche Lanche { get; private set; }

        public virtual ICollection<LancheCustomizado> LanchesCustomizados { get; set; }

        // Culpa do EF
        protected PedidoLanche() { }

        public void IncluirPromocao(string promocao,
                                    decimal desconto)
        {
            Promocao = promocao;
            Desconto = desconto;

            CalcularValorTotal();
        }

        public void CalcularValorTotal()
        {
            ValorTotal = LanchesCustomizados.Select(lc => lc.Ingrediente).Sum(i => i.Valor) + Desconto;
        }

        public void CalcularValorTotal(decimal valorSemDesconto,
                                       string promocao,
                                       decimal desconto)
        {
            ValorTotal = valorSemDesconto - desconto;
            Promocao = promocao;
            Desconto = desconto;
        }

        // Validações
        public override bool IsValid()
        {
            RuleFor(e => e.LanchesCustomizados)
                .NotNull()
                .Must(e => e.Count > 0)
                .WithMessage("Precisa ser fornecido a composição do lanche.");

            RuleFor(e => e.Promocao)
                .MaximumLength(20).WithMessage("O nome da promoção precisa ter no máximo 20 caracteres.");

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
