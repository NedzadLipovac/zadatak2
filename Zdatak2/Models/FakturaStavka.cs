using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zdatak2.Models
{
    public class FakturaStavka
    {
        [Key]
        public int Id { get; set; }

        public int FakturaId { get; set; }
        [ForeignKey("FakturaId")]
        public Faktura Faktura { get; set; }

        public int StavkaId { get; set; }
        [ForeignKey("StavkaId")]
        public Stavka Stavka { get; set; }

        public int Kolicina { get; set; }

    }
}