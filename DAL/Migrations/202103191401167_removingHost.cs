namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removingHost : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Event", "Host_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Event", new[] { "Host_Id" });
            DropColumn("dbo.Event", "Host_Id");
            DropColumn("dbo.AspNetUsers", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Event", "Host_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Event", "Host_Id");
            AddForeignKey("dbo.Event", "Host_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
