namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Elements");
            AddColumn("dbo.Elements", "ID_ele", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Elements", "kategoria_ele", c => c.String());
            AddPrimaryKey("dbo.Elements", "ID_ele");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Elements");
            AlterColumn("dbo.Elements", "kategoria_ele", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Elements", "ID_ele");
            AddPrimaryKey("dbo.Elements", "kategoria_ele");
        }
    }
}
