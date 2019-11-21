using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zdatak2.ViewModels.Stavke
{
    public class StavkeAddVM
    {
        [Required]
        public string Opis { get; set; }
        [Required]
        [Range(0.1,int.MaxValue)]
        public decimal Cijena { get; set; }
    }
}