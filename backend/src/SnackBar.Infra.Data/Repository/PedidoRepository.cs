using Dapper;
using Microsoft.EntityFrameworkCore;
using SnackBar.Domain.Ingredientes;
using SnackBar.Domain.Pedidos;
using SnackBar.Domain.Pedidos.Repository;
using SnackBar.Infra.Data.Context;
using System.Collections.Generic;

namespace SnackBar.Infra.Data.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(SnackBarContext context)
            : base(context) { }

        public IEnumerable<Ingrediente> ObterIngredientes()
        {
            return Db.Database.GetDbConnection().Query<Ingrediente>("SELECT * FROM Ingredientes");
        }
    }
}