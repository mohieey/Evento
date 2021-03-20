namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingHost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "Host_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Event", "Host_Id");
            AddForeignKey("dbo.Event", "Host_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "Host_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Event", new[] { "Host_Id" });
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.Event", "Host_Id");
        }
    }
}
