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
    public class NarudzbasController : Controller
    {
        private OOADContext db = new OOADContext();

        // GET: Narudzbas
        public ActionResult Index()
        {
            var narudzba = db.Narudzba.Include(n => n.Racun).Include(n => n.Radnik);
            return View(narudzba.ToList());
        }

        // GET: Narudzbas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Narudzba narudzba = db.Narudzba.Find(id);
            if (narudzba == null)
            {
                return HttpNotFound();
            }
            return View(narudzba);
        }

        // GET: Narudzbas/Create
        public ActionResult Create()
        {
            ViewBag.RacunId = new SelectList(db.Racun, "RacunId", "RacunId");
            ViewBag.RadnikId = new SelectList(db.Radnik, "RadnikId", "ime");
            return View();
        }

        // POST: Narudzbas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NarudzbaId,vrstaNarudzbe,datumNarudzbe,trenutniStatus,kolicina,hitnaNarudzba,RadnikId,RacunId")] Narudzba narudzba)
        {
            if (ModelState.IsValid)
            {
                db.Narudzba.Add(narudzba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RacunId = new SelectList(db.Racun, "RacunId", "RacunId", narudzba.RacunId);
            ViewBag.RadnikId = new SelectList(db.Radnik, "RadnikId", "ime", narudzba.RadnikId);
            return View(narudzba);
        }

        // GET: Narudzbas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Narudzba narudzba = db.Narudzba.Find(id);
            if (narudzba == null)
            {
                return HttpNotFound();
            }
            ViewBag.RacunId = new SelectList(db.Racun, "RacunId", "RacunId", narudzba.RacunId);
            ViewBag.RadnikId = new SelectList(db.Radnik, "RadnikId", "ime", narudzba.RadnikId);
            return View(narudzba);
        }

        // POST: Narudzbas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NarudzbaId,vrstaNarudzbe,datumNarudzbe,trenutniStatus,kolicina,hitnaNarudzba,RadnikId,RacunId")] Narudzba narudzba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(narudzba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RacunId = new SelectList(db.Racun, "RacunId", "RacunId", narudzba.RacunId);
            ViewBag.RadnikId = new SelectList(db.Radnik, "RadnikId", "ime", narudzba.RadnikId);
            return View(narudzba);
        }

        // GET: Narudzbas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Narudzba narudzba = db.Narudzba.Find(id);
            if (narudzba == null)
            {
                return HttpNotFound();
            }
            return View(narudzba);
        }

        // POST: Narudzbas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Narudzba narudzba = db.Narudzba.Find(id);
            db.Narudzba.Remove(narudzba);
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
