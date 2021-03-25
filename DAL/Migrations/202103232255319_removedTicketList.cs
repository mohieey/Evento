namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedTicketList : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ticket", "ShoppingCart_ID", "dbo.ShoppingCarts");
            DropIndex("dbo.Ticket", new[] { "ShoppingCart_ID" });
            DropColumn("dbo.Ticket", "ShoppingCart_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ticket", "ShoppingCart_ID", c => c.Int());
            CreateIndex("dbo.Ticket", "ShoppingCart_ID");
            AddForeignKey("dbo.Ticket", "ShoppingCart_ID", "dbo.ShoppingCarts", "ID");
        }
    }
}
