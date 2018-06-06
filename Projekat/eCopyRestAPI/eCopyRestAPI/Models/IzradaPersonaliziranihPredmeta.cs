namespace eCopyRestAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IzradaPersonaliziranihPredmeta")]
    public partial class IzradaPersonaliziranihPredmeta
    {
        public int IzradaPersonaliziranihPredmetaId { get; set; }

        public DateTime datumNarudzbe { get; set; }

        public string trenutniStatus { get; set; }

        public int kolicina { get; set; }

        public bool hitnaNarudzba { get; set; }

        public int RadnikId { get; set; }

        public int RacunId { get; set; }

        [Required]
        public string predmet { get; set; }

        [Required]
        public string boja { get; set; }

        public byte[] slika { get; set; }

        public int? Firma_FirmaId { get; set; }

        public int? FizickoLice_FizickoLiceId { get; set; }

        public virtual Firma Firma { get; set; }

        public virtual FizickoLice FizickoLice { get; set; }

        public virtual Racun Racun { get; set; }

        public virtual Radnik Radnik { get; set; }
    }
}
