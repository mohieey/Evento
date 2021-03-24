namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderTicket : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ticket", "Order_ID", "dbo.Orders");
            DropIndex("dbo.Ticket", new[] { "Order_ID" });
            CreateTable(
                "dbo.OrderTickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        orderId = c.Int(nullable: false),
                        ticketId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.orderId, cascadeDelete: true)
                .ForeignKey("dbo.Ticket", t => t.ticketId, cascadeDelete: true)
                .Index(t => t.orderId)
                .Index(t => t.ticketId);
            
            DropColumn("dbo.Ticket", "Order_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ticket", "Order_ID", c => c.Int());
            DropForeignKey("dbo.OrderTickets", "ticketId", "dbo.Ticket");
            DropForeignKey("dbo.OrderTickets", "orderId", "dbo.Orders");
            DropIndex("dbo.OrderTickets", new[] { "ticketId" });
            DropIndex("dbo.OrderTickets", new[] { "orderId" });
            DropTable("dbo.OrderTickets");
            CreateIndex("dbo.Ticket", "Order_ID");
            AddForeignKey("dbo.Ticket", "Order_ID", "dbo.Orders", "ID");
        }
    }
}
