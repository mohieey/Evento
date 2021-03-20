namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHostClient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ticket", "owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Event", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Event", new[] { "User_Id" });
            DropIndex("dbo.Ticket", new[] { "owner_Id" });
            CreateTable(
                "dbo.HostUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ClientUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        shoppingCart_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShoppingCarts", t => t.shoppingCart_ID)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.shoppingCart_ID);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        totalPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Event", "Host_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Ticket", "ShoppingCart_ID", c => c.Int());
            AddColumn("dbo.Ticket", "Client_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Orders", "ClientUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Event", "Host_Id");
            CreateIndex("dbo.Ticket", "ShoppingCart_ID");
            CreateIndex("dbo.Ticket", "Client_Id");
            CreateIndex("dbo.Orders", "ClientUser_Id");
            AddForeignKey("dbo.Event", "Host_Id", "dbo.HostUsers", "Id");
            AddForeignKey("dbo.Orders", "ClientUser_Id", "dbo.ClientUsers", "Id");
            AddForeignKey("dbo.Ticket", "ShoppingCart_ID", "dbo.ShoppingCarts", "ID");
            AddForeignKey("dbo.Ticket", "Client_Id", "dbo.ClientUsers", "Id");
            DropColumn("dbo.Event", "User_Id");
            DropColumn("dbo.Ticket", "owner_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ticket", "owner_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Event", "User_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Ticket", "Client_Id", "dbo.ClientUsers");
            DropForeignKey("dbo.ClientUsers", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ClientUsers", "shoppingCart_ID", "dbo.ShoppingCarts");
            DropForeignKey("dbo.Ticket", "ShoppingCart_ID", "dbo.ShoppingCarts");
            DropForeignKey("dbo.Orders", "ClientUser_Id", "dbo.ClientUsers");
            DropForeignKey("dbo.HostUsers", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Event", "Host_Id", "dbo.HostUsers");
            DropIndex("dbo.Orders", new[] { "ClientUser_Id" });
            DropIndex("dbo.ClientUsers", new[] { "shoppingCart_ID" });
            DropIndex("dbo.ClientUsers", new[] { "Id" });
            DropIndex("dbo.Ticket", new[] { "Client_Id" });
            DropIndex("dbo.Ticket", new[] { "ShoppingCart_ID" });
            DropIndex("dbo.HostUsers", new[] { "Id" });
            DropIndex("dbo.Event", new[] { "Host_Id" });
            DropColumn("dbo.Orders", "ClientUser_Id");
            DropColumn("dbo.Ticket", "Client_Id");
            DropColumn("dbo.Ticket", "ShoppingCart_ID");
            DropColumn("dbo.Event", "Host_Id");
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.ClientUsers");
            DropTable("dbo.HostUsers");
            CreateIndex("dbo.Ticket", "owner_Id");
            CreateIndex("dbo.Event", "User_Id");
            AddForeignKey("dbo.Event", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Ticket", "owner_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
