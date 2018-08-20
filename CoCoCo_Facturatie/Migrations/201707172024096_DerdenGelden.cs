namespace CoCoCo_Facturatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DerdenGelden : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DerdenGelden",
                c => new
                    {
                        DerdenGeldId = c.Int(nullable: false, identity: true),
                        Tijd = c.DateTime(nullable: false, precision: 0, defaultValueSql: "CURRENT_TIMESTAMP", storeType: "timestamp"),
                        Wie = c.String(nullable: false, maxLength: 2, storeType: "nvarchar"),
                        DossierNummer = c.String(nullable: false, unicode: false),
                        DossierNaam = c.String(nullable: false, unicode: false),
                        Partij_AanspreekTitel = c.String(nullable: false, unicode: false),
                        Partij_Naam = c.String(nullable: false, unicode: false),
                        Partij_Adres = c.String(nullable: false, unicode: false),
                        Partij_Adres2 = c.String(nullable: false, unicode: false),
                        SchadeloosStelling = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Gerechtskosten = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Totaal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Betaald = c.Boolean(nullable: false),
                        OGMNummer = c.String(unicode: false),
                        SchadeloosStellingBetaald = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GerechtskostenBetaald = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotaalBetaald = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.DerdenGeldId);
            
            AddColumn("dbo.Aanmaningen", "DerdenGeld_DerdenGeldId", c => c.Int());
            CreateIndex("dbo.Aanmaningen", "DerdenGeld_DerdenGeldId");
            AddForeignKey("dbo.Aanmaningen", "DerdenGeld_DerdenGeldId", "dbo.DerdenGelden", "DerdenGeldId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aanmaningen", "DerdenGeld_DerdenGeldId", "dbo.DerdenGelden");
            DropIndex("dbo.Aanmaningen", new[] { "DerdenGeld_DerdenGeldId" });
            DropColumn("dbo.Aanmaningen", "DerdenGeld_DerdenGeldId");
            DropTable("dbo.DerdenGelden");
        }
    }
}
