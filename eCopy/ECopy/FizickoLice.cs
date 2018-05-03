using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECopy
{
    class FizickoLice: RegistrovaniKorisnik
    {
        private long brojNarudzbi;

        public FizickoLice(string ime, string prezime, string adresa, string email, long broj, string korisnickoIme, string lozinka, long brojRacuna, long brojNarudzbi): base(ime, prezime, adresa, email, broj, korisnickoIme, lozinka, brojRacuna)
        {
            this.brojNarudzbi = brojNarudzbi;
        }

        public long BrojNarudzbi { get => brojNarudzbi; set => brojNarudzbi = value; }
    }
}
