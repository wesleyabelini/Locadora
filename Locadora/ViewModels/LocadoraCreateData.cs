using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locadora.ViewModels
{
    public class LocadoraCreateData
    {
        public ICollection<Filme> Filme { get; set; }
        public ICollection<Cliente> Cliente { get; set; }
        public ICollection<Locacao> Locacao { get; set; }
    }
}