namespace ScheduleIt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteUnread_GuidNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "EventID_EventID", "dbo.Events");
            DropIndex("dbo.Messages", new[] { "EventID_EventID" });
            AddColumn("dbo.Messages", "EventID", c => c.Guid());
            DropColumn("dbo.Messages", "UnreadMessage");
            DropColumn("dbo.Messages", "EventID_EventID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "EventID_EventID", c => c.Guid());
            AddColumn("dbo.Messages", "UnreadMessage", c => c.Boolean(nullable: false));
            DropColumn("dbo.Messages", "EventID");
            CreateIndex("dbo.Messages", "EventID_EventID");
            AddForeignKey("dbo.Messages", "EventID_EventID", "dbo.Events", "EventID");
        }
    }
}
