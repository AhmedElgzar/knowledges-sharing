namespace yInvoice.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Adress = c.String(),
                        Zip = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClientID = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.ClientID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Adress = c.String(),
                        Zip = c.String(),
                        Phone = c.String(),
                        CompanyID = c.Int(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.InvoiceItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty = c.Int(nullable: false),
                        Description = c.String(),
                        InvoiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Invoices", t => t.InvoiceID, cascadeDelete: true)
                .Index(t => t.InvoiceID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        ClientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ClientID, cascadeDelete: true)
                .Index(t => t.ClientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "ClientID", "dbo.Users");
            DropForeignKey("dbo.InvoiceItems", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "ClientID", "dbo.Users");
            DropForeignKey("dbo.Users", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Items", new[] { "ClientID" });
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceID" });
            DropIndex("dbo.Users", new[] { "CompanyID" });
            DropIndex("dbo.Invoices", new[] { "CompanyID" });
            DropIndex("dbo.Invoices", new[] { "ClientID" });
            DropTable("dbo.Items");
            DropTable("dbo.InvoiceItems");
            DropTable("dbo.Users");
            DropTable("dbo.Invoices");
            DropTable("dbo.Companies");
        }
    }
}
