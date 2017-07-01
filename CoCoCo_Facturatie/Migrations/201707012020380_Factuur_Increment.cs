namespace CoCoCo_Facturatie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Factuur_Increment : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Facturen", "FactuurID");

            Sql(
                "ALTER TABLE `Facturen` CHANGE `FactuurID` `FactuurID` INT(11) NOT NULL AUTO_INCREMENT;");
        }
        
        public override void Down()
        {
            Sql(
                "ALTER TABLE `Facturen` CHANGE `FactuurID` `FactuurID` INT(11) NOT NULL;");
            DropIndex("dbo.Facturen", new[] { "FactuurID" });
        }
    }
}
