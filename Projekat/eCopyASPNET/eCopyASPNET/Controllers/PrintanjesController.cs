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
    public class PrintanjesController : Controller
    {
        private OOADContext db = new OOADContext();

        // GET: Printanjes
        public ActionResult Index()
        {
            var printanje = db.Printanje.Include(p => p.Racun).Include(p => p.Radnik);
            return View(printanje.ToList());
        }

        // GET: Printanjes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Printanje printanje = db.Printanje.Find(id);
            if (printanje == null)
            {
                return HttpNotFound();
            }
            return View(printanje);
        }

        // GET: Printanjes/Create
        public ActionResult Create()
        {
            ViewBag.RacunId = new SelectList(db.Racun, "RacunId", "RacunId");
            ViewBag.RadnikId = new SelectList(db.Radnik, "RadnikId", "ime");
            return View();
        }

        // POST: Printanjes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrintanjeId,datumNarudzbe,trenutniStatus,kolicina,hitnaNarudzba,RadnikId,RacunId,format,uvez,dokument,uBoji")] Printanje printanje)
        {
            if (ModelState.IsValid)
            {
                db.Printanje.Add(printanje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RacunId = new SelectList(db.Racun, "RacunId", "RacunId", printanje.RacunId);
            ViewBag.RadnikId = new SelectList(db.Radnik, "RadnikId", "ime", printanje.RadnikId);
            return View(printanje);
        }

        // GET: Printanjes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Printanje printanje = db.Printanje.Find(id);
            if (printanje == null)
            {
                return HttpNotFound();
            }
            ViewBag.RacunId = new SelectList(db.Racun, "RacunId", "RacunId", printanje.RacunId);
            ViewBag.RadnikId = new SelectList(db.Radnik, "RadnikId", "ime", printanje.RadnikId);
            return View(printanje);
        }

        // POST: Printanjes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrintanjeId,datumNarudzbe,trenutniStatus,kolicina,hitnaNarudzba,RadnikId,RacunId,format,uvez,dokument,uBoji")] Printanje printanje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(printanje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RacunId = new SelectList(db.Racun, "RacunId", "RacunId", printanje.RacunId);
            ViewBag.RadnikId = new SelectList(db.Radnik, "RadnikId", "ime", printanje.RadnikId);
            return View(printanje);
        }

        // GET: Printanjes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Printanje printanje = db.Printanje.Find(id);
            if (printanje == null)
            {
                return HttpNotFound();
            }
            return View(printanje);
        }

        // POST: Printanjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Printanje printanje = db.Printanje.Find(id);
            db.Printanje.Remove(printanje);
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
