namespace Funds4Kids.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Denominations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EventInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventInfoes", t => t.EventInfo_Id)
                .Index(t => t.EventInfo_Id);
            
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false, defaultValue: DateTime.UtcNow),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SenderEmail = c.String(nullable: false),
                        EventInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventInfoes", t => t.EventInfoId, cascadeDelete: true)
                .Index(t => t.EventInfoId);
            
            CreateTable(
                "dbo.EventInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 512),
                        Description = c.String(nullable: false),
                        ImageUrl = c.String(),
                        CloseDate = c.DateTime(nullable: false),
                        Goal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EventCoordinatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventCoordinators", t => t.EventCoordinatorId, cascadeDelete: true)
                .Index(t => t.EventCoordinatorId);
            
            CreateTable(
                "dbo.EventCoordinators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaypalAccountEmail = c.String(nullable: false),
                        UserProfileId = c.Int(nullable: false),
                        UserProfile_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserProfile_UserId)
                .Index(t => t.UserProfile_UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.EventCoordinators", new[] { "UserProfile_UserId" });
            DropIndex("dbo.EventInfoes", new[] { "EventCoordinatorId" });
            DropIndex("dbo.Donations", new[] { "EventInfoId" });
            DropIndex("dbo.Denominations", new[] { "EventInfo_Id" });
            DropForeignKey("dbo.EventCoordinators", "UserProfile_UserId", "dbo.UserProfile");
            DropForeignKey("dbo.EventInfoes", "EventCoordinatorId", "dbo.EventCoordinators");
            DropForeignKey("dbo.Donations", "EventInfoId", "dbo.EventInfoes");
            DropForeignKey("dbo.Denominations", "EventInfo_Id", "dbo.EventInfoes");
            DropTable("dbo.EventCoordinators");
            DropTable("dbo.EventInfoes");
            DropTable("dbo.Donations");
            DropTable("dbo.Denominations");
            DropTable("dbo.UserProfile");
        }
    }
}
