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
    public class RadniksController : Controller
    {
        private OOADContext db = new OOADContext();

        // GET: Radniks
        public ActionResult Index()
        {
            return View(db.Radnik.ToList());
        }

        // GET: Radniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radnik radnik = db.Radnik.Find(id);
            if (radnik == null)
            {
                return HttpNotFound();
            }
            return View(radnik);
        }

        // POST: Radniks/Create
        /* [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Create(string ime, string prezime, string korisnickoIme, string lozinka, string pozicija, string plata, string datum)
         {
             Radnik radnik = new Radnik(ime, prezime, korisnickoIme, lozinka, pozicija, 1000, Convert.ToDateTime("2018-01-01"));
             //radnik.slika = buffer;
             if (ModelState.IsValid)
             {
                 db.Radnik.Add(radnik);
                 db.SaveChanges();
                 return View();
             }
             return View(radnik);
         } */
        public ActionResult Create()
        {
            return View();
        }


        // POST: Radniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RadnikId,ime,prezime,korisnickoIme,lozinka,pozicija,plata,datumRodjenja,slika")] Radnik radnik)
        {
            //Radnik radnik= new Radnik(FirstName, LastName, Username, Password, Position, 1000, DateOfBirth);
            if (ModelState.IsValid)
            {
                
                db.Radnik.Add(radnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(radnik);
        }

        // GET: Radniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radnik radnik = db.Radnik.Find(id);
            if (radnik == null)
            {
                return HttpNotFound();
            }
            return View(radnik);
        }

        [HttpPost , ActionName("Add")]
        public void Add(string ime, string prezime, string korisnickoIme, string lozinka, string pozicija, string plata, string datum)
        {
            Radnik novi = new Radnik(ime, prezime, korisnickoIme, lozinka, pozicija, 1000, Convert.ToDateTime("2018-01-01"));
            
            db.Radnik.Add(novi);
            db.SaveChanges();
        }
        public byte[] EncodeBase64(string data)
        {
            string s = data.Trim().Replace(" ", "+");
            if (s.Length % 4 > 0)
                s = s.PadRight(s.Length + 4 - s.Length % 4, '=');
            return (Convert.FromBase64String(s));
        }

        // POST: Radniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RadnikId,ime,prezime,korisnickoIme,lozinka,pozicija,plata,datumRodjenja,slika")] Radnik radnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(radnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(radnik);
        }

        // GET: Radniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radnik radnik = db.Radnik.Find(id);
            if (radnik == null)
            {
                return HttpNotFound();
            }
            return View(radnik);
        }

        // POST: Radniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Radnik radnik = db.Radnik.Find(id);
            db.Radnik.Remove(radnik);
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
