namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OnlyTwoColumns : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Users", "UserName");
            DropColumn("dbo.Users", "UserID");
            DropColumn("dbo.Users", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "UserID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "UserName", c => c.String());
            AddPrimaryKey("dbo.Users", "UserID");
        }
    }
}
