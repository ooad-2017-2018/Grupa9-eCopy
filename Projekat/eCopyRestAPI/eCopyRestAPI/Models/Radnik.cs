namespace eCopyRestAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Radnik")]
    public partial class Radnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Radnik()
        {
            IzradaPersonaliziranihPredmeta = new HashSet<IzradaPersonaliziranihPredmeta>();
            IzradaReklamnogMaterijala = new HashSet<IzradaReklamnogMaterijala>();
            IzradaSlika = new HashSet<IzradaSlika>();
            Printanje = new HashSet<Printanje>();
        }

        public int RadnikId { get; set; }

        [Required]
        public string ime { get; set; }

        [Required]
        public string prezime { get; set; }

        [Required]
        public string korisnickoIme { get; set; }

        [Required]
        public string lozinka { get; set; }

        [Required]
        public string pozicija { get; set; }

        public float plata { get; set; }

        public DateTime datumRodjenja { get; set; }

        public byte[] slika { get; set; }

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
