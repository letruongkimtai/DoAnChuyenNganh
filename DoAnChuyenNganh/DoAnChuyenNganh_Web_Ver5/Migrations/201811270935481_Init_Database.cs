namespace DoAnChuyenNganh_Web_Ver5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banners",
                c => new
                    {
                        BnID = c.Int(nullable: false, identity: true),
                        BnImg = c.String(),
                        RelsDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BnID);
            
            CreateTable(
                "dbo.Coupons",
                c => new
                    {
                        CouponID = c.String(nullable: false, maxLength: 128),
                        Discount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CouponID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CtmID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Passwords = c.String(),
                        CtmName = c.String(),
                        BDate = c.DateTime(nullable: false),
                        Addr = c.String(),
                        Tell = c.String(),
                        Eaddr = c.String(),
                    })
                .PrimaryKey(t => t.CtmID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        EventTitle = c.String(),
                        StartDay = c.DateTime(nullable: false),
                        EndDay = c.DateTime(nullable: false),
                        EventImg = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.EventID);
            
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
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Odate = c.DateTime(nullable: false),
                        PaymentMethod = c.String(),
                        PaymentCheck = c.Boolean(nullable: false),
                        DeliveryStatus = c.Boolean(nullable: false),
                        CtmID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CtmID, cascadeDelete: true)
                .Index(t => t.CtmID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        PrID = c.Int(nullable: false, identity: true),
                        PrName = c.String(),
                        SellDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pic = c.String(),
                        Status = c.String(),
                        Describe = c.String(),
                        TypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrID)
                .ForeignKey("dbo.ProductTypes", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.TypeID);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.TypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "PrID", "dbo.Products");
            DropForeignKey("dbo.Products", "TypeID", "dbo.ProductTypes");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CtmID", "dbo.Customers");
            DropIndex("dbo.Products", new[] { "TypeID" });
            DropIndex("dbo.Orders", new[] { "CtmID" });
            DropIndex("dbo.OrderDetails", new[] { "PrID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Events");
            DropTable("dbo.Customers");
            DropTable("dbo.Coupons");
            DropTable("dbo.Banners");
        }
    }
}
