using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECopy
{
    abstract class RegistrovaniKorisnik: Osoba
    {
        private String korisnickoIme;
        private String lozinka;
        private Int64 brojRacuna;

        public RegistrovaniKorisnik(string ime, string prezime, string adresa, string email, long broj, string korisnickoIme, string lozinka, long brojRacuna): base(ime, prezime, adresa, email, broj)
        {
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
            this.brojRacuna = brojRacuna;
        }

        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public long BrojRacuna { get => brojRacuna; set => brojRacuna = value; }
    }
}
