namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "TotalAvailableTickets", c => c.Int(nullable: false));
            AddColumn("dbo.Event", "isCanceled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Ticket", "Order_ID", c => c.Int());
            CreateIndex("dbo.Ticket", "Order_ID");
            AddForeignKey("dbo.Ticket", "Order_ID", "dbo.Orders", "ID");
            DropColumn("dbo.Ticket", "isBooked");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ticket", "isBooked", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Ticket", "Order_ID", "dbo.Orders");
            DropIndex("dbo.Ticket", new[] { "Order_ID" });
            DropColumn("dbo.Ticket", "Order_ID");
            DropColumn("dbo.Event", "isCanceled");
            DropColumn("dbo.Event", "TotalAvailableTickets");
        }
    }
}
