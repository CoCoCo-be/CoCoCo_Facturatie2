namespace CoCoCo_Facturatie.Migrations
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aanmaningen",
                c => new
                    {
                        AanmaningId = c.Int(nullable: false, identity: true),
                        Tijd = c.DateTime(nullable: false, precision: 0, defaultValueSql: "CURRENT_TIMESTAMP", storeType: "timestamp"),
                        Wie = c.String(nullable: false, maxLength: 2, storeType: "nvarchar"),
                        DossierNummer = c.String(nullable: false, unicode: false),
                        DossierNaam = c.String(nullable: false, unicode: false),
                        Partij_AanspreekTitel = c.String(nullable: false, unicode: false),
                        Partij_Naam = c.String(nullable: false, unicode: false),
                        Partij_Adres = c.String(nullable: false, unicode: false),
                        Partij_Adres2 = c.String(nullable: false, unicode: false),
                        AanmaningVersie = c.Byte(nullable: false),
                        EreloonNota_EreloonNotaId = c.Int(),
                        Provisie_ProvisieId = c.Int(),
                    })
                .PrimaryKey(t => t.AanmaningId)
                .ForeignKey("dbo.EreloonNotas", t => t.EreloonNota_EreloonNotaId)
                .ForeignKey("dbo.Provisies", t => t.Provisie_ProvisieId)
                .Index(t => t.EreloonNota_EreloonNotaId)
                .Index(t => t.Provisie_ProvisieId);
            
            CreateTable(
                "dbo.EreloonNotas",
                c => new
                    {
                        EreloonNotaId = c.Int(nullable: false, identity: true),
                        Tijd = c.DateTime(nullable: false, precision: 0, defaultValueSql: "CURRENT_TIMESTAMP", storeType: "timestamp"),
                        Wie = c.String(nullable: false, maxLength: 2, storeType: "nvarchar"),
                        DossierNummer = c.String(nullable: false, unicode: false),
                        DossierNaam = c.String(nullable: false, unicode: false),
                        Partij_AanspreekTitel = c.String(nullable: false, unicode: false),
                        Partij_Naam = c.String(nullable: false, unicode: false),
                        Partij_Adres = c.String(nullable: false, unicode: false),
                        Partij_Adres2 = c.String(nullable: false, unicode: false),
                        BijkomendeKosten = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Forfait = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EreloonUren = c.Time(nullable: false, precision: 0),
                        WachtUren = c.Time(nullable: false, precision: 0),
                        BTW = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rolzetting = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Dagvaarding = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Betekening = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Uitvoering = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Anderen = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Derden = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Totaal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Betaald = c.Boolean(nullable: false),
                        OGMNummer = c.String(unicode: false),
                        Status = c.Short(nullable: false),
                        InterCompany = c.Boolean(nullable: false),
                        KostenSchema_KostenSchemaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EreloonNotaId)
                .ForeignKey("dbo.KostenSchemas", t => t.KostenSchema_KostenSchemaId, cascadeDelete: true)
                .Index(t => t.KostenSchema_KostenSchemaId);

            CreateTable(
                "dbo.Facturen",
                c => new
                {
                    FactuurJaar = c.Int(nullable: false),
                    FactuurID = c.Int(nullable: false),
                    Tijd = c.DateTime(nullable: false, precision: 0, defaultValueSql: "CURRENT_TIMESTAMP", storeType: "timestamp"),
                    Wie = c.String(nullable: false, maxLength: 2, storeType: "nvarchar"),
                    DossierNummer = c.String(nullable: false, unicode: false),
                    DossierNaam = c.String(nullable: false, unicode: false),
                    Partij_AanspreekTitel = c.String(nullable: false, unicode: false),
                    Partij_Naam = c.String(nullable: false, unicode: false),
                    Partij_Adres = c.String(nullable: false, unicode: false),
                    Partij_Adres2 = c.String(nullable: false, unicode: false),
                    BijkomendeKosten = c.Decimal(precision: 18, scale: 2),
                    Forfait = c.Decimal(precision: 18, scale: 2),
                    EreloonUren = c.Time(precision: 0),
                    WachtUren = c.Time(precision: 0),
                    BTW = c.Decimal(precision: 18, scale: 2),
                    Rolzetting = c.Decimal(precision: 18, scale: 2),
                    Dagvaarding = c.Decimal(precision: 18, scale: 2),
                    Betekening = c.Decimal(precision: 18, scale: 2),
                    Uitvoering = c.Decimal(precision: 18, scale: 2),
                    Anderen = c.Decimal(precision: 18, scale: 2),
                    Derden = c.Decimal(precision: 18, scale: 2),
                    Totaal = c.Decimal(precision: 18, scale: 2),
                    ProvisieErelonen = c.Decimal(precision: 18, scale: 2),
                    ProvisieBTW = c.Decimal(precision: 18, scale: 2),
                    ProvisiegerechtsKosten = c.Decimal(precision: 18, scale: 2),
                    Totaal1 = c.Decimal(precision: 18, scale: 2),
                    Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    KostenSchema_KostenSchemaId = c.Int(),
                    EreloonNota_EreloonNotaId = c.Int(),
                    Provisie_ProvisieId = c.Int(),
                })
                .PrimaryKey(t => new { t.FactuurJaar, t.FactuurID })
                .ForeignKey("dbo.KostenSchemas", t => t.KostenSchema_KostenSchemaId, cascadeDelete: true)
                .ForeignKey("dbo.EreloonNotas", t => t.EreloonNota_EreloonNotaId)
                .ForeignKey("dbo.Provisies", t => t.Provisie_ProvisieId)
                .Index(t => t.KostenSchema_KostenSchemaId)
                .Index(t => t.EreloonNota_EreloonNotaId)
                .Index(t => t.Provisie_ProvisieId);

            CreateTable(
                "dbo.KostenSchemas",
                c => new
                    {
                        KostenSchemaId = c.Int(nullable: false, identity: true),
                        Naam = c.String(nullable: false, unicode: false),
                        Prestaties = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Wacht = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Verplaatsing = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mail = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fotokopie = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Dactylo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Archive = c.Boolean(nullable: false),
                        BTW = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.KostenSchemaId);
            
            CreateTable(
                "dbo.Provisies",
                c => new
                    {
                        ProvisieId = c.Int(nullable: false, identity: true),
                        Tijd = c.DateTime(nullable: false, precision: 0, defaultValueSql: "CURRENT_TIMESTAMP", storeType: "timestamp"),
                        Wie = c.String(nullable: false, maxLength: 2, storeType: "nvarchar"),
                        DossierNummer = c.String(nullable: false, unicode: false),
                        DossierNaam = c.String(nullable: false, unicode: false),
                        Partij_AanspreekTitel = c.String(nullable: false, unicode: false),
                        Partij_Naam = c.String(nullable: false, unicode: false),
                        Partij_Adres = c.String(nullable: false, unicode: false),
                        Partij_Adres2 = c.String(nullable: false, unicode: false),
                        Ereloon = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BTW = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Gerechtskosten = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Totaal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Betaald = c.Boolean(nullable: false),
                        OGMNummer = c.String(unicode: false),
                        EreloonBetaald = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BTWBetaald = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GerechtskostenBetaald = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Short(nullable: false),
                        InterCompany = c.Boolean(nullable: false),
                        EreloonNota_EreloonNotaId = c.Int(),
                    })
                .PrimaryKey(t => t.ProvisieId)
                .ForeignKey("dbo.EreloonNotas", t => t.EreloonNota_EreloonNotaId)
                .Index(t => t.EreloonNota_EreloonNotaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Provisies", "EreloonNota_EreloonNotaId", "dbo.EreloonNotas");
            DropForeignKey("dbo.Facturen", "Provisie_ProvisieId", "dbo.Provisies");
            DropForeignKey("dbo.Aanmaningen", "Provisie_ProvisieId", "dbo.Provisies");
            DropForeignKey("dbo.EreloonNotas", "KostenSchema_KostenSchemaId", "dbo.KostenSchemas");
            DropForeignKey("dbo.Facturen", "EreloonNota_EreloonNotaId", "dbo.EreloonNotas");
            DropForeignKey("dbo.Facturen", "KostenSchema_KostenSchemaId", "dbo.KostenSchemas");
            DropForeignKey("dbo.Aanmaningen", "EreloonNota_EreloonNotaId", "dbo.EreloonNotas");
            DropIndex("dbo.Provisies", new[] { "EreloonNota_EreloonNotaId" });
            DropIndex("dbo.Facturen", new[] { "Provisie_ProvisieId" });
            DropIndex("dbo.Facturen", new[] { "EreloonNota_EreloonNotaId" });
            DropIndex("dbo.Facturen", new[] { "KostenSchema_KostenSchemaId" });
            DropIndex("dbo.EreloonNotas", new[] { "KostenSchema_KostenSchemaId" });
            DropIndex("dbo.Aanmaningen", new[] { "Provisie_ProvisieId" });
            DropIndex("dbo.Aanmaningen", new[] { "EreloonNota_EreloonNotaId" });
            DropTable("dbo.Provisies");
            DropTable("dbo.KostenSchemas");
            DropTable("dbo.Facturen");
            DropTable("dbo.EreloonNotas");
            DropTable("dbo.Aanmaningen");
        }
    }
}
