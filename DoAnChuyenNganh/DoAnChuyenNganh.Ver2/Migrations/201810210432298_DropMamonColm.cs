namespace DoAnChuyenNganh.Ver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropMamonColm : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LoaiMons", "Mamon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoaiMons", "Mamon", c => c.Int(nullable: false));
        }
    }
}
