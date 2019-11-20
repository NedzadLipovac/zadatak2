namespace Zdatak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipPorezaIspravkaPropertia : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TipPorezas", "naziv", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TipPorezas", "naziv", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
