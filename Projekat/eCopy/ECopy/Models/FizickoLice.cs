using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECopy.Models
{
    public class FizickoLice
    {

        public int id
        {
            get;
            set;
        }
        public string Ime
        {
            get;
            set;
        }
        public string prezime
        {
            get;
            set;
        }
        public string adresa
        {
            get;
            set;
        }
        public string email
        {
            get;
            set;
        }
        public string korisnickoIme
        {
            get;
            set;
        }
        public string lozinka
        {
            get;
            set;
        }
        public DateTime datumRodjenja
        {
            get;
            set;
        }
        public static string trenutniUser { get; set; }

        public FizickoLice() { }
        public FizickoLice(string ime, string prezime, string adresa, string email, string korisnickoIme, string lozinka, DateTime datum)
        {
            this.Ime = ime;
            this.prezime = prezime;
            this.adresa = adresa;
            this.email = email;
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
            this.datumRodjenja = datum;
        }
    }
}
