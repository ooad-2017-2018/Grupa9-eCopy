namespace eCopyASPNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Firma",
                c => new
                    {
                        FirmaId = c.Int(nullable: false, identity: true),
                        nazivFirme = c.String(nullable: false),
                        ime = c.String(nullable: false),
                        prezime = c.String(nullable: false),
                        adresa = c.String(nullable: false),
                        email = c.String(),
                        korisnickoIme = c.String(nullable: false),
                        lozinka = c.String(nullable: false),
                        brojRacuna = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FirmaId);
            
            CreateTable(
                "dbo.IzradaPersonaliziranihPredmeta",
                c => new
                    {
                        IzradaPersonaliziranihPredmetaId = c.Int(nullable: false, identity: true),
                        datumNarudzbe = c.DateTime(nullable: false),
                        trenutniStatus = c.String(),
                        kolicina = c.Int(nullable: false),
                        hitnaNarudzba = c.Boolean(nullable: false),
                        RadnikId = c.Int(nullable: false),
                        RacunId = c.Int(nullable: false),
                        predmet = c.String(nullable: false),
                        boja = c.String(nullable: false),
                        slika = c.Binary(),
                        Firma_FirmaId = c.Int(),
                        FizickoLice_FizickoLiceId = c.Int(),
                    })
                .PrimaryKey(t => t.IzradaPersonaliziranihPredmetaId)
                .ForeignKey("dbo.Firma", t => t.Firma_FirmaId)
                .ForeignKey("dbo.FizickoLice", t => t.FizickoLice_FizickoLiceId)
                .ForeignKey("dbo.Racun", t => t.RacunId, cascadeDelete: true)
                .ForeignKey("dbo.Radnik", t => t.RadnikId, cascadeDelete: true)
                .Index(t => t.RadnikId)
                .Index(t => t.RacunId)
                .Index(t => t.Firma_FirmaId)
                .Index(t => t.FizickoLice_FizickoLiceId);
            
            CreateTable(
                "dbo.FizickoLice",
                c => new
                    {
                        FizickoLiceId = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                        prezime = c.String(nullable: false),
                        adresa = c.String(),
                        email = c.String(),
                        korisnickoIme = c.String(nullable: false),
                        lozinka = c.String(nullable: false),
                        datumRodjenja = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FizickoLiceId);
            
            CreateTable(
                "dbo.IzradaReklamnogMaterijala",
                c => new
                    {
                        IzradaReklamnogMaterijalaId = c.Int(nullable: false, identity: true),
                        datumNarudzbe = c.DateTime(nullable: false),
                        trenutniStatus = c.String(),
                        kolicina = c.Int(nullable: false),
                        hitnaNarudzba = c.Boolean(nullable: false),
                        RadnikId = c.Int(nullable: false),
                        RacunId = c.Int(nullable: false),
                        predmet = c.String(nullable: false),
                        boja = c.String(nullable: false),
                        slika = c.Binary(),
                        logo = c.String(),
                        Firma_FirmaId = c.Int(),
                        FizickoLice_FizickoLiceId = c.Int(),
                    })
                .PrimaryKey(t => t.IzradaReklamnogMaterijalaId)
                .ForeignKey("dbo.Firma", t => t.Firma_FirmaId)
                .ForeignKey("dbo.FizickoLice", t => t.FizickoLice_FizickoLiceId)
                .ForeignKey("dbo.Racun", t => t.RacunId, cascadeDelete: true)
                .ForeignKey("dbo.Radnik", t => t.RadnikId, cascadeDelete: true)
                .Index(t => t.RadnikId)
                .Index(t => t.RacunId)
                .Index(t => t.Firma_FirmaId)
                .Index(t => t.FizickoLice_FizickoLiceId);
            
            CreateTable(
                "dbo.Racun",
                c => new
                    {
                        RacunId = c.Int(nullable: false, identity: true),
                        brojNarudzbi = c.Int(nullable: false),
                        datumIzdavanja = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RacunId);
            
            CreateTable(
                "dbo.IzradaSlika",
                c => new
                    {
                        IzradaSlikaId = c.Int(nullable: false, identity: true),
                        datumNarudzbe = c.DateTime(nullable: false),
                        trenutniStatus = c.String(),
                        kolicina = c.Int(nullable: false),
                        hitnaNarudzba = c.Boolean(nullable: false),
                        RadnikId = c.Int(nullable: false),
                        RacunId = c.Int(nullable: false),
                        format = c.String(nullable: false),
                        dodatno = c.String(),
                        Firma_FirmaId = c.Int(),
                        FizickoLice_FizickoLiceId = c.Int(),
                    })
                .PrimaryKey(t => t.IzradaSlikaId)
                .ForeignKey("dbo.Firma", t => t.Firma_FirmaId)
                .ForeignKey("dbo.FizickoLice", t => t.FizickoLice_FizickoLiceId)
                .ForeignKey("dbo.Racun", t => t.RacunId, cascadeDelete: true)
                .ForeignKey("dbo.Radnik", t => t.RadnikId, cascadeDelete: true)
                .Index(t => t.RadnikId)
                .Index(t => t.RacunId)
                .Index(t => t.Firma_FirmaId)
                .Index(t => t.FizickoLice_FizickoLiceId);
            
            CreateTable(
                "dbo.Radnik",
                c => new
                    {
                        RadnikId = c.Int(nullable: false, identity: true),
                        ime = c.String(nullable: false),
                        prezime = c.String(nullable: false),
                        korisnickoIme = c.String(nullable: false),
                        lozinka = c.String(nullable: false),
                        pozicija = c.String(nullable: false),
                        plata = c.Single(nullable: false),
                        datumRodjenja = c.DateTime(nullable: false),
                        slika = c.Binary(),
                    })
                .PrimaryKey(t => t.RadnikId);
            
            CreateTable(
                "dbo.Printanje",
                c => new
                    {
                        PrintanjeId = c.Int(nullable: false, identity: true),
                        datumNarudzbe = c.DateTime(nullable: false),
                        trenutniStatus = c.String(),
                        kolicina = c.Int(nullable: false),
                        hitnaNarudzba = c.Boolean(nullable: false),
                        RadnikId = c.Int(nullable: false),
                        RacunId = c.Int(nullable: false),
                        format = c.String(nullable: false),
                        uvez = c.String(nullable: false),
                        dokument = c.String(nullable: false),
                        uBoji = c.Boolean(nullable: false),
                        Firma_FirmaId = c.Int(),
                        FizickoLice_FizickoLiceId = c.Int(),
                    })
                .PrimaryKey(t => t.PrintanjeId)
                .ForeignKey("dbo.Firma", t => t.Firma_FirmaId)
                .ForeignKey("dbo.FizickoLice", t => t.FizickoLice_FizickoLiceId)
                .ForeignKey("dbo.Racun", t => t.RacunId, cascadeDelete: true)
                .ForeignKey("dbo.Radnik", t => t.RadnikId, cascadeDelete: true)
                .Index(t => t.RadnikId)
                .Index(t => t.RacunId)
                .Index(t => t.Firma_FirmaId)
                .Index(t => t.FizickoLice_FizickoLiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Printanje", "RadnikId", "dbo.Radnik");
            DropForeignKey("dbo.Printanje", "RacunId", "dbo.Racun");
            DropForeignKey("dbo.Printanje", "FizickoLice_FizickoLiceId", "dbo.FizickoLice");
            DropForeignKey("dbo.Printanje", "Firma_FirmaId", "dbo.Firma");
            DropForeignKey("dbo.IzradaSlika", "RadnikId", "dbo.Radnik");
            DropForeignKey("dbo.IzradaReklamnogMaterijala", "RadnikId", "dbo.Radnik");
            DropForeignKey("dbo.IzradaPersonaliziranihPredmeta", "RadnikId", "dbo.Radnik");
            DropForeignKey("dbo.IzradaSlika", "RacunId", "dbo.Racun");
            DropForeignKey("dbo.IzradaSlika", "FizickoLice_FizickoLiceId", "dbo.FizickoLice");
            DropForeignKey("dbo.IzradaSlika", "Firma_FirmaId", "dbo.Firma");
            DropForeignKey("dbo.IzradaReklamnogMaterijala", "RacunId", "dbo.Racun");
            DropForeignKey("dbo.IzradaPersonaliziranihPredmeta", "RacunId", "dbo.Racun");
            DropForeignKey("dbo.IzradaReklamnogMaterijala", "FizickoLice_FizickoLiceId", "dbo.FizickoLice");
            DropForeignKey("dbo.IzradaReklamnogMaterijala", "Firma_FirmaId", "dbo.Firma");
            DropForeignKey("dbo.IzradaPersonaliziranihPredmeta", "FizickoLice_FizickoLiceId", "dbo.FizickoLice");
            DropForeignKey("dbo.IzradaPersonaliziranihPredmeta", "Firma_FirmaId", "dbo.Firma");
            DropIndex("dbo.Printanje", new[] { "FizickoLice_FizickoLiceId" });
            DropIndex("dbo.Printanje", new[] { "Firma_FirmaId" });
            DropIndex("dbo.Printanje", new[] { "RacunId" });
            DropIndex("dbo.Printanje", new[] { "RadnikId" });
            DropIndex("dbo.IzradaSlika", new[] { "FizickoLice_FizickoLiceId" });
            DropIndex("dbo.IzradaSlika", new[] { "Firma_FirmaId" });
            DropIndex("dbo.IzradaSlika", new[] { "RacunId" });
            DropIndex("dbo.IzradaSlika", new[] { "RadnikId" });
            DropIndex("dbo.IzradaReklamnogMaterijala", new[] { "FizickoLice_FizickoLiceId" });
            DropIndex("dbo.IzradaReklamnogMaterijala", new[] { "Firma_FirmaId" });
            DropIndex("dbo.IzradaReklamnogMaterijala", new[] { "RacunId" });
            DropIndex("dbo.IzradaReklamnogMaterijala", new[] { "RadnikId" });
            DropIndex("dbo.IzradaPersonaliziranihPredmeta", new[] { "FizickoLice_FizickoLiceId" });
            DropIndex("dbo.IzradaPersonaliziranihPredmeta", new[] { "Firma_FirmaId" });
            DropIndex("dbo.IzradaPersonaliziranihPredmeta", new[] { "RacunId" });
            DropIndex("dbo.IzradaPersonaliziranihPredmeta", new[] { "RadnikId" });
            DropTable("dbo.Printanje");
            DropTable("dbo.Radnik");
            DropTable("dbo.IzradaSlika");
            DropTable("dbo.Racun");
            DropTable("dbo.IzradaReklamnogMaterijala");
            DropTable("dbo.FizickoLice");
            DropTable("dbo.IzradaPersonaliziranihPredmeta");
            DropTable("dbo.Firma");
        }
    }
}
