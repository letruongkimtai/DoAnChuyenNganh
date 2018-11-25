namespace DoAnChuyenNganh_Web_Ver4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderDetail_added_to_context : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        PrID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.OrderID, t.PrID })
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.PrID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.PrID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "PrID", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "PrID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropTable("dbo.OrderDetails");
        }
    }
}
