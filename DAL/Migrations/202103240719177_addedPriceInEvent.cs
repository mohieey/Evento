namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPriceInEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Event", "price");
        }
    }
}
