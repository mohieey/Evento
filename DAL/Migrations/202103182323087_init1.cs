namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ticket", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ticket", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
