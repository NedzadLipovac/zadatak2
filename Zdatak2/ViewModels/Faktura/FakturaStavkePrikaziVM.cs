using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zdatak2.ViewModels.Faktura
{
    public class FakturaStavkePrikaziVM
    {
        public int FakturaId { get; set; }
        public List<Row> rows { get; set; }

        public class Row
        {
            public int StavkaId { get; set; }
            public int FakturaStavkaId { get; set; }
            public decimal Cijena { get; set; }
            public string Opis { get; set; }
            public int Kolicina { get; set; }
            public decimal UkupnaCijenaStavke { get; set; }
        }
    }
}