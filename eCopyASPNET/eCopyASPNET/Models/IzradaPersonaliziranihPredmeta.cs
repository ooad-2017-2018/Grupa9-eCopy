using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace eCopyASPNET.Models
{
    public class IzradaPersonaliziranihPredmeta : Narudzba
    {
        public int IzradaPersonaliziranihPredmetaId { get; set; }
        [Required]
        public string predmet { get; set; }
        [Required]
        public string boja { get; set; }
        public byte[] slika { get; set; }
        public IzradaPersonaliziranihPredmeta()
        {

        }

        public IzradaPersonaliziranihPredmeta(string predmet, string boja, byte[] slika, int idNarudzbe, string vrstaNaarudzbe, DateTime datumNarudzbe, string trenutniStatus, int kolicina, bool hitnaNarudzba) : base(idNarudzbe, vrstaNaarudzbe, datumNarudzbe, trenutniStatus, kolicina, hitnaNarudzba)
        {
            this.predmet = predmet;
            this.boja = boja;
            this.slika = slika;
        }
    }
}