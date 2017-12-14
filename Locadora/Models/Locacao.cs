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
        public int LocacaoID { get; set; }

        [Display(Name ="ID Cliente")]
        public int ClienteID { get; set; }

        [Display(Name ="ID Filme")]
        public int FilmeID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        [Display(Name ="Data Locação")]
        public DateTime DateLocacao { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Locação")]
        public DateTime DateEntrega { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Filme> Filme { get; set; }
    }
}