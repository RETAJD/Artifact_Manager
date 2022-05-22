namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Roles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        username = c.String(nullable: false, maxLength: 128),
                        rola = c.String(),
                    })
                .PrimaryKey(t => t.username);
            
            AddColumn("dbo.Users", "Roles_username", c => c.String(maxLength: 128));
            CreateIndex("dbo.Users", "Roles_username");
            AddForeignKey("dbo.Users", "Roles_username", "dbo.Roles", "username");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Roles_username", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "Roles_username" });
            DropColumn("dbo.Users", "Roles_username");
            DropTable("dbo.Roles");
        }
    }
}
