namespace Iatec.KnowledgeAssessment.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleEventChanges1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Event", new[] { "IdSchedule" });
            CreateTable(
                "dbo.ScheduleEvent",
                c => new
                    {
                        IdScheduleEvent = c.Int(nullable: false, identity: true),
                        IdEvent = c.Int(nullable: false),
                        IdSchedule = c.Int(nullable: false),
                        MonthName = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Days = c.Int(nullable: false),
                        Place = c.String(),
                        TypeEvent = c.Int(nullable: false),
                        UserOwner = c.String(),
                        Participants = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsShareable = c.Boolean(nullable: false),
                    })
                 .PrimaryKey(t => t.IdScheduleEvent)
                .ForeignKey("dbo.Schedule", t => t.IdSchedule, cascadeDelete: true)
                .Index(t => t.IdSchedule);

            DropColumn("dbo.Event", "IdScheduleEvent");
            DropColumn("dbo.Event", "EventId");
            DropColumn("dbo.Event", "IdSchedule");
            DropColumn("dbo.Event", "MonthName");
            DropColumn("dbo.Event", "DateEvent");
            DropColumn("dbo.Event", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Event", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Event", "DateEvent", c => c.DateTime());
            AddColumn("dbo.Event", "MonthName", c => c.String());
            AddColumn("dbo.Event", "IdSchedule", c => c.Int());
            AddColumn("dbo.Event", "EventId", c => c.Int());
            AddColumn("dbo.Event", "IdScheduleEvent", c => c.Int());
            DropIndex("dbo.ScheduleEvent", new[] { "IdSchedule" });
            DropTable("dbo.ScheduleEvent");
            CreateIndex("dbo.Event", "IdSchedule");
        }
    }
}
