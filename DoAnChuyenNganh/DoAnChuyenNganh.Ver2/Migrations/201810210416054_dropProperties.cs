namespace DoAnChuyenNganh.Ver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CTmonans", "Maloai", "dbo.LoaiMons");
            DropIndex("dbo.CTmonans", new[] { "Maloai" });
            DropColumn("dbo.CTmonans", "Maloai");
            DropColumn("dbo.LoaiMons", "Mamon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoaiMons", "Mamon", c => c.Int(nullable: false));
            AddColumn("dbo.CTmonans", "Maloai", c => c.Int());
            CreateIndex("dbo.CTmonans", "Maloai");
            AddForeignKey("dbo.CTmonans", "Maloai", "dbo.LoaiMons", "Maloai");
        }
    }
}
