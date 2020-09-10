namespace projectIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "SeatId", "dbo.Seats");
            DropIndex("dbo.Reservations", new[] { "SeatId" });
            AddColumn("dbo.Seats", "Reservation_ReservationId", c => c.Int());
            CreateIndex("dbo.Seats", "Reservation_ReservationId");
            AddForeignKey("dbo.Seats", "Reservation_ReservationId", "dbo.Reservations", "ReservationId");
            DropColumn("dbo.Reservations", "SeatId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "SeatId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Seats", "Reservation_ReservationId", "dbo.Reservations");
            DropIndex("dbo.Seats", new[] { "Reservation_ReservationId" });
            DropColumn("dbo.Seats", "Reservation_ReservationId");
            CreateIndex("dbo.Reservations", "SeatId");
            AddForeignKey("dbo.Reservations", "SeatId", "dbo.Seats", "SeatId", cascadeDelete: true);
        }
    }
}
