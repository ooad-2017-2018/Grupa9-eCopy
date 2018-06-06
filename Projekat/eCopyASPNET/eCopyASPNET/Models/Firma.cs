using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCopyASPNET.Models
{
    public class Firma
    {
        
        public int FirmaId { get; set; }
        [Required]
        public String nazivFirme { get; set; }
        [Required]
        public String ime { get; set; }
        [Required]
        public String prezime { get; set; }
        [Required]
        public String adresa { get; set; }
        public String email { get; set; }
        [Required]
        public String korisnickoIme { get; set; }
        [Required]
        public String lozinka { get; set; }
        public int brojRacuna { get; set; }
        public virtual ICollection<IzradaPersonaliziranihPredmeta> IzradaPersonaliziranihPredmeta { get; set; }
        public virtual ICollection<IzradaReklamnogMaterijala> IzradaReklamnogMaterijala { get; set; }
        public virtual ICollection<IzradaSlika> IzradaSlika { get; set; }
        public virtual ICollection<Printanje> Printanje { get; set; }
    }
}