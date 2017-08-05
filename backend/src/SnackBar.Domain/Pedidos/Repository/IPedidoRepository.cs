using SnackBar.Domain.Ingredientes;
using SnackBar.Domain.Interfaces;
using SnackBar.Domain.Lanches;
using System;
using System.Collections.Generic;

namespace SnackBar.Domain.Pedidos.Repository
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        IEnumerable<Ingrediente> ObterIngredientes();
        IEnumerable<Lanche> ObterLanchesCardapio();
        Lanche ObterLancheCardapioPorId(Guid id);
        Ingrediente ObterIngredientePorId(Guid id);
    }
}