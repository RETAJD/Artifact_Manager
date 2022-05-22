namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Uprawnienia_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Uprawnienias",
                c => new
                    {
                        ID_Roli = c.Int(nullable: false, identity: true),
                        Rola = c.String(),
                        rodzaj = c.String(),
                    })
                .PrimaryKey(t => t.ID_Roli);
            
            AddColumn("dbo.Roles", "Uprawnienia_ID_Roli", c => c.Int());
            CreateIndex("dbo.Roles", "Uprawnienia_ID_Roli");
            AddForeignKey("dbo.Roles", "Uprawnienia_ID_Roli", "dbo.Uprawnienias", "ID_Roli");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roles", "Uprawnienia_ID_Roli", "dbo.Uprawnienias");
            DropIndex("dbo.Roles", new[] { "Uprawnienia_ID_Roli" });
            DropColumn("dbo.Roles", "Uprawnienia_ID_Roli");
            DropTable("dbo.Uprawnienias");
        }
    }
}
