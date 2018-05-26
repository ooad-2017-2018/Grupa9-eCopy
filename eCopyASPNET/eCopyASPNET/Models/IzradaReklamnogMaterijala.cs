using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace eCopyASPNET.Models
{
    public class IzradaReklamnogMaterijala : Narudzba
    {
        public int IzradaReklamnogMaterijalaId {get; set;}
        [Required]
        public string predmet { get; set; }
        [Required]
        public string boja { get; set; }
        public byte[] slika { get; set; }
        public string logo { get; set; }
        public IzradaReklamnogMaterijala()
        {

        }

        public IzradaReklamnogMaterijala(string predmet, string boja, byte[] slika, string logo, int idNarudzbe, string vrstaNaarudzbe, DateTime datumNarudzbe, string trenutniStatus, int kolicina, bool hitnaNarudzba) : base(idNarudzbe, vrstaNaarudzbe, datumNarudzbe, trenutniStatus, kolicina, hitnaNarudzba)
        {
            this.predmet = predmet;
            this.boja = boja;
            this.slika = slika;
            this.logo = logo;
        }
    }
}
