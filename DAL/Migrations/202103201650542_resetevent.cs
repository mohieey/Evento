namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resetevent : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Event", "HostId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Event", "HostId", c => c.String());
        }
    }
}
