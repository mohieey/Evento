namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNameToEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Event", "Name");
        }
    }
}
