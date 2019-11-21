using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zdatak2.Models;

namespace Zdatak2.ViewModels.Faktura
{
    public class FakturaDodajVM
    {
        public int FakturaId { get; set; }

        public string Stvaratelj_id{ get; set; }
        [Required]
        public string BrFakture { get; set; }
        [Required]
        public DateTime DatumStvaranja { get; set; }
        [Required]
        public DateTime DatumDospijeca { get; set; }
        [Required]
        public List<SelectListItem> tipPoreza { get; set; }
        [Required]
        public int tipPorezaId { get; set; }

        public decimal UkupnaCijenaBezPoreza { get; set; }
        public decimal UkupnaCijenaSaporezom { get; set; }
        public string PrimateljRacuna { get; set; }
    }
}