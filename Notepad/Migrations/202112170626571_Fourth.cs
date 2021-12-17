namespace Notepad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fourth : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Id", c => c.Int(nullable: false));
        }
    }
}
