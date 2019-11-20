using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zdatak2.Models;

namespace Zdatak2.ViewModels.Faktura
{
    public class FakturaPrikaziVM
    {
        public ApplicationUser Stvaratelj { get; set; }
        public List<Row> rows { get; set; }

     
    }

    public class Row
    {
        public int FakturaId { get; set; }
        public string BrFakture { get; set; }
        public DateTime DatumStvaranja { get; set; }
        public DateTime DatumDospijeca { get; set; }

    }
}