namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kol_col : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ktora_kategoria", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "ktora_kategoria");
        }
    }
}
