namespace ScheduleIt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TmeOffEventsCotroller : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Guid(nullable: false),
                        DateSent = c.DateTime(nullable: false),
                        DateRead = c.DateTime(),
                        MessageTitle = c.String(),
                        Content = c.String(),
                        UnreadMessage = c.Boolean(nullable: false),
                        EventID_Id = c.String(maxLength: 128),
                        Recipient_Id = c.String(maxLength: 128),
                        Sender_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.Events", t => t.EventID_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Recipient_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Sender_Id)
                .Index(t => t.EventID_Id)
                .Index(t => t.Recipient_Id)
                .Index(t => t.Sender_Id);
            
            CreateTable(
                "dbo.ScheduleTemplates",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Shifts", "ScheduleTemplate_Id", c => c.Guid());
            AddColumn("dbo.Schedules", "ScheduleTemplate_Id", c => c.Guid());
            CreateIndex("dbo.Shifts", "ScheduleTemplate_Id");
            CreateIndex("dbo.Schedules", "ScheduleTemplate_Id");
            AddForeignKey("dbo.Schedules", "ScheduleTemplate_Id", "dbo.ScheduleTemplates", "Id");
            AddForeignKey("dbo.Shifts", "ScheduleTemplate_Id", "dbo.ScheduleTemplates", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shifts", "ScheduleTemplate_Id", "dbo.ScheduleTemplates");
            DropForeignKey("dbo.Schedules", "ScheduleTemplate_Id", "dbo.ScheduleTemplates");
            DropForeignKey("dbo.Messages", "Sender_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "Recipient_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "EventID_Id", "dbo.Events");
            DropIndex("dbo.Schedules", new[] { "ScheduleTemplate_Id" });
            DropIndex("dbo.Shifts", new[] { "ScheduleTemplate_Id" });
            DropIndex("dbo.Messages", new[] { "Sender_Id" });
            DropIndex("dbo.Messages", new[] { "Recipient_Id" });
            DropIndex("dbo.Messages", new[] { "EventID_Id" });
            DropColumn("dbo.Schedules", "ScheduleTemplate_Id");
            DropColumn("dbo.Shifts", "ScheduleTemplate_Id");
            DropTable("dbo.ScheduleTemplates");
            DropTable("dbo.Messages");
        }
    }
}
