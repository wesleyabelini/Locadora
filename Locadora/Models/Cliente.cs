using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Locadora.Models
{
    public class Cliente
    {
        [Key]
        public int ID { get; set; }

        [Display(Name="Nome")]
        public string Nome { get; set; }

        public virtual ICollection<Locacao> Locacao { get; set; }
    }
}