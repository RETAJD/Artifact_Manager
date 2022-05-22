namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "admin", c => c.String());
            AddColumn("dbo.Roles", "wyswietlanie", c => c.String());
            DropColumn("dbo.Roles", "rodzaj");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "rodzaj", c => c.String());
            DropColumn("dbo.Roles", "wyswietlanie");
            DropColumn("dbo.Roles", "admin");
        }
    }
}
