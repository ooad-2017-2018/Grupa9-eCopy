using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace eCopyASPNET.Models
{
    public class Printanje : Narudzba
    {
        [Required]
        public string format { get; set; }
        [Required]
        public string uvez { get; set; }
        [Required]
        public String dokument { get; set; }
        [Required]
        public Boolean uBoji { get; set; }

        public Printanje() { }

        public Printanje(string format, string uvez, String dokument, bool uBoji, int idNarudzbe, string vrstaNaarudzbe, DateTime datumNarudzbe, string trenutniStatus, int kolicina, bool hitnaNarudzba) : base(idNarudzbe, vrstaNaarudzbe, datumNarudzbe, trenutniStatus, kolicina, hitnaNarudzba)
        {
            this.format = format;
            this.uvez = uvez;
            this.dokument = dokument;
            this.uBoji = uBoji;
        }
    }
}