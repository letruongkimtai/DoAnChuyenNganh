namespace DoAnChuyenNganh_Web_Ver5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Admin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdmID = c.Int(nullable: false, identity: true),
                        AdmName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdmID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
