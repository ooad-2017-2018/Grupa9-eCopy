using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCopyASPNET.Models
{
    public class Racun
    {
        public int RacunId { get; set; }
        [Required]
        public int brojNarudzbi { get; set; }
        [Required]
        public DateTime datumIzdavanja { get; set; }
        public virtual ICollection<IzradaPersonaliziranihPredmeta> IzradaPersonaliziranihPredmeta { get; set; }
        public virtual ICollection<IzradaReklamnogMaterijala> IzradaReklamnogMaterijala { get; set; }
        public virtual ICollection<IzradaSlika> IzradaSlika { get; set; }
        public virtual ICollection<Printanje> Printanje { get; set; }

        public Racun()
        {

        }
        public Racun(int brojNarudzbi, DateTime datumIzdavanja)
        {
            this.brojNarudzbi = brojNarudzbi;
            this.datumIzdavanja = datumIzdavanja;
        }
    }
}