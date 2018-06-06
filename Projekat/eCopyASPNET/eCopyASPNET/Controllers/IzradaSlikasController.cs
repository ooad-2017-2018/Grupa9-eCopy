using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eCopyASPNET.Models;

namespace eCopyASPNET.Controllers
{
    public class IzradaSlikasController : Controller
    {
        private OOADContext db = new OOADContext();

        // GET: IzradaSlikas
        public ActionResult Index()
        {
            var izradaSlika = db.IzradaSlika.Include(i => i.Racun).Include(i => i.Radnik);
            return View(izradaSlika.ToList());
        }

        // GET: IzradaSlikas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzradaSlika izradaSlika = db.IzradaSlika.Find(id);
            if (izradaSlika == null)
            {
                return HttpNotFound();
            }
            return View(izradaSlika);
        }

        // GET: IzradaSlikas/Create
        public ActionResult Create()
        {
            ViewBag.RacunId = new SelectList(db.Racun, "RacunId", "RacunId");
            ViewBag.RadnikId = new SelectList(db.Radnik, "RadnikId", "ime");
            return View();
        }

        // POST: IzradaSlikas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IzradaSlikaId,datumNarudzbe,trenutniStatus,kolicina,hitnaNarudzba,RadnikId,RacunId,format,dodatno")] IzradaSlika izradaSlika)
        {
            if (ModelState.IsValid)
            {
                db.IzradaSlika.Add(izradaSlika);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RacunId = new SelectList(db.Racun, "RacunId", "RacunId", izradaSlika.RacunId);
            ViewBag.RadnikId = new SelectList(db.Radnik, "RadnikId", "ime", izradaSlika.RadnikId);
            return View(izradaSlika);
        }

        [HttpPost, ActionName("Add")]
        public void Add(string datum, string status, string kolicina, string hitno, string format, string dodatno)
        {
            bool da = false;
            if (hitno.Equals("da")) da = true;

            IzradaSlika novi = new IzradaSlika(Convert.ToDateTime("2018-01-01"), status, Int16.Parse(kolicina), da, format, dodatno);
            novi.RacunId = 1;
            novi.RadnikId = 1;
            //novi.Firma = new Firma();
            //novi.FizickoLice = new FizickoLice();
            
                db.IzradaSlika.Add(novi);
                db.SaveChanges();
            
        }
        // GET: IzradaSlikas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzradaSlika izradaSlika = db.IzradaSlika.Find(id);
            if (izradaSlika == null)
            {
                return HttpNotFound();
            }
            ViewBag.RacunId = new SelectList(db.Racun, "RacunId", "RacunId", izradaSlika.RacunId);
            ViewBag.RadnikId = new SelectList(db.Radnik, "RadnikId", "ime", izradaSlika.RadnikId);
            return View(izradaSlika);
        }

        // POST: IzradaSlikas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IzradaSlikaId,datumNarudzbe,trenutniStatus,kolicina,hitnaNarudzba,RadnikId,RacunId,format,dodatno")] IzradaSlika izradaSlika)
        {
            if (ModelState.IsValid)
            {
                db.Entry(izradaSlika).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RacunId = new SelectList(db.Racun, "RacunId", "RacunId", izradaSlika.RacunId);
            ViewBag.RadnikId = new SelectList(db.Radnik, "RadnikId", "ime", izradaSlika.RadnikId);
            return View(izradaSlika);
        }

        // GET: IzradaSlikas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzradaSlika izradaSlika = db.IzradaSlika.Find(id);
            if (izradaSlika == null)
            {
                return HttpNotFound();
            }
            return View(izradaSlika);
        }

        // POST: IzradaSlikas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IzradaSlika izradaSlika = db.IzradaSlika.Find(id);
            db.IzradaSlika.Remove(izradaSlika);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
