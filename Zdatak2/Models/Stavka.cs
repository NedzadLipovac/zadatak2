using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zdatak2.Models
{
    public class Stavka
    {
        [Key]
        public int StavkaId { get; set; }

        public string Opis { get; set; }
        public decimal Cijena { get; set; }
    }
}