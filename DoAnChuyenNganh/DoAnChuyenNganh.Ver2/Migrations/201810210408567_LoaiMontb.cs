namespace DoAnChuyenNganh.Ver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoaiMontb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoaiMons",
                c => new
                    {
                        Maloai = c.Int(nullable: false, identity: true),
                        Tenloai = c.String(),
                        Mamon = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Maloai);
            
            AddColumn("dbo.CTmonans", "Maloai", c => c.Int());
            CreateIndex("dbo.CTmonans", "Maloai");
            AddForeignKey("dbo.CTmonans", "Maloai", "dbo.LoaiMons", "Maloai");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CTmonans", "Maloai", "dbo.LoaiMons");
            DropIndex("dbo.CTmonans", new[] { "Maloai" });
            DropColumn("dbo.CTmonans", "Maloai");
            DropTable("dbo.LoaiMons");
        }
    }
}
