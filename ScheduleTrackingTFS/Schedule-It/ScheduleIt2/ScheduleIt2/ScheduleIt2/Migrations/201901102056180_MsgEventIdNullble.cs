namespace ScheduleIt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MsgEventIdNullble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "EventID", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "EventID", c => c.Guid(nullable: false));
        }
    }
}
