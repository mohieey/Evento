namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingClientIdInOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "appUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "appUser_Id" });
            RenameColumn(table: "dbo.Orders", name: "ClientUser_Id", newName: "clientId");
            RenameIndex(table: "dbo.Orders", name: "IX_ClientUser_Id", newName: "IX_clientId");
            DropColumn("dbo.Orders", "appUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "appUser_Id", c => c.String(maxLength: 128));
            RenameIndex(table: "dbo.Orders", name: "IX_clientId", newName: "IX_ClientUser_Id");
            RenameColumn(table: "dbo.Orders", name: "clientId", newName: "ClientUser_Id");
            CreateIndex("dbo.Orders", "appUser_Id");
            AddForeignKey("dbo.Orders", "appUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
