namespace ScheduleIt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Event_End_Nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "End", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "End", c => c.DateTime(nullable: false));
        }
    }
}
