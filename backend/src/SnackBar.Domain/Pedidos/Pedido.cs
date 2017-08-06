using FluentValidation;
using SnackBar.Domain.Core.Models;
using SnackBar.Domain.Pedidos.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnackBar.Domain.Pedidos
{
    public class Pedido : Entity<Pedido>
    {
        public string Cliente { get; private set; }
        public DateTime DataPedido { get; private set; }
        public DateTime? DataEntrega { get; private set; }
        public DateTime? DataCancelamento { get; private set; }
        public decimal ValorTotal { get; private set; }

        public virtual ICollection<PedidoLanche> PedidosLanches { get; set; }

        // Culpa do EF
        protected Pedido() { }

        public Pedido(Guid id,
                      DateTime dataPedido,
                      string cliente,
                      ICollection<PedidoLanche> pedidosLanches)
        {
            Id = id;
            DataPedido = dataPedido;
            Cliente = cliente;
            PedidosLanches = pedidosLanches;
        }

        public void CalcularValorTotal()
        {
            ValorTotal = PedidosLanches.Sum(pl => pl.ValorTotal);
        }

        public string ObterStatus()
        {
            if (DataCancelamento.HasValue)
                return "CANCELADO";
            if (DataEntrega.HasValue)
                return "ENTREGUE";

            return "EM ANDAMENTO";
        }

        public DateTime ObterDataStatus()
        {
            if (DataCancelamento.HasValue)
                return (DateTime)DataCancelamento;
            if (DataEntrega.HasValue)
                return (DateTime)DataEntrega;

            return DataPedido;
        }

        // Validações
        public override bool IsValid()
        {
            RuleFor(e => e.Cliente)
                .NotEmpty().WithMessage("O nome do cliente precisa ser fornecido.")
                .Length(4, 150).WithMessage("O nome do cliente precisa ter entre 4 e 150 caracteres.");

            RuleFor(e => e.PedidosLanches)
                .NotNull()
                .Must(e => e.Count > 0)
                .WithMessage("Precisa ser fornecido ao menos um lanche para o pedido.");

            ValidationResult = Validate(this);

            ValidarPedidosLanches();

            return ValidationResult.IsValid;
        }

        private void ValidarPedidosLanches()
        {
            foreach (var pedidoLanche in PedidosLanches)
            {
                if (pedidoLanche.IsValid())
                    continue;

                foreach (var error in pedidoLanche.ValidationResult.Errors)
                {
                    ValidationResult.Errors.Add(error);
                }
            }

        }

        public static class PedidoFactory
        {
            public static Pedido Criar(string cliente)
            {
                var pedido = new Pedido()
                {
                    Id = Guid.NewGuid(),
                    Cliente = cliente,
                    DataPedido = DateTime.Now,
                    PedidosLanches = new List<PedidoLanche>()
                };

                return pedido;
            }
        }
    }
}
