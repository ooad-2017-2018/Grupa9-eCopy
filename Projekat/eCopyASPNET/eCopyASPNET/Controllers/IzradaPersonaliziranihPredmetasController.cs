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
    public class IzradaPersonaliziranihPredmetasController : Controller
    {
        private OOADContext db = new OOADContext();

        // GET: IzradaPersonaliziranihPredmetas
        public ActionResult Index()
        {
            var izradaPersonaliziranihPredmeta = db.IzradaPersonaliziranihPredmeta.Include(i => i.Racun).Include(i => i.Radnik);
            return View(izradaPersonaliziranihPredmeta.ToList());
        }

        // GET: IzradaPersonaliziranihPredmetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzradaPersonaliziranihPredmeta izradaPersonaliziranihPredmeta = db.IzradaPersonaliziranihPredmeta.Find(id);
            if (izradaPersonaliziranihPredmeta == null)
            {
                return HttpNotFound();
            }
            return View(izradaPersonaliziranihPredmeta);
        }

        // GET: IzradaPersonaliziranihPredmetas/Create
        public ActionResult Create()
        {
            ViewBag.RacunId = new SelectList(db.Racun, "RacunId", "RacunId");
            ViewBag.RadnikId = new SelectList(db.Radnik, "RadnikId", "ime");
            return View();
        }

        // POST: IzradaPersonaliziranihPredmetas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IzradaPersonaliziranihPredmetaId,datumNarudzbe,trenutniStatus,kolicina,hitnaNarudzba,RadnikId,RacunId,predmet,boja,slika")] IzradaPersonaliziranihPredmeta izradaPersonaliziranihPredmeta)
        {
            if (ModelState.IsValid)
            {
                db.IzradaPersonaliziranihPredmeta.Add(izradaPersonaliziranihPredmeta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RacunId = new SelectList(db.Racun, "RacunId", "RacunId", izradaPersonaliziranihPredmeta.RacunId);
            ViewBag.RadnikId = new SelectList(db.Radnik, "RadnikId", "ime", izradaPersonaliziranihPredmeta.RadnikId);
            return View(izradaPersonaliziranihPredmeta);
        }

        // GET: IzradaPersonaliziranihPredmetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzradaPersonaliziranihPredmeta izradaPersonaliziranihPredmeta = db.IzradaPersonaliziranihPredmeta.Find(id);
            if (izradaPersonaliziranihPredmeta == null)
            {
                return HttpNotFound();
            }
            ViewBag.RacunId = new SelectList(db.Racun, "RacunId", "RacunId", izradaPersonaliziranihPredmeta.RacunId);
            ViewBag.RadnikId = new SelectList(db.Radnik, "RadnikId", "ime", izradaPersonaliziranihPredmeta.RadnikId);
            return View(izradaPersonaliziranihPredmeta);
        }

        // POST: IzradaPersonaliziranihPredmetas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IzradaPersonaliziranihPredmetaId,datumNarudzbe,trenutniStatus,kolicina,hitnaNarudzba,RadnikId,RacunId,predmet,boja,slika")] IzradaPersonaliziranihPredmeta izradaPersonaliziranihPredmeta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(izradaPersonaliziranihPredmeta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RacunId = new SelectList(db.Racun, "RacunId", "RacunId", izradaPersonaliziranihPredmeta.RacunId);
            ViewBag.RadnikId = new SelectList(db.Radnik, "RadnikId", "ime", izradaPersonaliziranihPredmeta.RadnikId);
            return View(izradaPersonaliziranihPredmeta);
        }

        // GET: IzradaPersonaliziranihPredmetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzradaPersonaliziranihPredmeta izradaPersonaliziranihPredmeta = db.IzradaPersonaliziranihPredmeta.Find(id);
            if (izradaPersonaliziranihPredmeta == null)
            {
                return HttpNotFound();
            }
            return View(izradaPersonaliziranihPredmeta);
        }

        // POST: IzradaPersonaliziranihPredmetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IzradaPersonaliziranihPredmeta izradaPersonaliziranihPredmeta = db.IzradaPersonaliziranihPredmeta.Find(id);
            db.IzradaPersonaliziranihPredmeta.Remove(izradaPersonaliziranihPredmeta);
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
