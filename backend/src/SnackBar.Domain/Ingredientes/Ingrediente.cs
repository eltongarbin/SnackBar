using FluentValidation;
using SnackBar.Domain.Core.Models;
using SnackBar.Domain.Lanches.Models.Entity;
using SnackBar.Domain.Pedidos.Models.Entity;
using System;
using System.Collections.Generic;

namespace SnackBar.Domain.Ingredientes
{
    public class Ingrediente : Entity<Ingrediente>
    {
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }

        public virtual ICollection<LanchePredefinido> LanchesPredefinidos { get; private set; }
        public virtual ICollection<LancheCustomizado> LanchesCustomizados { get; private set; }

        // Culpa do EF
        protected Ingrediente() { }

        public Ingrediente(string nome,
                           decimal valor)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Valor = valor;
        }

        // Validações
        public override bool IsValid()
        {
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage("O nome do ingrediente precisa ser fornecido.")
                .MaximumLength(50).WithMessage("O nome do ingrediente precisa ter até 50 caracteres.");

            RuleFor(e => e.Valor)
                .GreaterThan(0).WithMessage("O valor do ingrediente precisa ser fornecido e maior que zero.");

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
