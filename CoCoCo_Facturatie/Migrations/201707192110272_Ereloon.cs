namespace CoCoCo_Facturatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ereloon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EreloonNotas", "Dactylo", c => c.Short(nullable: false));
            AddColumn("dbo.EreloonNotas", "Fotokopie", c => c.Short(nullable: false));
            AddColumn("dbo.EreloonNotas", "Fax", c => c.Short(nullable: false));
            AddColumn("dbo.EreloonNotas", "Verplaatsing", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EreloonNotas", "Verplaatsing");
            DropColumn("dbo.EreloonNotas", "Fax");
            DropColumn("dbo.EreloonNotas", "Fotokopie");
            DropColumn("dbo.EreloonNotas", "Dactylo");
        }
    }
}
