namespace DoAnChuyenNganh_Web_Ver4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requỉed_deleted : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Passwords", c => c.String());
            AlterColumn("dbo.Customers", "CtmName", c => c.String());
            AlterColumn("dbo.Customers", "Tell", c => c.String());
            AlterColumn("dbo.Customers", "Eaddr", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Eaddr", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Tell", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "CtmName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Passwords", c => c.String(nullable: false));
        }
    }
}
