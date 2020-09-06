namespace projectIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        BuildingId = c.Int(nullable: false, identity: true),
                        BuildingName = c.String(),
                    })
                .PrimaryKey(t => t.BuildingId);
            
            CreateTable(
                "dbo.Performances",
                c => new
                    {
                        PerformanceId = c.Int(nullable: false, identity: true),
                        PerformanceName = c.String(nullable: false),
                        Description = c.String(),
                        BuildingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PerformanceId)
                .ForeignKey("dbo.Buildings", t => t.BuildingId, cascadeDelete: true)
                .Index(t => t.BuildingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Performances", "BuildingId", "dbo.Buildings");
            DropIndex("dbo.Performances", new[] { "BuildingId" });
            DropTable("dbo.Performances");
            DropTable("dbo.Buildings");
        }
    }
}
