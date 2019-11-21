using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zdatak2.Models;

namespace Zdatak2.ViewModels.Stavke
{
    public class StavkeIndexVM
    {
  
        public List<Row> rows { get; set; }

    }
    public class Row
    {

        public string Opis { get; set; }
        public decimal Cijena { get; set; }
    }
}