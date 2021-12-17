namespace Notepad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDBAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Notes", "User_Id", c => c.Int());
            CreateIndex("dbo.Notes", "User_Id");
            AddForeignKey("dbo.Notes", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "User_Id", "dbo.Users");
            DropIndex("dbo.Notes", new[] { "User_Id" });
            DropColumn("dbo.Notes", "User_Id");
            DropTable("dbo.Users");
        }
    }
}
