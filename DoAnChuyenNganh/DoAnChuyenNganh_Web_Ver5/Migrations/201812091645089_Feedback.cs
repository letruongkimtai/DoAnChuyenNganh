namespace DoAnChuyenNganh_Web_Ver5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Feedback : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedBack",
                c => new
                    {
                        PrID = c.Int(nullable: false),
                        CtmID = c.Int(nullable: false),
                        FbContent = c.String(),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PrID, t.CtmID })
                .ForeignKey("dbo.Customers", t => t.CtmID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.PrID, cascadeDelete: true)
                .Index(t => t.PrID)
                .Index(t => t.CtmID);
            
            AddColumn("dbo.Banners", "URL", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeedBack", "PrID", "dbo.Products");
            DropForeignKey("dbo.FeedBack", "CtmID", "dbo.Customers");
            DropIndex("dbo.FeedBack", new[] { "CtmID" });
            DropIndex("dbo.FeedBack", new[] { "PrID" });
            DropColumn("dbo.Banners", "URL");
            DropTable("dbo.FeedBack");
        }
    }
}
