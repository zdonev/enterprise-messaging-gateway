namespace EnterpriseMessagingGateway.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCheckIn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgreementResolvers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                        Description = c.String(),
                        Agreement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agreements", t => t.Agreement_Id)
                .Index(t => t.Agreement_Id);
            
            CreateTable(
                "dbo.Agreements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        AgreementHash = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                        CheckForDuplicate = c.Boolean(nullable: false),
                        DocumentType_Id = c.Int(),
                        Receiver_Id = c.Int(),
                        Sender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentType_Id)
                .ForeignKey("dbo.TradingPartners", t => t.Receiver_Id)
                .ForeignKey("dbo.TradingPartners", t => t.Sender_Id)
                .Index(t => t.DocumentType_Id)
                .Index(t => t.Receiver_Id)
                .Index(t => t.Sender_Id);
            
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 4000),
                        DocType = c.String(nullable: false, maxLength: 255),
                        Channel = c.String(nullable: false, maxLength: 255),
                        AgreementResolutionMap = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.DocType, t.Channel }, unique: true, name: "DocumentType_Channel");
            
            CreateTable(
                "dbo.DocumentTypeResolvers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rank = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Value = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 4000),
                        LookupType = c.Int(nullable: false),
                        DocumentType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentType_Id)
                .Index(t => t.DocumentType_Id);
            
            CreateTable(
                "dbo.AgreementLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        User = c.String(),
                        Before = c.String(),
                        After = c.String(),
                        Action = c.String(),
                        Agreement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agreements", t => t.Agreement_Id)
                .Index(t => t.Agreement_Id);
            
            CreateTable(
                "dbo.AgreementProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PropertyName = c.String(),
                        PropertyValue = c.String(),
                        PropertyDescription = c.String(),
                        Agreement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agreements", t => t.Agreement_Id)
                .Index(t => t.Agreement_Id);
            
            CreateTable(
                "dbo.TradingPartners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 4000),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "TP_Name");
            
            CreateTable(
                "dbo.TradingPartnerContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Role = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        Phone = c.String(maxLength: 255),
                        Street = c.String(maxLength: 255),
                        City = c.String(maxLength: 255),
                        State = c.String(maxLength: 255),
                        PostalCode = c.String(maxLength: 255),
                        Country = c.String(maxLength: 255),
                        TradingPartner_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TradingPartners", t => t.TradingPartner_Id, cascadeDelete: true)
                .Index(t => t.TradingPartner_Id);
            
            CreateTable(
                "dbo.TradingPartnerContactProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Value = c.String(nullable: false),
                        Contact_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TradingPartnerContacts", t => t.Contact_Id, cascadeDelete: true)
                .Index(t => t.Contact_Id);
            
            CreateTable(
                "dbo.TradingPartnerIdentifiers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qualifier = c.String(nullable: false, maxLength: 50),
                        Identifier = c.String(nullable: false, maxLength: 100),
                        TradingPartner_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TradingPartners", t => t.TradingPartner_Id, cascadeDelete: true)
                .Index(t => new { t.Qualifier, t.Identifier }, unique: true, name: "TradingPartner_Identity")
                .Index(t => t.TradingPartner_Id);
            
            CreateTable(
                "dbo.TradingPartnerProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Value = c.String(nullable: false),
                        TradingPartner_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TradingPartners", t => t.TradingPartner_Id, cascadeDelete: true)
                .Index(t => t.TradingPartner_Id);
            
            CreateTable(
                "dbo.AgreementTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sequence = c.Int(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        TrackingOn = c.Boolean(nullable: false),
                        ArchivingOn = c.Boolean(nullable: false),
                        Agreement_Id = c.Int(),
                        Task_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agreements", t => t.Agreement_Id)
                .ForeignKey("dbo.Tasks", t => t.Task_Id)
                .Index(t => t.Agreement_Id)
                .Index(t => t.Task_Id);
            
            CreateTable(
                "dbo.AgreementTaskParameters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        AgreementTask_Id = c.Int(),
                        TaskParameter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgreementTasks", t => t.AgreementTask_Id)
                .ForeignKey("dbo.TaskParameters", t => t.TaskParameter_Id)
                .Index(t => t.AgreementTask_Id)
                .Index(t => t.TaskParameter_Id);
            
            CreateTable(
                "dbo.TaskParameters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(nullable: false, maxLength: 255),
                        Required = c.Boolean(nullable: false),
                        Description = c.String(nullable: false, maxLength: 4000),
                        Type = c.Int(nullable: false),
                        Task_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.Task_Id, cascadeDelete: true)
                .Index(t => t.Task_Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 4000),
                        GlobalTracking = c.Boolean(nullable: false),
                        GlobalArchiving = c.Boolean(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "Task_Name");
            
            CreateTable(
                "dbo.TaskProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                        Task_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.Task_Id, cascadeDelete: true)
                .Index(t => t.Task_Id);
            
            CreateTable(
                "dbo.MessageArchives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityId = c.String(nullable: false, maxLength: 255),
                        TaskName = c.String(nullable: false, maxLength: 255),
                        Sequence = c.Int(nullable: false),
                        Context = c.String(),
                        Payload = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskParameters", "Task_Id", "dbo.Tasks");
            DropForeignKey("dbo.TaskProperties", "Task_Id", "dbo.Tasks");
            DropForeignKey("dbo.AgreementTasks", "Task_Id", "dbo.Tasks");
            DropForeignKey("dbo.AgreementTaskParameters", "TaskParameter_Id", "dbo.TaskParameters");
            DropForeignKey("dbo.AgreementTaskParameters", "AgreementTask_Id", "dbo.AgreementTasks");
            DropForeignKey("dbo.AgreementTasks", "Agreement_Id", "dbo.Agreements");
            DropForeignKey("dbo.Agreements", "Sender_Id", "dbo.TradingPartners");
            DropForeignKey("dbo.AgreementResolvers", "Agreement_Id", "dbo.Agreements");
            DropForeignKey("dbo.Agreements", "Receiver_Id", "dbo.TradingPartners");
            DropForeignKey("dbo.TradingPartnerProperties", "TradingPartner_Id", "dbo.TradingPartners");
            DropForeignKey("dbo.TradingPartnerIdentifiers", "TradingPartner_Id", "dbo.TradingPartners");
            DropForeignKey("dbo.TradingPartnerContacts", "TradingPartner_Id", "dbo.TradingPartners");
            DropForeignKey("dbo.TradingPartnerContactProperties", "Contact_Id", "dbo.TradingPartnerContacts");
            DropForeignKey("dbo.AgreementProperties", "Agreement_Id", "dbo.Agreements");
            DropForeignKey("dbo.AgreementLogs", "Agreement_Id", "dbo.Agreements");
            DropForeignKey("dbo.DocumentTypeResolvers", "DocumentType_Id", "dbo.DocumentTypes");
            DropForeignKey("dbo.Agreements", "DocumentType_Id", "dbo.DocumentTypes");
            DropIndex("dbo.TaskProperties", new[] { "Task_Id" });
            DropIndex("dbo.Tasks", "Task_Name");
            DropIndex("dbo.TaskParameters", new[] { "Task_Id" });
            DropIndex("dbo.AgreementTaskParameters", new[] { "TaskParameter_Id" });
            DropIndex("dbo.AgreementTaskParameters", new[] { "AgreementTask_Id" });
            DropIndex("dbo.AgreementTasks", new[] { "Task_Id" });
            DropIndex("dbo.AgreementTasks", new[] { "Agreement_Id" });
            DropIndex("dbo.TradingPartnerProperties", new[] { "TradingPartner_Id" });
            DropIndex("dbo.TradingPartnerIdentifiers", new[] { "TradingPartner_Id" });
            DropIndex("dbo.TradingPartnerIdentifiers", "TradingPartner_Identity");
            DropIndex("dbo.TradingPartnerContactProperties", new[] { "Contact_Id" });
            DropIndex("dbo.TradingPartnerContacts", new[] { "TradingPartner_Id" });
            DropIndex("dbo.TradingPartners", "TP_Name");
            DropIndex("dbo.AgreementProperties", new[] { "Agreement_Id" });
            DropIndex("dbo.AgreementLogs", new[] { "Agreement_Id" });
            DropIndex("dbo.DocumentTypeResolvers", new[] { "DocumentType_Id" });
            DropIndex("dbo.DocumentTypes", "DocumentType_Channel");
            DropIndex("dbo.Agreements", new[] { "Sender_Id" });
            DropIndex("dbo.Agreements", new[] { "Receiver_Id" });
            DropIndex("dbo.Agreements", new[] { "DocumentType_Id" });
            DropIndex("dbo.AgreementResolvers", new[] { "Agreement_Id" });
            DropTable("dbo.MessageArchives");
            DropTable("dbo.TaskProperties");
            DropTable("dbo.Tasks");
            DropTable("dbo.TaskParameters");
            DropTable("dbo.AgreementTaskParameters");
            DropTable("dbo.AgreementTasks");
            DropTable("dbo.TradingPartnerProperties");
            DropTable("dbo.TradingPartnerIdentifiers");
            DropTable("dbo.TradingPartnerContactProperties");
            DropTable("dbo.TradingPartnerContacts");
            DropTable("dbo.TradingPartners");
            DropTable("dbo.AgreementProperties");
            DropTable("dbo.AgreementLogs");
            DropTable("dbo.DocumentTypeResolvers");
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.Agreements");
            DropTable("dbo.AgreementResolvers");
        }
    }
}
