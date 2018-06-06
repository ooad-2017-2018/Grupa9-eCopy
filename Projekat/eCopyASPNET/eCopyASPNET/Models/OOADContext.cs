using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace eCopyASPNET.Models
{
    public class OOADContext : DbContext
    {
        public OOADContext() : base("AzureConnection") //AzureConnection je naziv connection stringa u Web.config-u
        {
        }
        //dodavanjem klasa iz modela kao DbSet iste će biti mapirane u bazu podataka

        public DbSet<IzradaPersonaliziranihPredmeta> IzradaPersonaliziranihPredmeta{ get; set; }
        public DbSet<IzradaReklamnogMaterijala> IzradaReklamnogMaterijala { get; set; }
        public DbSet<IzradaSlika> IzradaSlika{ get; set; }
        public DbSet<Printanje> Printanje { get; set; }
        public DbSet<Racun> Racun { get; set; }
        public DbSet<Radnik> Radnik { get; set; }
        public DbSet<FizickoLice> FizickoLice { get; set; }
        public DbSet<Firma> Firma { get; set; }

        //Ova funkcija se koriste da bi se ukinulo automatsko dodavanje množine u nazive
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}