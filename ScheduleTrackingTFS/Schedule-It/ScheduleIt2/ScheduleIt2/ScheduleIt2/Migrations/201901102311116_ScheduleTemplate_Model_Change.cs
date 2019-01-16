namespace ScheduleIt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleTemplate_Model_Change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "ScheduleTemplate_Id", "dbo.ScheduleTemplates");
            DropIndex("dbo.Schedules", new[] { "ScheduleTemplate_Id" });
            AddColumn("dbo.ScheduleTemplates", "Title", c => c.String());
            DropColumn("dbo.Schedules", "ScheduleTemplate_Id");
            DropColumn("dbo.ScheduleTemplates", "Notes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ScheduleTemplates", "Notes", c => c.String());
            AddColumn("dbo.Schedules", "ScheduleTemplate_Id", c => c.Guid());
            DropColumn("dbo.ScheduleTemplates", "Title");
            CreateIndex("dbo.Schedules", "ScheduleTemplate_Id");
            AddForeignKey("dbo.Schedules", "ScheduleTemplate_Id", "dbo.ScheduleTemplates", "Id");
        }
    }
}
