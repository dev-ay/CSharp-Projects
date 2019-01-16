namespace ScheduleIt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PayPeriod : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PayPeriods",
                c => new
                    {
                        PayPeriodId = c.Guid(nullable: false),
                        PayPeriodLength = c.Int(nullable: false),
                        DaysUntilPayPeriod = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PayPeriodId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PayPeriods");
        }
    }
}
