namespace CoCoCo_Facturatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Korting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EreloonNotas", "Korting", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EreloonNotas", "Korting");
        }
    }
}
