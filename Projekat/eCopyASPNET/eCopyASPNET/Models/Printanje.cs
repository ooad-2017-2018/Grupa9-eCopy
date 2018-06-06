using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace eCopyASPNET.Models
{
    public class Printanje 
    {
        public int PrintanjeId { get; set; }
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
        [Required]
        public string uvez { get; set; }
        [Required]
        public String dokument { get; set; }
        [Required]
        public Boolean uBoji { get; set; }


        public virtual FizickoLice FizickoLice { get; set; }
        public virtual Firma Firma { get; set; }


        public Printanje() { }

       
    }
}