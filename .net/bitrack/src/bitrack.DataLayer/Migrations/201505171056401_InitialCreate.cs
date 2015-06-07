namespace bitrack.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        SessionId = c.Guid(nullable: false),
                        EventID = c.Int(nullable: false),
                        Category = c.String(),
                        Action = c.String(),
                        Label = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        WebsiteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Websites", t => t.WebsiteID, cascadeDelete: true)
                .Index(t => t.WebsiteID);
            
            CreateTable(
                "dbo.Websites",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Goals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Value = c.String(),
                        WebsiteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Websites", t => t.WebsiteID, cascadeDelete: true)
                .Index(t => t.WebsiteID);
            
            CreateTable(
                "dbo.GoalLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        GoalID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Goals", t => t.GoalID, cascadeDelete: true)
                .Index(t => t.GoalID);
            
            CreateTable(
                "dbo.WebsiteUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        IsOwner = c.Boolean(nullable: false),
                        WebsiteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Websites", t => t.WebsiteID, cascadeDelete: true)
                .Index(t => t.WebsiteID);
            
            CreateTable(
                "dbo.ExperimentVariationLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false),
                        ExperimentVariationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ExperimentVariations", t => t.ExperimentVariationID, cascadeDelete: true)
                .Index(t => t.ExperimentVariationID);
            
            CreateTable(
                "dbo.ExperimentVariations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ExperimentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Experiments", t => t.ExperimentID, cascadeDelete: true)
                .Index(t => t.ExperimentID);
            
            CreateTable(
                "dbo.Experiments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        TrafficPercent = c.Int(nullable: false),
                        DurationType = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        GoalID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Goals", t => t.GoalID, cascadeDelete: true)
                .Index(t => t.GoalID);
            
            CreateTable(
                "dbo.PageviewLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        SessionId = c.Guid(nullable: false),
                        UserAgent = c.String(),
                        IPAdress = c.String(),
                        PageviewID = c.Int(nullable: false),
                        RefferID = c.Int(),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pageviews", t => t.PageviewID, cascadeDelete: true)
                .ForeignKey("dbo.PageviewLogs", t => t.RefferID)
                .Index(t => t.PageviewID)
                .Index(t => t.RefferID);
            
            CreateTable(
                "dbo.Pageviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        WebsiteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Websites", t => t.WebsiteID, cascadeDelete: true)
                .Index(t => t.WebsiteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PageviewLogs", "RefferID", "dbo.PageviewLogs");
            DropForeignKey("dbo.Pageviews", "WebsiteID", "dbo.Websites");
            DropForeignKey("dbo.PageviewLogs", "PageviewID", "dbo.Pageviews");
            DropForeignKey("dbo.ExperimentVariationLogs", "ExperimentVariationID", "dbo.ExperimentVariations");
            DropForeignKey("dbo.ExperimentVariations", "ExperimentID", "dbo.Experiments");
            DropForeignKey("dbo.Experiments", "GoalID", "dbo.Goals");
            DropForeignKey("dbo.Events", "WebsiteID", "dbo.Websites");
            DropForeignKey("dbo.WebsiteUsers", "WebsiteID", "dbo.Websites");
            DropForeignKey("dbo.Goals", "WebsiteID", "dbo.Websites");
            DropForeignKey("dbo.GoalLogs", "GoalID", "dbo.Goals");
            DropForeignKey("dbo.EventLogs", "EventID", "dbo.Events");
            DropIndex("dbo.Pageviews", new[] { "WebsiteID" });
            DropIndex("dbo.PageviewLogs", new[] { "RefferID" });
            DropIndex("dbo.PageviewLogs", new[] { "PageviewID" });
            DropIndex("dbo.Experiments", new[] { "GoalID" });
            DropIndex("dbo.ExperimentVariations", new[] { "ExperimentID" });
            DropIndex("dbo.ExperimentVariationLogs", new[] { "ExperimentVariationID" });
            DropIndex("dbo.WebsiteUsers", new[] { "WebsiteID" });
            DropIndex("dbo.GoalLogs", new[] { "GoalID" });
            DropIndex("dbo.Goals", new[] { "WebsiteID" });
            DropIndex("dbo.Events", new[] { "WebsiteID" });
            DropIndex("dbo.EventLogs", new[] { "EventID" });
            DropTable("dbo.Pageviews");
            DropTable("dbo.PageviewLogs");
            DropTable("dbo.Experiments");
            DropTable("dbo.ExperimentVariations");
            DropTable("dbo.ExperimentVariationLogs");
            DropTable("dbo.WebsiteUsers");
            DropTable("dbo.GoalLogs");
            DropTable("dbo.Goals");
            DropTable("dbo.Websites");
            DropTable("dbo.Events");
            DropTable("dbo.EventLogs");
        }
    }
}
