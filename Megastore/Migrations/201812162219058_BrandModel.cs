namespace Megastore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BrandModel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Brands");
            AlterColumn("dbo.Brands", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Brands", "Name", c => c.String(nullable: false, maxLength: 255));
            AddPrimaryKey("dbo.Brands", "Name");
            DropTable("dbo.Categories");
            DropTable("dbo.CategorySources");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CategorySources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Taxonomy = c.String(maxLength: 255),
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
            
            DropPrimaryKey("dbo.Brands");
            AlterColumn("dbo.Brands", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.Brands", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Brands", "Id");
        }
    }
}
