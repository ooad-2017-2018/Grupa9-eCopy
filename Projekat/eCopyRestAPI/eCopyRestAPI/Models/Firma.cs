namespace eCopyRestAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Firma")]
    public partial class Firma
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Firma()
        {
            IzradaPersonaliziranihPredmeta = new HashSet<IzradaPersonaliziranihPredmeta>();
            IzradaReklamnogMaterijala = new HashSet<IzradaReklamnogMaterijala>();
            IzradaSlika = new HashSet<IzradaSlika>();
            Printanje = new HashSet<Printanje>();
        }

        public int FirmaId { get; set; }

        [Required]
        public string nazivFirme { get; set; }

        [Required]
        public string ime { get; set; }

        [Required]
        public string prezime { get; set; }

        [Required]
        public string adresa { get; set; }

        public string email { get; set; }

        [Required]
        public string korisnickoIme { get; set; }

        [Required]
        public string lozinka { get; set; }

        public int brojRacuna { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzradaPersonaliziranihPredmeta> IzradaPersonaliziranihPredmeta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzradaReklamnogMaterijala> IzradaReklamnogMaterijala { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzradaSlika> IzradaSlika { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Printanje> Printanje { get; set; }
    }
}
