using Dapper;
using Microsoft.EntityFrameworkCore;
using SnackBar.Domain.Ingredientes;
using SnackBar.Domain.Lanches;
using SnackBar.Domain.Lanches.Models.Entity;
using SnackBar.Domain.Pedidos;
using SnackBar.Domain.Pedidos.Repository;
using SnackBar.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using SnackBar.Domain.Pedidos.Models.Entity;

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

        public IEnumerable<Lanche> ObterLanchesCardapio()
        {
            var sql = @"SELECT Lanches.*,
                               Ingredientes.*
                        FROM Lanches
                             INNER JOIN LanchesPredefinidos
                             ON LanchesPredefinidos.LancheId = Lanches.Id
                             INNER JOIN Ingredientes
                             ON Ingredientes.Id = LanchesPredefinidos.IngredienteId";

            var lookup = new Dictionary<Guid, Lanche>();

            Db.Database.GetDbConnection().Query<Lanche, Ingrediente, Lanche>(
                sql,
                (l, i) =>
                {
                    Lanche lanche;

                    if (!lookup.TryGetValue(l.Id, out lanche))
                        lookup.Add(l.Id, lanche = l);

                    if (lanche.LanchesPredefinidos == null)
                        lanche.LanchesPredefinidos = new List<LanchePredefinido>();

                    lanche.LanchesPredefinidos.Add(new LanchePredefinido(lanche, i));

                    return lanche;
                }
            ).AsQueryable();

            return lookup.Values.ToList();
        }

        public Lanche ObterLancheCardapioPorId(Guid id)
        {
            var sql = @"SELECT Lanches.*,
                               Ingredientes.*
                        FROM Lanches
                             INNER JOIN LanchesPredefinidos
                             ON LanchesPredefinidos.LancheId = Lanches.Id
                             INNER JOIN Ingredientes
                             ON Ingredientes.Id = LanchesPredefinidos.IngredienteId
                        WHERE Lanches.Id = @uid";

            var lanche = Db.Database.GetDbConnection().Query<Lanche, Ingrediente, Lanche>(sql,
                (l, i) =>
                {
                    if (l.LanchesPredefinidos == null)
                        l.LanchesPredefinidos = new List<LanchePredefinido>();

                    l.LanchesPredefinidos.Add(new LanchePredefinido(l, i));

                    return l;
                },
                new { uid = id }
            ).AsQueryable();

            return lanche.FirstOrDefault();
        }

        public Ingrediente ObterIngredientePorId(Guid id)
        {
            var sql = @"SELECT * FROM Ingredientes 
                        WHERE Id = @uid";

            var ingrediente = Db.Database.GetDbConnection().Query<Ingrediente>(sql, new { uid = id });

            return ingrediente.SingleOrDefault();
        }

        public override IEnumerable<Pedido> ObterTodos()
        {
            var sql = @"SELECT Pedidos.*,
                               Lanches.*
                        FROM Pedidos
                             INNER JOIN PedidosLanches
                             ON PedidosLanches.PedidoId = Pedidos.Id
                             INNER JOIN Lanches
                             ON Lanches.Id = PedidosLanches.LancheId";

            var lookup = new Dictionary<Guid, Pedido>();

            Db.Database.GetDbConnection().Query<Pedido, Lanche, Pedido>(
                sql,
                (p, l) =>
                {
                    Pedido pedido;

                    if (!lookup.TryGetValue(p.Id, out pedido))
                        lookup.Add(p.Id, pedido = p);

                    if (pedido.PedidosLanches == null)
                        pedido.PedidosLanches = new List<PedidoLanche>();

                    pedido.PedidosLanches.Add(PedidoLanche.PedidoLancheFactory.Criar(pedido, l));

                    return pedido;
                }
            ).AsQueryable();

            return lookup.Values.ToList();
        }

        public override Pedido ObterPorId(Guid id)
        {
            var pedido = DbSet.AsNoTracking()
                                .Include(p => p.PedidosLanches)
                                    .ThenInclude(l => l.Lanche)
                                .Include(p => p.PedidosLanches)
                                    .ThenInclude(pl => pl.LanchesCustomizados)
                                    .ThenInclude(lc => lc.Ingrediente)
                                .FirstOrDefault(t => t.Id == id);

            return pedido;
        }
    }
}