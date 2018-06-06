namespace eCopyRestAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FizickoLice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FizickoLice()
        {
            IzradaPersonaliziranihPredmeta = new HashSet<IzradaPersonaliziranihPredmeta>();
            IzradaReklamnogMaterijala = new HashSet<IzradaReklamnogMaterijala>();
            IzradaSlika = new HashSet<IzradaSlika>();
            Printanje = new HashSet<Printanje>();
        }

        public int FizickoLiceId { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string prezime { get; set; }

        public string adresa { get; set; }

        public string email { get; set; }

        [Required]
        public string korisnickoIme { get; set; }

        [Required]
        public string lozinka { get; set; }

        public DateTime datumRodjenja { get; set; }

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
