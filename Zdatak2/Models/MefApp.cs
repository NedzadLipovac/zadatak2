using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.Composition;
using System.Composition.Hosting;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;

namespace Zdatak2.Models
{
    public class MefApp
    {
        private CompositionContainer _container;

        [Import]
        protected Ilogger Logger { get; set; }

        internal decimal Run(decimal cijena,decimal stopaPoreza)
        {
            compose();
            return Logger.calculate(cijena,stopaPoreza);
        }

        private void compose()
        {
            var catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(MefApp).Assembly));

            catalog.Catalogs.Add(new DirectoryCatalog("E:\\V2017\\Projects\\Zdatak2\\Zdatak2\\Extensions"));


            this._container = new CompositionContainer(catalog);

            try
            {
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {

                Debug.WriteLine(compositionException.ToString());
            }
        }
    }
}