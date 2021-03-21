namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedHostIdInEvent : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Event", name: "Host_Id", newName: "HostId");
            RenameIndex(table: "dbo.Event", name: "IX_Host_Id", newName: "IX_HostId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Event", name: "IX_HostId", newName: "IX_Host_Id");
            RenameColumn(table: "dbo.Event", name: "HostId", newName: "Host_Id");
        }
    }
}
