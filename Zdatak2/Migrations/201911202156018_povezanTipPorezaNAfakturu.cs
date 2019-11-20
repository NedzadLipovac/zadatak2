namespace Zdatak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class povezanTipPorezaNAfakturu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fakturas", "tipPorezaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Fakturas", "tipPorezaId");
            AddForeignKey("dbo.Fakturas", "tipPorezaId", "dbo.TipPorezas", "tipPorezaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fakturas", "tipPorezaId", "dbo.TipPorezas");
            DropIndex("dbo.Fakturas", new[] { "tipPorezaId" });
            DropColumn("dbo.Fakturas", "tipPorezaId");
        }
    }
}
