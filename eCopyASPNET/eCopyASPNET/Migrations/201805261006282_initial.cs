namespace eCopyASPNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Narudzba",
                c => new
                    {
                        NarudzbaId = c.Int(nullable: false, identity: true),
                        vrstaNarudzbe = c.String(),
                        datumNarudzbe = c.DateTime(nullable: false),
                        trenutniStatus = c.String(),
                        kolicina = c.Int(nullable: false),
                        hitnaNarudzba = c.Boolean(nullable: false),
                        RadnikId = c.Int(nullable: false),
                        RacunId = c.Int(nullable: false),
                        IzradaPersonaliziranihPredmetaId = c.Int(),
                        predmet = c.String(),
                        boja = c.String(),
                        slika = c.Binary(),
                        IzradaReklamnogMaterijalaId = c.Int(),
                        predmet1 = c.String(),
                        boja1 = c.String(),
                        slika1 = c.Binary(),
                        logo = c.String(),
                        IzradaSlikaId = c.Int(),
                        format = c.String(),
                        dodatno = c.String(),
                        format1 = c.String(),
                        uvez = c.String(),
                        dokument = c.String(),
                        uBoji = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.NarudzbaId)
                .ForeignKey("dbo.Racun", t => t.RacunId, cascadeDelete: true)
                .ForeignKey("dbo.Radnik", t => t.RadnikId, cascadeDelete: true)
                .Index(t => t.RadnikId)
                .Index(t => t.RacunId);
            
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
                "dbo.Radnik",
                c => new
                    {
                        RadnikId = c.Int(nullable: false, identity: true),
                        ime = c.String(),
                        prezime = c.String(),
                        korisnickoIme = c.String(),
                        lozinka = c.String(),
                        pozicija = c.String(),
                        plata = c.Single(nullable: false),
                        datumRodjenja = c.DateTime(nullable: false),
                        slika = c.Binary(),
                    })
                .PrimaryKey(t => t.RadnikId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Narudzba", "RadnikId", "dbo.Radnik");
            DropForeignKey("dbo.Narudzba", "RacunId", "dbo.Racun");
            DropIndex("dbo.Narudzba", new[] { "RacunId" });
            DropIndex("dbo.Narudzba", new[] { "RadnikId" });
            DropTable("dbo.Radnik");
            DropTable("dbo.Racun");
            DropTable("dbo.Narudzba");
        }
    }
}
