namespace ScheduleIt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TempSchedules : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "Priority", c => c.Int());
            AddColumn("dbo.Schedules", "DateCreated", c => c.DateTime());
            AddColumn("dbo.Schedules", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "Discriminator");
            DropColumn("dbo.Schedules", "DateCreated");
            DropColumn("dbo.Schedules", "Priority");
        }
    }
}
