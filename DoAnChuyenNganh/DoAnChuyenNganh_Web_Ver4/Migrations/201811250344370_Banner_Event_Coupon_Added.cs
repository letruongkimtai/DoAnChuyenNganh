namespace DoAnChuyenNganh_Web_Ver4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Banner_Event_Coupon_Added : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
            DropTable("dbo.Coupons");
            DropTable("dbo.Banners");
        }
    }
}
