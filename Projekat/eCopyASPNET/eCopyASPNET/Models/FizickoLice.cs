using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCopyASPNET.Models
{
    public class FizickoLice
    {
        public int FizickoLiceId
        {
            get;
            set;
        }
        [Required]
        public string Ime
        {
            get;
            set;
        }
        [Required]
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
        [Required]
        public string korisnickoIme
        {
            get;
            set;
        }
        [Required]
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
        public virtual ICollection<IzradaPersonaliziranihPredmeta> IzradaPersonaliziranihPredmeta { get; set; }
        public virtual ICollection<IzradaReklamnogMaterijala> IzradaReklamnogMaterijala { get; set; }
        public virtual ICollection<IzradaSlika> IzradaSlika { get; set; }
        public virtual ICollection<Printanje> Printanje { get; set; }
    }
}