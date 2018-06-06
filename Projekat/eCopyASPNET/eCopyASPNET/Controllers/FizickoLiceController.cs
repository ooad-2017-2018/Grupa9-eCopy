using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using eCopyASPNET.Models;
using Newtonsoft.Json;

namespace eCopyASPNET.Controllers
{
    public class FizickoLiceController : Controller
    {
        private OOADContext db = new OOADContext();

        // GET: FizickoLice
        /*public ActionResult Index()
        {
            return View(db.FizickoLice.ToList());
        }*/

        // GET: FizickoLice
        string apiUrl = " http://localhost/ecopyapi/";
        public async Task<ActionResult> Index()
        {
            List<FizickoLice> korisnici = new List<FizickoLice>();
            using (var client = new HttpClient())
            {

                //Postavljanje adrese URL od web api servisa
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();

                //definisanje formata koji želimo prihvatiti
                client.DefaultRequestHeaders.Accept.Add(new
               MediaTypeWithQualityHeaderValue("application/json"));
                //Asinhrono slanje zahtjeva za podacima o studentima

                HttpResponseMessage Res = await client.GetAsync("api/FizickoLice/");
                //Provjera da li je rezultat uspješan
                if (Res.IsSuccessStatusCode)
                {
                    //spremanje podataka dobijenih iz responsa
                    var response = Res.Content.ReadAsStringAsync().Result;
                   
                //Deserijalizacija responsa dobijenog iz apija i pretvaranje u listustudenata
                korisnici = JsonConvert.DeserializeObject<List<FizickoLice>>(response);
                }

                return View(korisnici);
            }
        }

        // GET: FizickoLice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FizickoLice fizickoLice = db.FizickoLice.Find(id);
            if (fizickoLice == null)
            {
                return HttpNotFound();
            }
            return View(fizickoLice);
        }

        // GET: FizickoLice/Create
        public ActionResult Create()
        {
            return View();
        }
        public string Get(int id)
        {
            FizickoLice fle=db.FizickoLice.OfType<FizickoLice>().SingleOrDefault(s => s.FizickoLiceId == id);
            return fle.Ime;
        }
        // POST: FizickoLice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FizickoLiceId,Ime,prezime,adresa,email,korisnickoIme,lozinka,datumRodjenja")] FizickoLice fizickoLice)
        {
            if (ModelState.IsValid)
            {
                db.FizickoLice.Add(fizickoLice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fizickoLice);
        }


        // GET: FizickoLice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FizickoLice fizickoLice = db.FizickoLice.Find(id);
            if (fizickoLice == null)
            {
                return HttpNotFound();
            }
            return View(fizickoLice);
        }

        //POST
        [HttpPost, ActionName("Add")]
        public void Add(string ime, string prezime, string adresa, string email, string korisnickoIme, string lozinka, string datum)
        {
            FizickoLice novi = new FizickoLice(ime, prezime, adresa, email, korisnickoIme, lozinka, Convert.ToDateTime("2018-01-01"));
            db.FizickoLice.Add(novi);
            db.SaveChanges();
        }

        // POST: FizickoLice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FizickoLiceId,Ime,prezime,adresa,email,korisnickoIme,lozinka,datumRodjenja")] FizickoLice fizickoLice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fizickoLice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fizickoLice);
        }

        // GET: FizickoLice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FizickoLice fizickoLice = db.FizickoLice.Find(id);
            if (fizickoLice == null)
            {
                return HttpNotFound();
            }
            return View(fizickoLice);
        }

        // POST: FizickoLice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FizickoLice fizickoLice = db.FizickoLice.Find(id);
            db.FizickoLice.Remove(fizickoLice);
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

        [HttpPut]
        public void promjenaPassword(int username, String password)
        {
            if (password.Length > 0)
            {
                db.FizickoLice.OfType<FizickoLice>().SingleOrDefault(s => s.FizickoLiceId==username).lozinka = password;
                db.SaveChanges();
            }

        }

        [HttpPut]
        public void promjenaEmail(string id, String email)
        {
            db.FizickoLice.OfType<FizickoLice>().SingleOrDefault(s => s.korisnickoIme.Equals(id)).email = email;
            db.SaveChanges();
        }

        [HttpPut]
        public void promjenaUserName(string id, String ime)
        {
            db.FizickoLice.OfType<FizickoLice>().SingleOrDefault(s => s.korisnickoIme.Equals(id)).korisnickoIme = ime;
            db.SaveChanges();
        }

    }
}
