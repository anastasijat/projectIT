namespace projectIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seats", "Reservation_ReservationId", "dbo.Reservations");
            DropIndex("dbo.Seats", new[] { "Reservation_ReservationId" });
            AddColumn("dbo.Reservations", "SeatId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservations", "SeatId");
            AddForeignKey("dbo.Reservations", "SeatId", "dbo.Seats", "SeatId", cascadeDelete: true);
            DropColumn("dbo.Seats", "Reservation_ReservationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seats", "Reservation_ReservationId", c => c.Int());
            DropForeignKey("dbo.Reservations", "SeatId", "dbo.Seats");
            DropIndex("dbo.Reservations", new[] { "SeatId" });
            DropColumn("dbo.Reservations", "SeatId");
            CreateIndex("dbo.Seats", "Reservation_ReservationId");
            AddForeignKey("dbo.Seats", "Reservation_ReservationId", "dbo.Reservations", "ReservationId");
        }
    }
}
