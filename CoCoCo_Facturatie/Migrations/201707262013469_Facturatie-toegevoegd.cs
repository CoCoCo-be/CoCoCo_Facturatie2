namespace CoCoCo_Facturatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Facturatietoegevoegd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facturen", "Dactylo", c => c.Short());
            AddColumn("dbo.Facturen", "Fotokopie", c => c.Short());
            AddColumn("dbo.Facturen", "Fax", c => c.Short());
            AddColumn("dbo.Facturen", "Verplaatsing", c => c.Short());
            AlterColumn("dbo.Facturen", "Totaal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Facturen", "Totaal1");
            DropColumn("dbo.Provisies", "EreloonBetaald");
            DropColumn("dbo.Provisies", "BTWBetaald");
            DropColumn("dbo.Provisies", "GerechtskostenBetaald");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Provisies", "GerechtskostenBetaald", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Provisies", "BTWBetaald", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Provisies", "EreloonBetaald", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Facturen", "Totaal1", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Facturen", "Totaal", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Facturen", "Verplaatsing");
            DropColumn("dbo.Facturen", "Fax");
            DropColumn("dbo.Facturen", "Fotokopie");
            DropColumn("dbo.Facturen", "Dactylo");
        }
    }
}
