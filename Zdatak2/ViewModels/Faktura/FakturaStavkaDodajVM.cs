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
        public int Kolicina { get; set; }
        [Required]
        public int StavkaId { get; set; }
        [Required]
        public List<SelectListItem> stavke { get; set; }

    }
}