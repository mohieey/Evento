namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "location", c => c.String());
            DropColumn("dbo.Event", "location_country");
            DropColumn("dbo.Event", "location_city");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Event", "location_city", c => c.String());
            AddColumn("dbo.Event", "location_country", c => c.String());
            DropColumn("dbo.Event", "location");
        }
    }
}
