namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaZpozwoleniami : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.onlyPozwolenias",
                c => new
                    {
                        pozwolenie_pojedyncze = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.pozwolenie_pojedyncze);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.onlyPozwolenias");
        }
    }
}
