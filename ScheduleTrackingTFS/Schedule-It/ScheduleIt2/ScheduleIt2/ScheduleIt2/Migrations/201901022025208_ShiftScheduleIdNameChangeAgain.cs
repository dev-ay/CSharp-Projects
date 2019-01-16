namespace ScheduleIt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShiftScheduleIdNameChangeAgain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shifts", "ScheduleId", c => c.String());
            DropColumn("dbo.Shifts", "ScheduledId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shifts", "ScheduledId", c => c.String());
            DropColumn("dbo.Shifts", "ScheduleId");
        }
    }
}
