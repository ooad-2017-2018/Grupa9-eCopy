using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCopyASPNET.Models
{
    public class IzradaSlika
    {
        public int IzradaSlikaId { get; set; }
        [Required]
        public DateTime datumNarudzbe { get; set; }
        public string trenutniStatus { get; set; }
        [Required]
        public int kolicina { get; set; }
        public Boolean hitnaNarudzba { get; set; }
        public int RadnikId { get; set; }
        public int RacunId { get; set; }
        public virtual Radnik Radnik { get; set; }
        public virtual Racun Racun { get; set; }
        [Required]
        public string format { get; set; }
        public string dodatno { get; set; }


        public virtual FizickoLice FizickoLice { get; set; }
        public virtual Firma Firma { get; set; }

        public IzradaSlika() { }
        public IzradaSlika(DateTime datum, string status, int kolicina, bool hitno, string format, string doadatno)
        {
            this.datumNarudzbe = datum;
            this.trenutniStatus = status;
            this.kolicina = kolicina;
            this.hitnaNarudzba = hitno;
            this.format = format;
            this.dodatno = doadatno;
        }


    }
}