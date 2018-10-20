namespace DoAnChuyenNganh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaoBang2Khoa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.CategoryID })
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Details", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Details", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Details", new[] { "CategoryID" });
            DropIndex("dbo.Details", new[] { "ProductID" });
            DropTable("dbo.Details");
        }
    }
}
