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
        public int IdGenero { get; set; }
        public string Nome { get; set; }
    }
}