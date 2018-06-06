using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace eCopyASPNET.Models
{
    public class IzradaPersonaliziranihPredmeta 
    {
        public int IzradaPersonaliziranihPredmetaId { get; set; }
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
        public string predmet { get; set; }
        [Required]
        public string boja { get; set; }
        public byte[] slika { get; set; }


        public virtual FizickoLice FizickoLice { get; set; }
        public virtual Firma Firma { get; set; }

        public IzradaPersonaliziranihPredmeta()
        {

        }
    }
}