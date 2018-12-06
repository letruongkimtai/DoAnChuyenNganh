namespace DoAnChuyenNganh_Web_Ver5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBoughtElement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "BeenBought", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "BeenBought");
        }
    }
}
