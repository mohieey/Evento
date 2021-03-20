namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingUserInEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Event", "User_Id");
            AddForeignKey("dbo.Event", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Event", new[] { "User_Id" });
            DropColumn("dbo.Event", "User_Id");
        }
    }
}
