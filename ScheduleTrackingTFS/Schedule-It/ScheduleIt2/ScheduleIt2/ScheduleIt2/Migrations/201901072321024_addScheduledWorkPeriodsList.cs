namespace ScheduleIt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addScheduledWorkPeriodsList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shifts", "Schedule_Id", c => c.Guid());
            CreateIndex("dbo.Shifts", "Schedule_Id");
            AddForeignKey("dbo.Shifts", "Schedule_Id", "dbo.Schedules", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shifts", "Schedule_Id", "dbo.Schedules");
            DropIndex("dbo.Shifts", new[] { "Schedule_Id" });
            DropColumn("dbo.Shifts", "Schedule_Id");
        }
    }
}
