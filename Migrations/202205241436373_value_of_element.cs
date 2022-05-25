namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class value_of_element : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.elements_values", "nazwa_wartosci", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.elements_values", "nazwa_wartosci");
        }
    }
}
