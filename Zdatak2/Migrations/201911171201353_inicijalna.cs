namespace Zdatak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicijalna : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fakturas",
                c => new
                    {
                        FakturaId = c.Int(nullable: false, identity: true),
                        BrFakture = c.String(),
                        DatumStvaranja = c.DateTime(nullable: false),
                        DatumDospijeca = c.DateTime(nullable: false),
                        UkupnaCijenaBezPoreza = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UkupnaCijenaSaporezom = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrimateljRacuna = c.String(),
                        StvarateljRacuna_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FakturaId)
                .ForeignKey("dbo.AspNetUsers", t => t.StvarateljRacuna_Id)
                .Index(t => t.StvarateljRacuna_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.FakturaStavkas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FakturaId = c.Int(nullable: false),
                        StavkaId = c.Int(nullable: false),
                        Kolicina = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fakturas", t => t.FakturaId, cascadeDelete: true)
                .ForeignKey("dbo.Stavkas", t => t.StavkaId, cascadeDelete: true)
                .Index(t => t.FakturaId)
                .Index(t => t.StavkaId);
            
            CreateTable(
                "dbo.Stavkas",
                c => new
                    {
                        StavkaId = c.Int(nullable: false, identity: true),
                        Opis = c.String(),
                        Cijena = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.StavkaId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FakturaStavkas", "StavkaId", "dbo.Stavkas");
            DropForeignKey("dbo.FakturaStavkas", "FakturaId", "dbo.Fakturas");
            DropForeignKey("dbo.Fakturas", "StvarateljRacuna_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.FakturaStavkas", new[] { "StavkaId" });
            DropIndex("dbo.FakturaStavkas", new[] { "FakturaId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Fakturas", new[] { "StvarateljRacuna_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Stavkas");
            DropTable("dbo.FakturaStavkas");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Fakturas");
        }
    }
}
