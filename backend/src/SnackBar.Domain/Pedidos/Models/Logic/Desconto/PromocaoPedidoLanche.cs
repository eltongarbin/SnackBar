using SnackBar.Domain.Pedidos.Models.Entity;

namespace SnackBar.Domain.Pedidos.Models.Logic.Desconto
{
    public class PromocaoPedidoLanche
    {
        public string Descricao { get; private set; }
        public decimal Desconto { get; private set; }

        public static class PromocaoPedidoLancheFactory
        {
            public static PromocaoPedidoLanche Calcular(PedidoLanche pedidoLanche)
            {
                pedidoLanche.CalcularValorTotal();

                Desconto d1 = new DescontoLight();
                Desconto d2 = new DescontoMuitaCarne();
                Desconto d3 = new DescontoMuitoQueijo();
                Desconto d4 = new SemDesconto();

                d1.SetarProximo(d2);
                d2.SetarProximo(d3);
                d3.SetarProximo(d4);

                d1.AplicarDesconto(pedidoLanche);

                return new PromocaoPedidoLanche
                {
                    Descricao = pedidoLanche.Promocao,
                    Desconto = pedidoLanche.Desconto
                };
            }
        }
    }
}
