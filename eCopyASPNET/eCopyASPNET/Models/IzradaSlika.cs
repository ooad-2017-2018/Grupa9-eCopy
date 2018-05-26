using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCopyASPNET.Models
{
    public class IzradaSlika: Narudzba
    {
        public int IzradaSlikaId { get; set; }
        [Required]
        public string format { get; set; }
        public string dodatno { get; set; }
        public IzradaSlika() { }

        public IzradaSlika(string format, string dodatno, int idNarudzbe, string vrstaNaarudzbe, DateTime datumNarudzbe, string trenutniStatus, int kolicina, bool hitnaNarudzba) : base(idNarudzbe, vrstaNaarudzbe, datumNarudzbe, trenutniStatus, kolicina, hitnaNarudzba)
        {
            this.format = format;
            this.dodatno = dodatno;
        }
    }
}