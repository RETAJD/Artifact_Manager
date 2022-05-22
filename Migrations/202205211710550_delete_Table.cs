namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_Table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Roles", "Uprawnienia_ID_Roli", "dbo.Uprawnienias");
            DropIndex("dbo.Roles", new[] { "Uprawnienia_ID_Roli" });
            AddColumn("dbo.Roles", "rodzaj", c => c.String());
            DropColumn("dbo.Roles", "Uprawnienia_ID_Roli");
            DropTable("dbo.Uprawnienias");
        }
        
        public override void Down()
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
            DropColumn("dbo.Roles", "rodzaj");
            CreateIndex("dbo.Roles", "Uprawnienia_ID_Roli");
            AddForeignKey("dbo.Roles", "Uprawnienia_ID_Roli", "dbo.Uprawnienias", "ID_Roli");
        }
    }
}
