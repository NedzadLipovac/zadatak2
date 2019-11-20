using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zdatak2.Models
{
    public class Faktura
    {
        [Key]
        public int FakturaId { get; set; }

        public string BrFakture { get; set; }
        public DateTime DatumStvaranja { get; set; }
        public DateTime DatumDospijeca { get; set; }
        public decimal UkupnaCijenaBezPoreza { get; set; }
        public decimal UkupnaCijenaSaporezom { get; set; }
        public string PrimateljRacuna { get; set; }

        public string StvarateljRacuna_Id { get; set; }
        [ForeignKey("StvarateljRacuna_Id")]
        public ApplicationUser StvarateljRacuna { get; set; }

        public int tipPorezaId { get; set; }
        [ForeignKey("tipPorezaId")]
        public TipPoreza TipPoreza { get; set; }


    }
}