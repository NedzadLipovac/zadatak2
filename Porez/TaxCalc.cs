using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Composition.Hosting;
using System.ComponentModel.Composition.Hosting;
namespace Porez
{
    [Export(typeof(Zdatak2.Models.Ilogger))]
    internal class TaxCalc : Zdatak2.Models.Ilogger
    {
        public decimal calculate(decimal cijena, decimal stopaPoreza)
        {
           return cijena* stopaPoreza;
        }
    }
}
