using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECopy.Models
{
    class Radnik
    {
        private string ime;
        private string prezime;
        private string korisnickoIme;
        private string lozinka;
        private string pozicija;
        private float plata;
        private DateTime datumRodjenja;

        public Radnik(string ime, string prezime, string korisnickoIme, string lozinka, string pozicija, float plata, DateTime datumRodjenja)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
            this.pozicija = pozicija;
            this.plata = plata;
            this.datumRodjenja = datumRodjenja;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public string Pozicija { get => pozicija; set => pozicija = value; }
        public float Plata { get => plata; set => plata = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
    }
}
