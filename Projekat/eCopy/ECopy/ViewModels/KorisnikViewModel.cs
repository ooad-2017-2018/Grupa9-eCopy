using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECopy.ViewModels
{
    class KorisnikViewModel
    {
        private ECopy.RegistrovaniKorisnik korisnik;

        public ECopy.RegistrovaniKorisnik Korisnik { get => korisnik; set => korisnik = value; }

        public void PostaviIme(string ime) { korisnik.Ime = ime; }
        public void PostaviPrezime(string prezime) { korisnik.Prezime = prezime; }
        public void PostaviLozinku(string lozinka) { korisnik.Lozinka = lozinka; }
        public void PostaviBrojRacuna(Int64 broj) { korisnik.BrojRacuna = broj; }
        public void PostaviKorisnickoIme(string ime) { korisnik.KorisnickoIme = ime; }
        public void PostaviAdresu(string adresa) { korisnik.Adresa = adresa; }
        public void PostaviEmail(string mail) { korisnik.Email = mail; }
        public void PostaviBrojTelefona(long broj) { korisnik.BrojTelefona = broj; }
    }
}

