namespace DoAnChuyenNganh_Web_Ver4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixing : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Tell", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Tell", c => c.Int(nullable: false));
        }
    }
}
