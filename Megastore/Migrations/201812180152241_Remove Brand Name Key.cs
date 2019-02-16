namespace Megastore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBrandNameKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Brands");
            AlterColumn("dbo.Brands", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Brands", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Brands");
            AlterColumn("dbo.Brands", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Brands", "Name");
        }
    }
}
