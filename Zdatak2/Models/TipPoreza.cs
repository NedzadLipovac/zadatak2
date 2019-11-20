using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zdatak2.Models
{
    public class TipPoreza
    {
        [Key]
        public int tipPorezaId { get; set; }

        public decimal iznos { get; set; }

        public string naziv { get; set; }
    }
}