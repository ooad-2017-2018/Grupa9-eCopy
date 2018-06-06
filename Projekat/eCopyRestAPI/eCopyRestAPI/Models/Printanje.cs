namespace eCopyRestAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Printanje")]
    public partial class Printanje
    {
        public int PrintanjeId { get; set; }

        public DateTime datumNarudzbe { get; set; }

        public string trenutniStatus { get; set; }

        public int kolicina { get; set; }

        public bool hitnaNarudzba { get; set; }

        public int RadnikId { get; set; }

        public int RacunId { get; set; }

        [Required]
        public string format { get; set; }

        [Required]
        public string uvez { get; set; }

        [Required]
        public string dokument { get; set; }

        public bool uBoji { get; set; }

        public int? Firma_FirmaId { get; set; }

        public int? FizickoLice_FizickoLiceId { get; set; }

        public virtual Firma Firma { get; set; }

        public virtual FizickoLice FizickoLice { get; set; }

        public virtual Racun Racun { get; set; }

        public virtual Radnik Radnik { get; set; }
    }
}
