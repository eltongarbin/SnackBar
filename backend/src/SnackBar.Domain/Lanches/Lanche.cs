using FluentValidation;
using SnackBar.Domain.Core.Models;
using SnackBar.Domain.Lanches.Models.Entity;
using SnackBar.Domain.Pedidos.Models.Entity;
using System;
using System.Collections.Generic;

namespace SnackBar.Domain.Lanches
{
    public class Lanche : Entity<Lanche>
    {
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }

        public ICollection<LanchePredefinido> LanchesPredefinidos { get; set; }
        public ICollection<PedidoLanche> PedidosLanches { get; set; }

        // Culpa do EF
        protected Lanche() { }

        public Lanche(Guid id,
                      string nome,
                      decimal valor)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
        }

        // Validações
        public override bool IsValid()
        {
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage("O nome do lanche precisa ser fornecido.")
                .MaximumLength(20).WithMessage("O nome do lanche precisa ter até 20 caracteres.");

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
