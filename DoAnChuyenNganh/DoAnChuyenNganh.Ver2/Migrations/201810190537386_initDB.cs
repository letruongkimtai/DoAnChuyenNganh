namespace DoAnChuyenNganh.Ver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CTmonans",
                c => new
                    {
                        Mamon = c.Int(nullable: false, identity: true),
                        Tenmon = c.String(),
                        Ngayban = c.DateTime(),
                        Giaban = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Anh = c.String(),
                        Trangthai = c.String(),
                        Mota = c.String(),
                    })
                .PrimaryKey(t => t.Mamon);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CTmonans");
        }
    }
}
