namespace DoAnChuyenNganh_Web_Ver4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orderdt_Orders_added_to_database : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PaymentMethod", c => c.String());
            AddColumn("dbo.Orders", "PaymentCheck", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "DeliveryStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Orders", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Total", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "DeliveryStatus");
            DropColumn("dbo.Orders", "PaymentCheck");
            DropColumn("dbo.Orders", "PaymentMethod");
        }
    }
}
