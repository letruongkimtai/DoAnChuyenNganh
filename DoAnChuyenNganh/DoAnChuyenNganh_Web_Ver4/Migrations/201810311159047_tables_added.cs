namespace DoAnChuyenNganh_Web_Ver4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tables_added : DbMigration
    {
        public override void Up()
        {
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
                        Tell = c.Int(nullable: false),
                        Eaddr = c.String(),
                    })
                .PrimaryKey(t => t.CtmID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Odate = c.DateTime(nullable: false),
                        Total = c.Int(nullable: false),
                        CtmID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CtmID, cascadeDelete: true)
                .Index(t => t.CtmID);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.TypeID);
            
            AddColumn("dbo.Products", "TypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "TypeID");
            AddForeignKey("dbo.Products", "TypeID", "dbo.ProductTypes", "TypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "TypeID", "dbo.ProductTypes");
            DropForeignKey("dbo.Orders", "CtmID", "dbo.Customers");
            DropIndex("dbo.Products", new[] { "TypeID" });
            DropIndex("dbo.Orders", new[] { "CtmID" });
            DropColumn("dbo.Products", "TypeID");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
