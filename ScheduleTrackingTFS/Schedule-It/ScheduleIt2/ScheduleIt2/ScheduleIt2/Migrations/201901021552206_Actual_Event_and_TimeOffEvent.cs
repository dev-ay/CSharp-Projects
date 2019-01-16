namespace ScheduleIt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Actual_Event_and_TimeOffEvent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        EventID = c.Guid(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Note = c.String(),
                        Title = c.String(),
                        ActiveSchedule = c.Boolean(nullable: false),
                        ApproverId = c.String(),
                        Submitted = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
