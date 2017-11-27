using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Locadora.Models
{
    public class LocadoraContext:DbContext
    {
        public System.Data.Entity.DbSet<Locadora.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<Locadora.Models.Filme> Filmes { get; set; }

        public System.Data.Entity.DbSet<Locadora.Models.Genero> Generoes { get; set; }

        public System.Data.Entity.DbSet<Locadora.Models.Locacao> Locacaos { get; set; }
    }
}