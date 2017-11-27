using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Locadora.Models
{
    public class Filme
    {
        public Filme()
        {
            GetGenero = new HashSet<Genero>();
        }

        [Key]
        public int IdFilme { get; set; }
        public string Nome { get; set; }
        public int IdGenero { get; set; }

        public bool isLocated { get; set; }

        public ICollection<Genero> GetGenero { get; set; }
    }
}