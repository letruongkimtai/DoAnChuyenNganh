namespace DoAnChuyenNganh.Ver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relation_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CTmonans", "Maloai", c => c.Int());
            AddColumn("dbo.LoaiMons", "Mamon", c => c.Int(nullable: false));
            CreateIndex("dbo.CTmonans", "Maloai");
            AddForeignKey("dbo.CTmonans", "Maloai", "dbo.LoaiMons", "Maloai");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CTmonans", "Maloai", "dbo.LoaiMons");
            DropIndex("dbo.CTmonans", new[] { "Maloai" });
            DropColumn("dbo.LoaiMons", "Mamon");
            DropColumn("dbo.CTmonans", "Maloai");
        }
    }
}
