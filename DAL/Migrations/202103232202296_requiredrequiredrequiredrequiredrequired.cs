namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredrequiredrequiredrequiredrequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingCarts", "ClientId", "dbo.ClientUsers");
            DropIndex("dbo.ShoppingCarts", new[] { "ClientId" });
            AlterColumn("dbo.ShoppingCarts", "ClientId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ShoppingCarts", "ClientId");
            AddForeignKey("dbo.ShoppingCarts", "ClientId", "dbo.ClientUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "ClientId", "dbo.ClientUsers");
            DropIndex("dbo.ShoppingCarts", new[] { "ClientId" });
            AlterColumn("dbo.ShoppingCarts", "ClientId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.ShoppingCarts", "ClientId");
            AddForeignKey("dbo.ShoppingCarts", "ClientId", "dbo.ClientUsers", "Id", cascadeDelete: true);
        }
    }
}
