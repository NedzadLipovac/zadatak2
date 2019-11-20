using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zdatak2.Models;
using Zdatak2.ViewModels.Faktura;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
namespace Zdatak2.Controllers
{
    [Authorize]
    public class FakturaController : Controller
    {
        protected ApplicationDbContext db { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public FakturaController()
        {
            this.db = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.db));
        }

        // GET: Faktura
        public ActionResult Index()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            FakturaPrikaziVM model = new FakturaPrikaziVM();
            model.Stvaratelj = new ApplicationUser();
            model.Stvaratelj = user;
            model.Stvaratelj.Id = user.Id;
            model.Stvaratelj.UserName = user.UserName;
            model.rows = db.Faktura
                .Select(x => new Row()
                {
                    BrFakture = x.BrFakture,
                    DatumDospijeca = x.DatumDospijeca,
                    DatumStvaranja = x.DatumStvaranja,
                    FakturaId = x.FakturaId
                }).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());

            FakturaDodajVM model = new FakturaDodajVM();
            model.tipPoreza = db.TipPoreza.Select(x => new SelectListItem()
            {
                Text = x.naziv+"-"+x.iznos+" %",
                Value = x.tipPorezaId.ToString()
            }).ToList();
            model.Stvaratelj_id = user.Id;

            return View(model);
        }
        public ActionResult Save(FakturaDodajVM model)
        {
            Faktura faktura = new Faktura();
            faktura.BrFakture = model.BrFakture;
            faktura.DatumDospijeca = model.DatumDospijeca;
            faktura.DatumStvaranja = model.DatumStvaranja;
            faktura.PrimateljRacuna = model.PrimateljRacuna;
            faktura.tipPorezaId = model.tipPorezaId;
            faktura.StvarateljRacuna_Id = model.Stvaratelj_id;
            faktura.UkupnaCijenaBezPoreza = 0;
            faktura.UkupnaCijenaSaporezom = 0;
            db.Faktura.Add(faktura);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public ActionResult Edit(int FakturaId)
        {
            FakturaUrediVM model = new FakturaUrediVM();
            model.FakturaId = FakturaId;
            model.BrFakture = db.Faktura.Where(x => x.FakturaId == FakturaId).FirstOrDefault().BrFakture;
            model.DatumStvaranja = db.Faktura.Where(x => x.FakturaId == FakturaId).FirstOrDefault().DatumStvaranja;
            model.DatumDospijeca = db.Faktura.Where(x => x.FakturaId == FakturaId).FirstOrDefault().DatumDospijeca;
            model.UkupnaCijenaBezPoreza = db.Faktura.Where(x => x.FakturaId == FakturaId).FirstOrDefault().UkupnaCijenaBezPoreza;
            model.UkupnaCijenaSaporezom = db.Faktura.Where(x => x.FakturaId == FakturaId).FirstOrDefault().UkupnaCijenaSaporezom;
            model.PrimateljRacuna = db.Faktura.Where(x => x.FakturaId == FakturaId).FirstOrDefault().PrimateljRacuna;
            return View(model);
        }

        public ActionResult PrikaziStavkeFakture(int FakturaId)
        {
            FakturaStavkePrikaziVM model = new FakturaStavkePrikaziVM();
            model.FakturaId = FakturaId;
            model.rows = db.FakturaStavka
                      .Include(x => x.Faktura)
                      .Include(y => y.Stavka)
                      .Where(x => x.FakturaId == FakturaId)
                      .Select(x => new FakturaStavkePrikaziVM.Row()
                      {
                           Cijena=x.Stavka.Cijena,
                            Kolicina=x.Kolicina,
                             Opis=x.Stavka.Opis,
                              FakturaStavkaId=x.Id,
                               StavkaId=x.StavkaId,
                                UkupnaCijenaStavke=x.Kolicina*x.Stavka.Cijena
                      }).ToList();
           
            return PartialView(model);
        }
        public  ActionResult DodajStavku(int FakturaId)
        {
            FakturaStavkaDodajVM model = new FakturaStavkaDodajVM();
            model.FakturaId = FakturaId;
            model.stavke = db.Stavka.Select(x => new SelectListItem()
            {
                Text = x.Opis,
                Value = x.StavkaId.ToString()
            }).ToList();
            return PartialView(model);
        }
        public ActionResult SnimiStavku(FakturaStavkaDodajVM model)
        {
            FakturaStavka fs = new FakturaStavka();
            fs.FakturaId = model.FakturaId;
            fs.Kolicina = model.Kolicina;
            var stavka = db.Stavka.Where(x => x.StavkaId == model.StavkaId).FirstOrDefault();
            fs.StavkaId = stavka.StavkaId;
            fs.Kolicina = model.Kolicina;

            db.FakturaStavka.Add(fs);
            db.SaveChanges();
            return RedirectToAction(nameof(IzracunajUkupnuCijenu), new { FakturaId = model.FakturaId });
        }
        public ActionResult IzracunajUkupnuCijenu(int FakturaId)
        {
            MefApp obj = new MefApp();
            List<FakturaStavka> stavke = db.FakturaStavka
                                       .Include(x => x.Stavka)
                                       .Where(x => x.FakturaId == FakturaId).ToList();
            var suma = new decimal(0);
            foreach (var item in stavke)
            {
                suma += Convert.ToDecimal(item.Kolicina) * item.Stavka.Cijena;
            }
            Faktura f = db.Faktura.Where(x => x.FakturaId == FakturaId).Include(x=>x.TipPoreza).FirstOrDefault();
            f.UkupnaCijenaBezPoreza = suma;

            var porez=obj.Run(f.UkupnaCijenaBezPoreza, f.TipPoreza.iznos);
            f.UkupnaCijenaSaporezom = porez + f.UkupnaCijenaBezPoreza;

            db.SaveChanges();
           return RedirectToAction(nameof(Edit), new { FakturaId = FakturaId });
        }
    }
}