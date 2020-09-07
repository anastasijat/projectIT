namespace projectIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buildings", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buildings", "Status", c => c.Int(nullable: false));
        }
    }
}
