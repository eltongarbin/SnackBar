using System.Linq;
using SnackBar.Domain.Pedidos.Models.Entity;

namespace SnackBar.Domain.Pedidos.Models.Logic.Desconto
{
    public class DescontoMuitaCarne : Desconto
    {
        public override void AplicarDesconto(PedidoLanche pedidoLanche)
        {
            if (!string.IsNullOrEmpty(pedidoLanche.Promocao))
            {
                Proximo.AplicarDesconto(pedidoLanche);
                return;
            }

            var ingredientesCarne = pedidoLanche.LanchesCustomizados
                                                .Where(lc => lc.Ingrediente.Nome.ToLower() == "hambúrguer de carne")
                                                .Select(lc => lc.Ingrediente);

            var qtCarne = ingredientesCarne.Count();
            if (qtCarne > 0 && qtCarne % 3 == 0)
            {
                var qtPagar = (qtCarne / 3) * 2;
                var qtDesconto = qtCarne - qtPagar;
                var valorDesconto = ingredientesCarne.Take(qtDesconto)
                                                     .Sum(i => i.Valor);

                pedidoLanche.IncluirPromocao("Muita carne", valorDesconto);
                return;
            }

            Proximo.AplicarDesconto(pedidoLanche);
        }
    }
}