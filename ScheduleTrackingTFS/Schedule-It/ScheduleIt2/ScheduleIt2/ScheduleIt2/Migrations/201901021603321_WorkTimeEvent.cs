namespace ScheduleIt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkTimeEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "ClockFunctionStatus", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "ClockFunctionStatus");
        }
    }
}
