namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedshpcrt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClientId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ClientUsers", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            AddColumn("dbo.Ticket", "ShoppingCart_ID", c => c.Int());
            CreateIndex("dbo.Ticket", "ShoppingCart_ID");
            AddForeignKey("dbo.Ticket", "ShoppingCart_ID", "dbo.ShoppingCarts", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ticket", "ShoppingCart_ID", "dbo.ShoppingCarts");
            DropForeignKey("dbo.ShoppingCarts", "ClientId", "dbo.ClientUsers");
            DropIndex("dbo.ShoppingCarts", new[] { "ClientId" });
            DropIndex("dbo.Ticket", new[] { "ShoppingCart_ID" });
            DropColumn("dbo.Ticket", "ShoppingCart_ID");
            DropTable("dbo.ShoppingCarts");
        }
    }
}
