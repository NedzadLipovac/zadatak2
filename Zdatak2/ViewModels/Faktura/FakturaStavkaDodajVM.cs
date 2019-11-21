using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zdatak2.ViewModels.Faktura
{
    public class FakturaStavkaDodajVM
    {
        public int FakturaId { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int Kolicina { get; set; }
        [Required]
        public int StavkaId { get; set; }
       
        public List<SelectListItem> stavke { get; set; }

    }
}