using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECopy
{
    class Firma: RegistrovaniKorisnik
    {
        private string naziv;

        public Firma(string naziv, string ime, string prezime, string adresa, string email, long broj, string korisnicko, string lozinka, long racun): base(ime, prezime, adresa, email, broj, korisnicko, lozinka, racun)
        {
            this.naziv = naziv;
        }

        public string Naziv { get => naziv; set => naziv = value; }
    }
}
