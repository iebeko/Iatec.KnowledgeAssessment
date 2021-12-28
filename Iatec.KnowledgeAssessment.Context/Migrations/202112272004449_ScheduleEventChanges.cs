namespace Iatec.KnowledgeAssessment.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleEventChanges : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ScheduleEvent", new[] { "IdSchedule" });
            AddColumn("dbo.Event", "IdScheduleEvent", c => c.Int());
            AddColumn("dbo.Event", "EventId", c => c.Int());
            AddColumn("dbo.Event", "IdSchedule", c => c.Int());
            AddColumn("dbo.Event", "MonthName", c => c.String());
            AddColumn("dbo.Event", "DateEvent", c => c.DateTime());
            AddColumn("dbo.Event", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Event", "IdSchedule");
            DropTable("dbo.ScheduleEvent");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.IdScheduleEvent);
            
            DropIndex("dbo.Event", new[] { "IdSchedule" });
            DropColumn("dbo.Event", "Discriminator");
            DropColumn("dbo.Event", "DateEvent");
            DropColumn("dbo.Event", "MonthName");
            DropColumn("dbo.Event", "IdSchedule");
            DropColumn("dbo.Event", "EventId");
            DropColumn("dbo.Event", "IdScheduleEvent");
            CreateIndex("dbo.ScheduleEvent", "IdSchedule");
        }
    }
}
