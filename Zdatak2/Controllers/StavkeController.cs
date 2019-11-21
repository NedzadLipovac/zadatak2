using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zdatak2.Models;
using Zdatak2.ViewModels.Stavke;

namespace Zdatak2.Controllers
{
    [Authorize]
    public class StavkeController : Controller
    {
        protected ApplicationDbContext db { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public StavkeController()
        {
            this.db = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.db));
        }
        // GET: Stavke
        public ActionResult Index()
        {
         
            StavkeIndexVM model = new StavkeIndexVM();
            model.rows = db.Stavka.Select(x => new Row
            {
                 Cijena=x.Cijena,
                 Opis=x.Opis
            }).ToList();
            
            return View(model);
        }
        public ActionResult Add()
        {
            StavkeAddVM model = new StavkeAddVM();

            return View(model);
        }
     
        public ActionResult Save(StavkeAddVM model)
        {
            Stavka s = new Stavka();
            s.Opis = model.Opis;
            s.Cijena = model.Cijena;
            db.Stavka.Add(s);
            db.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

    }
}