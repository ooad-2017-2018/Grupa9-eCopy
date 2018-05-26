using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCopyASPNET.Models
{
    public class Narudzba
    {
        public int NarudzbaId { get; set; }
        [Required]
        public string vrstaNarudzbe { get; set; }
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

        public Narudzba() {

            }
        protected Narudzba(int idNarudzbe, string vrstaNaarudzbe, DateTime datumNarudzbe, string trenutniStatus, int kolicina, bool hitnaNarudzba)
        {
            this.NarudzbaId = idNarudzbe;
            this.vrstaNarudzbe = vrstaNarudzbe;
            this.datumNarudzbe = datumNarudzbe;
            this.trenutniStatus = trenutniStatus;
            this.kolicina = kolicina;
            this.hitnaNarudzba = hitnaNarudzba;
        }

        protected Narudzba(int idNarudzbe, string vrstaNaarudzbe, DateTime datumNarudzbe, int kolicina, bool hitnaNarudzba)
        {
            this.NarudzbaId = idNarudzbe;
            this.vrstaNarudzbe = vrstaNarudzbe;
            this.datumNarudzbe = datumNarudzbe;
            this.kolicina = kolicina;
            this.hitnaNarudzba = hitnaNarudzba;
        }
    }
}