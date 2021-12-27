namespace Iatec.KnowledgeAssessment.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdEventChange : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Event");
            AddColumn("dbo.Event", "Participants", c => c.Int(nullable: false));
            AlterColumn("dbo.Event", "IdEvent", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Event", "IdEvent");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Event");
            AlterColumn("dbo.Event", "IdEvent", c => c.Guid(nullable: false));
            DropColumn("dbo.Event", "Participants");
            AddPrimaryKey("dbo.Event", "IdEvent");
        }
    }
}
