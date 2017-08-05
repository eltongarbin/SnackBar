using SnackBar.Domain.Pedidos.Models.Entity;

namespace SnackBar.Domain.Pedidos.Models.Logic.Desconto
{
    public class SemDesconto : Desconto
    {
        public override void AplicarDesconto(PedidoLanche pedidoLanche)
        {
            pedidoLanche.IncluirPromocao(string.Empty, 0);
        }
    }
}