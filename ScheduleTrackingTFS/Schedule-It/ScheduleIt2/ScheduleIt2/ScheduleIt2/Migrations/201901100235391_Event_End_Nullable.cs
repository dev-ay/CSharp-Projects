namespace ScheduleIt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Event_End_Nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "End", c => c.DateTime());
            AlterColumn("dbo.Messages", "EventID", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "EventID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Events", "End", c => c.DateTime(nullable: false));
        }
    }
}
