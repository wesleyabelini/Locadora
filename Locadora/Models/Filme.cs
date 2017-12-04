using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Locadora.Models
{
    public class Filme
    {
        [Key]
        public int FilmeID { get; set; }

        [Display(Name ="Nome")]
        public string Nome { get; set; }

        [Display(Name ="ID Genero")]
        public int GeneroID { get; set; }

        [Display(Name ="Locado")]
        public bool isLocated { get; set; }

        public virtual Genero Genero { get; set; }
        public virtual ICollection<Locacao> Locacao { get; set; }
    }
}