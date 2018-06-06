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
    public class IzradaReklamnogMaterijalasController : Controller
    {
        private OOADContext db = new OOADContext();

        // GET: IzradaReklamnogMaterijalas
        public ActionResult Index()
        {
            var izradaReklamnogMaterijala = db.IzradaReklamnogMaterijala.Include(i => i.Racun).Include(i => i.Radnik);
            return View(izradaReklamnogMaterijala.ToList());
        }

        // GET: IzradaReklamnogMaterijalas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzradaReklamnogMaterijala izradaReklamnogMaterijala = db.IzradaReklamnogMaterijala.Find(id);
            if (izradaReklamnogMaterijala == null)
            {
                return HttpNotFound();
            }
            return View(izradaReklamnogMaterijala);
        }

        // GET: IzradaReklamnogMaterijalas/Create
        public ActionResult Create()
        {
            ViewBag.RacunId = new SelectList(db.Racun, "RacunId", "RacunId");
            ViewBag.RadnikId = new SelectList(db.Radnik, "RadnikId", "ime");
            return View();
        }

        // POST: IzradaReklamnogMaterijalas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IzradaReklamnogMaterijalaId,datumNarudzbe,trenutniStatus,kolicina,hitnaNarudzba,RadnikId,RacunId,predmet,boja,slika,logo")] IzradaReklamnogMaterijala izradaReklamnogMaterijala)
        {
            if (ModelState.IsValid)
            {
                db.IzradaReklamnogMaterijala.Add(izradaReklamnogMaterijala);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RacunId = new SelectList(db.Racun, "RacunId", "RacunId", izradaReklamnogMaterijala.RacunId);
            ViewBag.RadnikId = new SelectList(db.Radnik, "RadnikId", "ime", izradaReklamnogMaterijala.RadnikId);
            return View(izradaReklamnogMaterijala);
        }

        // GET: IzradaReklamnogMaterijalas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzradaReklamnogMaterijala izradaReklamnogMaterijala = db.IzradaReklamnogMaterijala.Find(id);
            if (izradaReklamnogMaterijala == null)
            {
                return HttpNotFound();
            }
            ViewBag.RacunId = new SelectList(db.Racun, "RacunId", "RacunId", izradaReklamnogMaterijala.RacunId);
            ViewBag.RadnikId = new SelectList(db.Radnik, "RadnikId", "ime", izradaReklamnogMaterijala.RadnikId);
            return View(izradaReklamnogMaterijala);
        }

        // POST: IzradaReklamnogMaterijalas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IzradaReklamnogMaterijalaId,datumNarudzbe,trenutniStatus,kolicina,hitnaNarudzba,RadnikId,RacunId,predmet,boja,slika,logo")] IzradaReklamnogMaterijala izradaReklamnogMaterijala)
        {
            if (ModelState.IsValid)
            {
                db.Entry(izradaReklamnogMaterijala).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RacunId = new SelectList(db.Racun, "RacunId", "RacunId", izradaReklamnogMaterijala.RacunId);
            ViewBag.RadnikId = new SelectList(db.Radnik, "RadnikId", "ime", izradaReklamnogMaterijala.RadnikId);
            return View(izradaReklamnogMaterijala);
        }

        // GET: IzradaReklamnogMaterijalas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzradaReklamnogMaterijala izradaReklamnogMaterijala = db.IzradaReklamnogMaterijala.Find(id);
            if (izradaReklamnogMaterijala == null)
            {
                return HttpNotFound();
            }
            return View(izradaReklamnogMaterijala);
        }

        // POST: IzradaReklamnogMaterijalas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IzradaReklamnogMaterijala izradaReklamnogMaterijala = db.IzradaReklamnogMaterijala.Find(id);
            db.IzradaReklamnogMaterijala.Remove(izradaReklamnogMaterijala);
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
