using SnackBar.Domain.Pedidos.Models.Entity;

namespace SnackBar.Domain.Pedidos.Models.Logic.Desconto
{
    public abstract class Desconto
    {
        protected Desconto Proximo;

        public void SetarProximo(Desconto proximo)
        {
            Proximo = proximo;
        }

        public abstract void AplicarDesconto(PedidoLanche pedidoLanche);
    }
}