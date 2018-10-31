namespace DoAnChuyenNganh_Web_Ver4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WebsiteDB : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.PrID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
