namespace Notepad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notes", "User_Id", "dbo.Users");
            DropIndex("dbo.Notes", new[] { "User_Id" });
            RenameColumn(table: "dbo.Notes", name: "User_Id", newName: "User_Email");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Notes", "User_Email", c => c.String(maxLength: 128));
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Users", "Email");
            CreateIndex("dbo.Notes", "User_Email");
            AddForeignKey("dbo.Notes", "User_Email", "dbo.Users", "Email");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "User_Email", "dbo.Users");
            DropIndex("dbo.Notes", new[] { "User_Email" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Notes", "User_Email", c => c.Int());
            AddPrimaryKey("dbo.Users", "Id");
            RenameColumn(table: "dbo.Notes", name: "User_Email", newName: "User_Id");
            CreateIndex("dbo.Notes", "User_Id");
            AddForeignKey("dbo.Notes", "User_Id", "dbo.Users", "Id");
        }
    }
}
