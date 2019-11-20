using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdatak2.Models
{
    public interface Ilogger
    {
        decimal calculate(decimal cijena, decimal stopaPoreza);
    }
}
