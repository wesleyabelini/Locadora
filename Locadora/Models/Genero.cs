using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Locadora.Models
{
    public class Genero
    {
        [Key]
        public int GeneroID { get; set; }

        [Display(Name ="Nome")]
        public string Nome { get; set; }

        public virtual ICollection<Filme> Filme { get; set; }
    }
}