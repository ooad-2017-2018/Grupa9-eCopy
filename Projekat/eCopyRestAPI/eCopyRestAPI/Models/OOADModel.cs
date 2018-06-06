namespace eCopyRestAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OOADModel : DbContext
    {
        public OOADModel()
            : base("name=OOADModel")
        {
        }

        public virtual DbSet<Firma> Firma { get; set; }
        public virtual DbSet<FizickoLice> FizickoLice { get; set; }
        public virtual DbSet<IzradaPersonaliziranihPredmeta> IzradaPersonaliziranihPredmeta { get; set; }
        public virtual DbSet<IzradaReklamnogMaterijala> IzradaReklamnogMaterijala { get; set; }
        public virtual DbSet<IzradaSlika> IzradaSlika { get; set; }
        public virtual DbSet<Printanje> Printanje { get; set; }
        public virtual DbSet<Racun> Racun { get; set; }
        public virtual DbSet<Radnik> Radnik { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Firma>()
                .HasMany(e => e.IzradaPersonaliziranihPredmeta)
                .WithOptional(e => e.Firma)
                .HasForeignKey(e => e.Firma_FirmaId);

            modelBuilder.Entity<Firma>()
                .HasMany(e => e.IzradaReklamnogMaterijala)
                .WithOptional(e => e.Firma)
                .HasForeignKey(e => e.Firma_FirmaId);

            modelBuilder.Entity<Firma>()
                .HasMany(e => e.IzradaSlika)
                .WithOptional(e => e.Firma)
                .HasForeignKey(e => e.Firma_FirmaId);

            modelBuilder.Entity<Firma>()
                .HasMany(e => e.Printanje)
                .WithOptional(e => e.Firma)
                .HasForeignKey(e => e.Firma_FirmaId);

            modelBuilder.Entity<FizickoLice>()
                .HasMany(e => e.IzradaPersonaliziranihPredmeta)
                .WithOptional(e => e.FizickoLice)
                .HasForeignKey(e => e.FizickoLice_FizickoLiceId);

            modelBuilder.Entity<FizickoLice>()
                .HasMany(e => e.IzradaReklamnogMaterijala)
                .WithOptional(e => e.FizickoLice)
                .HasForeignKey(e => e.FizickoLice_FizickoLiceId);

            modelBuilder.Entity<FizickoLice>()
                .HasMany(e => e.IzradaSlika)
                .WithOptional(e => e.FizickoLice)
                .HasForeignKey(e => e.FizickoLice_FizickoLiceId);

            modelBuilder.Entity<FizickoLice>()
                .HasMany(e => e.Printanje)
                .WithOptional(e => e.FizickoLice)
                .HasForeignKey(e => e.FizickoLice_FizickoLiceId);
        }
    }
}
