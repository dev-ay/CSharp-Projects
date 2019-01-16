namespace ScheduleIt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Schedule_TempId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Schedules", "TemplateId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "TemplateId", c => c.String());
        }
    }
}
