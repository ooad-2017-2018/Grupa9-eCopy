using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace eCopyASPNET.Models
{
    public class Radnik
    {
        public int RadnikId { get; set; }
        [Required]
        public string ime { get; set; }
        [Required]
        public string prezime { get; set; }
        [Required]
        public string korisnickoIme { get; set; }
        [Required]
        public string lozinka { get; set; }
        [Required]
        public string pozicija { get; set; }
        [Required]
        public float plata { get; set; }
        public DateTime datumRodjenja { get; set; }
        public byte[] slika { get; set; }
        //public int id { get; set; }
        public virtual ICollection<Narudzba> Narudzba { get; set; }

        public Radnik()
        {

        }
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

    }
}