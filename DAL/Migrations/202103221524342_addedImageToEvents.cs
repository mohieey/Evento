namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedImageToEvents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Event", "image");
        }
    }
}
