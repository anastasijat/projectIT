namespace projectIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buildings", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Buildings", "NumberOfSeats", c => c.Int(nullable: false));
            AddColumn("dbo.Performances", "PerformanceDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Buildings", "BuildingName", c => c.String(nullable: false));
            AlterColumn("dbo.Seats", "status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Seats", "status", c => c.Int(nullable: false));
            AlterColumn("dbo.Buildings", "BuildingName", c => c.String());
            DropColumn("dbo.Performances", "PerformanceDateTime");
            DropColumn("dbo.Buildings", "NumberOfSeats");
            DropColumn("dbo.Buildings", "Status");
        }
    }
}
