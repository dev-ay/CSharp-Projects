namespace ScheduleIt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShiftColumnNameChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shifts", "ScheduledId", c => c.String());
            DropColumn("dbo.Shifts", "Scheduled");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shifts", "Scheduled", c => c.String());
            DropColumn("dbo.Shifts", "ScheduledId");
        }
    }
}
