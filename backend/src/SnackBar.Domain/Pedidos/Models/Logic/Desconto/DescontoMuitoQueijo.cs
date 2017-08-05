using System.Linq;
using SnackBar.Domain.Pedidos.Models.Entity;

namespace SnackBar.Domain.Pedidos.Models.Logic.Desconto
{
    public class DescontoMuitoQueijo : Desconto
    {
        public override void AplicarDesconto(PedidoLanche pedidoLanche)
        {
            if (!string.IsNullOrEmpty(pedidoLanche.Promocao))
            {
                Proximo.AplicarDesconto(pedidoLanche);
                return;
            }

            var ingredientesQueijo = pedidoLanche.LanchesCustomizados
                                                .Where(lc => lc.Ingrediente.Nome.ToLower() == "queijo")
                                                .Select(lc => lc.Ingrediente);

            var qtQueijo = ingredientesQueijo.Count();
            if (qtQueijo > 0 && qtQueijo % 3 == 0)
            {
                var qtPagar = (qtQueijo / 3) * 2;
                var qtDesconto = qtQueijo - qtPagar;
                var valorDesconto = ingredientesQueijo.Take(qtDesconto)
                                                      .Sum(i => i.Valor);

                pedidoLanche.IncluirPromocao("Muito Queijo", valorDesconto);
                return;
            }

            Proximo.AplicarDesconto(pedidoLanche);
        }
    }
}