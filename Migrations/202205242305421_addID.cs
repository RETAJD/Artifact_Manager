namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Categories");
            AddColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Categories", "poj_kategoria", c => c.String());
            AddPrimaryKey("dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "poj_kategoria", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Categories", "Id");
            AddPrimaryKey("dbo.Categories", "poj_kategoria");
        }
    }
}
