namespace Wassy.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LogIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Date = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Amount = c.Double(nullable: false),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        Wassaya = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Relatives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        UserId = c.Int(nullable: false),
                        RelationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Relations", t => t.RelationId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RelationId);
            
            CreateTable(
                "dbo.Relations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Percentage = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Responsibles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Templates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wassaya_Template = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Responsibles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Relatives", "UserId", "dbo.Users");
            DropForeignKey("dbo.Relatives", "RelationId", "dbo.Relations");
            DropForeignKey("dbo.Properties", "UserId", "dbo.Users");
            DropForeignKey("dbo.Properties", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Responsibles", new[] { "UserId" });
            DropIndex("dbo.Relatives", new[] { "RelationId" });
            DropIndex("dbo.Relatives", new[] { "UserId" });
            DropIndex("dbo.Properties", new[] { "UserId" });
            DropIndex("dbo.Properties", new[] { "CategoryId" });
            DropTable("dbo.Templates");
            DropTable("dbo.Responsibles");
            DropTable("dbo.Relations");
            DropTable("dbo.Relatives");
            DropTable("dbo.Users");
            DropTable("dbo.Properties");
            DropTable("dbo.LogIns");
            DropTable("dbo.Categories");
        }
    }
}
