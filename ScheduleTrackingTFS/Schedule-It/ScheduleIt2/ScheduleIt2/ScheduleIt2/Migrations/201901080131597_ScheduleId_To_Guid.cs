namespace ScheduleIt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleId_To_Guid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shifts", "Schedule_Id", "dbo.Schedules");
            DropIndex("dbo.Shifts", new[] { "Schedule_Id" });
            DropColumn("dbo.Shifts", "ScheduleId");
            RenameColumn(table: "dbo.Shifts", name: "Schedule_Id", newName: "ScheduleId");
            AlterColumn("dbo.Shifts", "ScheduleId", c => c.Guid());
            CreateIndex("dbo.Shifts", "ScheduleId");
            AddForeignKey("dbo.Shifts", "ScheduleId", "dbo.Schedules", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shifts", "ScheduleId", "dbo.Schedules");
            DropIndex("dbo.Shifts", new[] { "ScheduleId" });
            AlterColumn("dbo.Shifts", "ScheduleId", c => c.String());
            RenameColumn(table: "dbo.Shifts", name: "ScheduleId", newName: "Schedule_Id");
            AddColumn("dbo.Shifts", "ScheduleId", c => c.String());
            CreateIndex("dbo.Shifts", "Schedule_Id");
            AddForeignKey("dbo.Shifts", "Schedule_Id", "dbo.Schedules", "Id");
        }
    }
}
