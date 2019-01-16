namespace ScheduleIt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduledWorkPeriod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shifts", "Day", c => c.Int());
            AddColumn("dbo.Shifts", "WorkType", c => c.String());
            AddColumn("dbo.Shifts", "Scheduled", c => c.String());
            AddColumn("dbo.Shifts", "PayRate", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Shifts", "IsDayOff", c => c.Boolean());
            AddColumn("dbo.Shifts", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shifts", "Discriminator");
            DropColumn("dbo.Shifts", "IsDayOff");
            DropColumn("dbo.Shifts", "PayRate");
            DropColumn("dbo.Shifts", "Scheduled");
            DropColumn("dbo.Shifts", "WorkType");
            DropColumn("dbo.Shifts", "Day");
        }
    }
}
