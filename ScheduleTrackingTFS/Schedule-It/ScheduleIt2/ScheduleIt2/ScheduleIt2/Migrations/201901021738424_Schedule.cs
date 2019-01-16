namespace ScheduleIt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Schedule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Notes = c.String(),
                        ScheduleStartDay = c.DateTime(nullable: false),
                        ScheduleEndDay = c.DateTime(),
                        UserId = c.String(maxLength: 128),
                        Repeating = c.Boolean(nullable: false),
                        TemplateId = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Schedules", new[] { "UserId" });
            DropTable("dbo.Schedules");
        }
    }
}
