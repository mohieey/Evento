namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cleanUp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ticket", "ShoppingCart_ID", "dbo.ShoppingCarts");
            DropForeignKey("dbo.ClientUsers", "shoppingCartId", "dbo.ShoppingCarts");
            DropForeignKey("dbo.Ticket", "event_ID", "dbo.Event");
            DropIndex("dbo.ClientUsers", new[] { "shoppingCartId" });
            DropIndex("dbo.Ticket", new[] { "event_ID" });
            DropIndex("dbo.Ticket", new[] { "ShoppingCart_ID" });
            RenameColumn(table: "dbo.Ticket", name: "Client_Id", newName: "clientId");
            RenameColumn(table: "dbo.Ticket", name: "event_ID", newName: "eventId");
            RenameIndex(table: "dbo.Ticket", name: "IX_Client_Id", newName: "IX_clientId");
            AddColumn("dbo.Ticket", "date", c => c.DateTime());
            AddColumn("dbo.Event", "image", c => c.String());
            AlterColumn("dbo.Ticket", "eventId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ticket", "eventId");
            AddForeignKey("dbo.Ticket", "eventId", "dbo.Event", "ID", cascadeDelete: true);
            DropColumn("dbo.ClientUsers", "shoppingCartId");
            DropColumn("dbo.Orders", "date");
            DropColumn("dbo.Orders", "discount");
            DropColumn("dbo.Ticket", "class");
            DropColumn("dbo.Ticket", "ShoppingCart_ID");
            DropTable("dbo.ShoppingCarts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        totalPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Ticket", "ShoppingCart_ID", c => c.Int());
            AddColumn("dbo.Ticket", "class", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "discount", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "date", c => c.DateTime(nullable: false));
            AddColumn("dbo.ClientUsers", "shoppingCartId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Ticket", "eventId", "dbo.Event");
            DropIndex("dbo.Ticket", new[] { "eventId" });
            AlterColumn("dbo.Ticket", "eventId", c => c.Int());
            DropColumn("dbo.Event", "image");
            DropColumn("dbo.Ticket", "date");
            RenameIndex(table: "dbo.Ticket", name: "IX_clientId", newName: "IX_Client_Id");
            RenameColumn(table: "dbo.Ticket", name: "eventId", newName: "event_ID");
            RenameColumn(table: "dbo.Ticket", name: "clientId", newName: "Client_Id");
            CreateIndex("dbo.Ticket", "ShoppingCart_ID");
            CreateIndex("dbo.Ticket", "event_ID");
            CreateIndex("dbo.ClientUsers", "shoppingCartId");
            AddForeignKey("dbo.Ticket", "event_ID", "dbo.Event", "ID");
            AddForeignKey("dbo.ClientUsers", "shoppingCartId", "dbo.ShoppingCarts", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Ticket", "ShoppingCart_ID", "dbo.ShoppingCarts", "ID");
        }
    }
}
