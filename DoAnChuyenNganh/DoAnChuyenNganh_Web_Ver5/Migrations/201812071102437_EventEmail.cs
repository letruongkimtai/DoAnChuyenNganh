namespace DoAnChuyenNganh_Web_Ver5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventEmail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventEmails",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Email);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EventEmails");
        }
    }
}
