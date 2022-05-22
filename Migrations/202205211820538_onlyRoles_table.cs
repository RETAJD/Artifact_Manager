namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onlyRoles_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.onlyRoles",
                c => new
                    {
                        Rola_pojedyncza = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Rola_pojedyncza);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.onlyRoles");
        }
    }
}
