namespace Iatec.KnowledgeAssessment.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventNotification",
                c => new
                    {
                        IdEventNotification = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        IdEvent = c.Int(nullable: false),
                        IsAcepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdEventNotification);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        IdEvent = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Days = c.Int(nullable: false),
                        Place = c.String(),
                        TypeEvent = c.Int(nullable: false),
                        UserOwner = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsShareable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdEvent);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        ActivationCode = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IdUser);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        IdSchedule = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        NameSchedule = c.String(),
                    })
                .PrimaryKey(t => t.IdSchedule)
                .ForeignKey("dbo.User", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.ScheduleEvent",
                c => new
                    {
                        IdScheduleEvent = c.Int(nullable: false, identity: true),
                        IdEvent = c.Int(nullable: false),
                        IdSchedule = c.Int(nullable: false),
                        NameEvent = c.String(),
                        Month = c.String(),
                        MonthName = c.String(),
                        Year = c.Int(nullable: false),
                        DateEvent = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdScheduleEvent)
                .ForeignKey("dbo.Schedule", t => t.IdSchedule, cascadeDelete: true)
                .Index(t => t.IdSchedule);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleEvent", "IdSchedule", "dbo.Schedule");
            DropForeignKey("dbo.Schedule", "IdUser", "dbo.User");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.User");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.ScheduleEvent", new[] { "IdSchedule" });
            DropIndex("dbo.Schedule", new[] { "IdUser" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.ScheduleEvent");
            DropTable("dbo.Schedule");
            DropTable("dbo.User");
            DropTable("dbo.Role");
            DropTable("dbo.Event");
            DropTable("dbo.EventNotification");
        }
    }
}
