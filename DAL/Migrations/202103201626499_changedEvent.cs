namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "HostId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Event", "HostId");
        }
    }
}
