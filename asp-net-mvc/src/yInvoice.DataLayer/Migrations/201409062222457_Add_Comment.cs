namespace yInvoice.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Comment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "Comment");
        }
    }
}
