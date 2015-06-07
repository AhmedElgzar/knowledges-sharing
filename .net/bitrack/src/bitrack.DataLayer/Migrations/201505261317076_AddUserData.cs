namespace bitrack.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventLogs", "Browser", c => c.String());
            AddColumn("dbo.EventLogs", "IPAdress", c => c.String());
            AddColumn("dbo.EventLogs", "Country", c => c.String());
            AddColumn("dbo.EventLogs", "City", c => c.String());
            AddColumn("dbo.EventLogs", "OS", c => c.String());
            AddColumn("dbo.EventLogs", "Language", c => c.String());
            AddColumn("dbo.PageviewLogs", "Browser", c => c.String());
            AddColumn("dbo.PageviewLogs", "Country", c => c.String());
            AddColumn("dbo.PageviewLogs", "City", c => c.String());
            AddColumn("dbo.PageviewLogs", "OS", c => c.String());
            AddColumn("dbo.PageviewLogs", "Language", c => c.String());
            DropColumn("dbo.PageviewLogs", "UserAgent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PageviewLogs", "UserAgent", c => c.String());
            DropColumn("dbo.PageviewLogs", "Language");
            DropColumn("dbo.PageviewLogs", "OS");
            DropColumn("dbo.PageviewLogs", "City");
            DropColumn("dbo.PageviewLogs", "Country");
            DropColumn("dbo.PageviewLogs", "Browser");
            DropColumn("dbo.EventLogs", "Language");
            DropColumn("dbo.EventLogs", "OS");
            DropColumn("dbo.EventLogs", "City");
            DropColumn("dbo.EventLogs", "Country");
            DropColumn("dbo.EventLogs", "IPAdress");
            DropColumn("dbo.EventLogs", "Browser");
        }
    }
}
