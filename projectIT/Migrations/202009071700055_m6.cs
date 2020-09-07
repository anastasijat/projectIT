namespace projectIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        SeatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Seats", t => t.SeatId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.SeatId);
            
            AddColumn("dbo.Seats", "SeatNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "SeatId", "dbo.Seats");
            DropForeignKey("dbo.Reservations", "ClientId", "dbo.Clients");
            DropIndex("dbo.Reservations", new[] { "SeatId" });
            DropIndex("dbo.Reservations", new[] { "ClientId" });
            DropColumn("dbo.Clients", "email");
            DropColumn("dbo.Seats", "SeatNumber");
            DropTable("dbo.Reservations");
        }
    }
}
