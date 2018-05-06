using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECopy
{
    class NeregistrovaniKorisnik: Osoba
    {
        private long brojRacuna;

        public NeregistrovaniKorisnik(string ime, string prezime, string adresa, string email, long broj, long brojRacuna): base(ime, prezime, adresa, email, broj)
        {
            this.brojRacuna = brojRacuna;
        }
    }
}
