namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a7eh : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ticket", "event_ID", "dbo.Event");
            DropIndex("dbo.Ticket", new[] { "event_ID" });
            RenameColumn(table: "dbo.Ticket", name: "Client_Id", newName: "clientId");
            RenameColumn(table: "dbo.Ticket", name: "event_ID", newName: "eventId");
            RenameIndex(table: "dbo.Ticket", name: "IX_Client_Id", newName: "IX_clientId");
            AlterColumn("dbo.Ticket", "eventId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ticket", "eventId");
            AddForeignKey("dbo.Ticket", "eventId", "dbo.Event", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ticket", "eventId", "dbo.Event");
            DropIndex("dbo.Ticket", new[] { "eventId" });
            AlterColumn("dbo.Ticket", "eventId", c => c.Int());
            RenameIndex(table: "dbo.Ticket", name: "IX_clientId", newName: "IX_Client_Id");
            RenameColumn(table: "dbo.Ticket", name: "eventId", newName: "event_ID");
            RenameColumn(table: "dbo.Ticket", name: "clientId", newName: "Client_Id");
            CreateIndex("dbo.Ticket", "event_ID");
            AddForeignKey("dbo.Ticket", "event_ID", "dbo.Event", "ID");
        }
    }
}
