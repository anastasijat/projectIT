namespace projectIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        SeatId = c.Int(nullable: false, identity: true),
                        status = c.Int(nullable: false),
                        PerformanceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SeatId)
                .ForeignKey("dbo.Performances", t => t.PerformanceId, cascadeDelete: true)
                .Index(t => t.PerformanceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "PerformanceId", "dbo.Performances");
            DropIndex("dbo.Seats", new[] { "PerformanceId" });
            DropTable("dbo.Seats");
        }
    }
}
