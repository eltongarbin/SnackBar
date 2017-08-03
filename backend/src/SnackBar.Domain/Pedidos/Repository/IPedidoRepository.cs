using SnackBar.Domain.Ingredientes;
using SnackBar.Domain.Interfaces;
using System.Collections.Generic;

namespace SnackBar.Domain.Pedidos.Repository
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        IEnumerable<Ingrediente> ObterIngredientes();
    }
}