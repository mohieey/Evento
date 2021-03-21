namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedShoppingCartIdInClientUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClientUsers", "shoppingCart_ID", "dbo.ShoppingCarts");
            DropIndex("dbo.ClientUsers", new[] { "shoppingCart_ID" });
            RenameColumn(table: "dbo.ClientUsers", name: "shoppingCart_ID", newName: "shoppingCartId");
            AlterColumn("dbo.ClientUsers", "shoppingCartId", c => c.Int(nullable: false));
            CreateIndex("dbo.ClientUsers", "shoppingCartId");
            AddForeignKey("dbo.ClientUsers", "shoppingCartId", "dbo.ShoppingCarts", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientUsers", "shoppingCartId", "dbo.ShoppingCarts");
            DropIndex("dbo.ClientUsers", new[] { "shoppingCartId" });
            AlterColumn("dbo.ClientUsers", "shoppingCartId", c => c.Int());
            RenameColumn(table: "dbo.ClientUsers", name: "shoppingCartId", newName: "shoppingCart_ID");
            CreateIndex("dbo.ClientUsers", "shoppingCart_ID");
            AddForeignKey("dbo.ClientUsers", "shoppingCart_ID", "dbo.ShoppingCarts", "ID");
        }
    }
}
