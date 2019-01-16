namespace ScheduleIt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shift : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shifts");
        }
    }
}
