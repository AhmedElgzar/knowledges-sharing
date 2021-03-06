namespace yInvoice.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_EMails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Email", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Companies", "Email");
        }
    }
}
