namespace ScheduleIt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventPayPeriodScheduleKeyAnnotation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "EventID_Id", "dbo.Events");
            DropIndex("dbo.Messages", new[] { "EventID_Id" });
            RenameColumn(table: "dbo.Messages", name: "EventID_Id", newName: "EventID_EventID");
            DropPrimaryKey("dbo.Events");
            AlterColumn("dbo.Events", "Id", c => c.String());
            AlterColumn("dbo.Messages", "EventID_EventID", c => c.Guid());
            AddPrimaryKey("dbo.Events", "EventID");
            CreateIndex("dbo.Messages", "EventID_EventID");
            AddForeignKey("dbo.Messages", "EventID_EventID", "dbo.Events", "EventID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "EventID_EventID", "dbo.Events");
            DropIndex("dbo.Messages", new[] { "EventID_EventID" });
            DropPrimaryKey("dbo.Events");
            AlterColumn("dbo.Messages", "EventID_EventID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Events", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Events", "Id");
            RenameColumn(table: "dbo.Messages", name: "EventID_EventID", newName: "EventID_Id");
            CreateIndex("dbo.Messages", "EventID_Id");
            AddForeignKey("dbo.Messages", "EventID_Id", "dbo.Events", "Id");
        }
    }
}
