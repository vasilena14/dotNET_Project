namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                        Country = c.String(nullable: false, maxLength: 64),
                        Founded = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 64),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Engines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 64),
                        Cylinders = c.String(nullable: false, maxLength: 64),
                        CoolingSystem = c.String(nullable: false, maxLength: 64),
                        Capacity = c.Int(nullable: false),
                        Horsepower = c.Double(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Motorcycles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                        Year = c.Int(nullable: false),
                        SeatHeight = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Brand_ID = c.Int(nullable: false),
                        Category_ID = c.Int(nullable: false),
                        Engine_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Brands", t => t.Brand_ID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_ID, cascadeDelete: true)
                .ForeignKey("dbo.Engines", t => t.Engine_ID, cascadeDelete: true)
                .Index(t => t.Brand_ID)
                .Index(t => t.Category_ID)
                .Index(t => t.Engine_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Motorcycles", "Engine_ID", "dbo.Engines");
            DropForeignKey("dbo.Motorcycles", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.Motorcycles", "Brand_ID", "dbo.Brands");
            DropIndex("dbo.Motorcycles", new[] { "Engine_ID" });
            DropIndex("dbo.Motorcycles", new[] { "Category_ID" });
            DropIndex("dbo.Motorcycles", new[] { "Brand_ID" });
            DropTable("dbo.Motorcycles");
            DropTable("dbo.Engines");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
        }
    }
}
