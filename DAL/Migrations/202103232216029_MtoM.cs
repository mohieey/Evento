namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MtoM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCartTickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        shoppingCartId = c.Int(nullable: false),
                        ticketId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShoppingCarts", t => t.shoppingCartId, cascadeDelete: true)
                .ForeignKey("dbo.Ticket", t => t.ticketId, cascadeDelete: true)
                .Index(t => t.shoppingCartId)
                .Index(t => t.ticketId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCartTickets", "ticketId", "dbo.Ticket");
            DropForeignKey("dbo.ShoppingCartTickets", "shoppingCartId", "dbo.ShoppingCarts");
            DropIndex("dbo.ShoppingCartTickets", new[] { "ticketId" });
            DropIndex("dbo.ShoppingCartTickets", new[] { "shoppingCartId" });
            DropTable("dbo.ShoppingCartTickets");
        }
    }
}
