using FluentValidation.Results;
using SnackBar.Domain.Core.Models;
using SnackBar.Domain.Pedidos.Models;
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
        public decimal Valor { get; private set; }

        public virtual ICollection<PedidoLanche> PedidosLanches { get; private set; }

        // Culpa do EF
        protected Pedido() { }

        public Pedido(string cliente,
                      ICollection<PedidoLanche> pedidoLanches)
        {
            Id = Guid.NewGuid();
            DataPedido = DateTime.Now;
            Cliente = cliente;
            PedidosLanches = pedidoLanches;
        }

        public void RealizarPedidoLanche(PedidoLanche pedidoLanche)
        {
            if (!pedidoLanche.IsValid())
            {
                foreach (var error in pedidoLanche.ValidationResult.Errors)
                {
                    ValidationResult.Errors.Add(error);
                }
            }
                
            PedidosLanches.Add(pedidoLanche);
        }

        public void ExcluirPedidoLanche(Guid pedidoLancheId)
        {
            if (PedidosLanches.All(x => x.Id != pedidoLancheId))
                ValidationResult.Errors.Add(new ValidationFailure("ExcluirPedidoLanche", "Pedido a ser removido não localizado."));

            var pedidoLanche = PedidosLanches.Single(x => x.Id == pedidoLancheId);

            PedidosLanches.Remove(pedidoLanche);
        }

        public void AtualizarPedidoLanche(PedidoLanche pedidoLanche)
        {
            if (!pedidoLanche.IsValid())
            {
                foreach (var error in pedidoLanche.ValidationResult.Errors)
                {
                    ValidationResult.Errors.Add(error);
                }
            }

            ExcluirPedidoLanche(pedidoLanche.Id);
            RealizarPedidoLanche(pedidoLanche);
        }

        public void EntregarPedido()
        {
            DataEntrega = DateTime.Now;
        }

        public void CancelarPedido()
        {
            DataCancelamento = DateTime.Now;
        }

        // Validações
        public override bool IsValid()
        {
            return true;
        }

        public static class PedidoFactory
        {
            public static Pedido CriarPedido(Guid id,
                                             string cliente,
                                             ICollection<PedidoLanche> pedidoLanches)
            {
                return CriarPedido(id, cliente, DateTime.Now, null, null, pedidoLanches);
            }

            public static Pedido CriarPedido(Guid id,
                                             string cliente,
                                             DateTime dataPedido,
                                             DateTime? dataEntrega,
                                             DateTime? dataCancelamento,
                                             ICollection<PedidoLanche> pedidoLanches)
            {
                var pedido = new Pedido()
                {
                    Id = id,
                    Cliente = cliente,
                    DataPedido = dataPedido,
                    PedidosLanches = pedidoLanches
                };

                if (dataEntrega.HasValue)
                    pedido.DataEntrega = dataEntrega;

                if (dataCancelamento.HasValue)
                    pedido.DataCancelamento = dataCancelamento;

                return pedido;
            }
        }
    }
}
