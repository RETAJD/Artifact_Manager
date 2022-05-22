namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmiana_Roli : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "pozwolenia_wszystkie", c => c.String());
            DropColumn("dbo.Roles", "admin");
            DropColumn("dbo.Roles", "wyswietlanie");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "wyswietlanie", c => c.String());
            AddColumn("dbo.Roles", "admin", c => c.String());
            DropColumn("dbo.Roles", "pozwolenia_wszystkie");
        }
    }
}
