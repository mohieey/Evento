namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dddd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ticket", "Order_ID", "dbo.Orders");
            DropIndex("dbo.Ticket", new[] { "Order_ID" });
            RenameColumn(table: "dbo.Ticket", name: "Order_ID", newName: "OrderID");
            AddColumn("dbo.Ticket", "date", c => c.DateTime());
            AddColumn("dbo.Event", "image", c => c.String());
            AlterColumn("dbo.Ticket", "OrderID", c => c.Int(nullable: false));
            CreateIndex("dbo.Ticket", "OrderID");
            AddForeignKey("dbo.Ticket", "OrderID", "dbo.Orders", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ticket", "OrderID", "dbo.Orders");
            DropIndex("dbo.Ticket", new[] { "OrderID" });
            AlterColumn("dbo.Ticket", "OrderID", c => c.Int());
            DropColumn("dbo.Event", "image");
            DropColumn("dbo.Ticket", "date");
            RenameColumn(table: "dbo.Ticket", name: "OrderID", newName: "Order_ID");
            CreateIndex("dbo.Ticket", "Order_ID");
            AddForeignKey("dbo.Ticket", "Order_ID", "dbo.Orders", "ID");
        }
    }
}
