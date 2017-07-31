using SnackBar.Domain.Core.Models;
using SnackBar.Domain.Lanches.Models.Entity;
using SnackBar.Domain.Pedidos.Models;
using System;
using System.Collections.Generic;

namespace SnackBar.Domain.Lanches
{
    public class Lanche : Entity<Lanche>
    {
        public string Nome { get; private set; }

        public ICollection<LanchePredefinido> LanchesPredefinidos { get; private set; }
        public ICollection<PedidoLanche> PedidosLanches { get; private set; }

        // Culpa do EF
        protected Lanche() { }

        public Lanche(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
