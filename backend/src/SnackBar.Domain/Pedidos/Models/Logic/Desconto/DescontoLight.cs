using System.Linq;
using SnackBar.Domain.Pedidos.Models.Entity;

namespace SnackBar.Domain.Pedidos.Models.Logic.Desconto
{
    public class DescontoLight : Desconto
    {
        public override void AplicarDesconto(PedidoLanche pedidoLanche)
        {
            if (!string.IsNullOrEmpty(pedidoLanche.Promocao))
            {
                Proximo.AplicarDesconto(pedidoLanche);
                return;
            }

            var contemAlface = pedidoLanche.LanchesCustomizados.Any(lc => lc.Ingrediente.Nome.ToLower() == "alface");
            var contemBacon = pedidoLanche.LanchesCustomizados.Any(lc => lc.Ingrediente.Nome.ToLower() == "bacon");

            if (contemAlface && !contemBacon)
            {
                pedidoLanche.IncluirPromocao("Light", pedidoLanche.ValorTotal * 0.1M);
                return;
            }

            Proximo.AplicarDesconto(pedidoLanche);
        }
    }
}