using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECopy
{
    abstract class Osoba
    {
        private String ime;
        private String prezime;
        private String adresa;
        private String email;
        private Int64 brojTelefona;

        public Osoba(string ime, string prezime, string adresa, string email, long brojTelefona)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.adresa = adresa;
            this.email = email;
            this.brojTelefona = brojTelefona;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public string Email { get => email; set => email = value; }
        public long BrojTelefona { get => brojTelefona; set => brojTelefona = value; }
    }
}
