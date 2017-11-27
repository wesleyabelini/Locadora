using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Locadora.Models
{
    public class Locacao
    {
        [Key]
        public int IdLocacao { get; set; }
        public int IdCliente { get; set; }
        public int IdFilme { get; set; }
        public DateTime DateLocacao { get; set; }
        public DateTime DateEntrega { get; set; }

        public List<Cliente> GetCliente { get; set; }
        public List<Filme> GetFilme { get; set; }
    }
}