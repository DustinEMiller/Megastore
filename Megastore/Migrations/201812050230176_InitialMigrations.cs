namespace Megastore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategorySources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Taxonomy = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CategorySources");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
        }
    }
}
