namespace Zdatak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipPoreza : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipPorezas",
                c => new
                    {
                        tipPorezaId = c.Int(nullable: false, identity: true),
                        iznos = c.Decimal(nullable: false, precision: 18, scale: 2),
                        naziv = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.tipPorezaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TipPorezas");
        }
    }
}
