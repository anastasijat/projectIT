﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projectIT.Models;

namespace projectIT.Controllers
{
    public class ReservationsController : Controller
    {
        private projectContext db = new projectContext();

        // GET: Reservations
        public ActionResult Index()
        {
            var reservations = db.Reservations.Include(r => r.Client).Include(r => r.Seat);
            return View(reservations.ToList());
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Performance performance = db.Performances.Find(id);
            var performance = db.Performances.Include(p => p.Seats).Include(p => p.Building).Where(p => p.PerformanceId == id).Single();
            SeatListModel model = new SeatListModel();
            model.Performance = performance;
            model.availableSeats = performance.Seats;
            if (performance == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SeatListModel model)
        {
            if(ModelState.IsValid)
            {
                //var seats = string.Join(",", model.selectedSeats);
                IList<int> seats = model.selectedSeats;
                for(int i=0;i<seats.Count;i++)
                {
                    Reservation reservation = new Reservation();
                    reservation.SeatId = seats[i];
                    var s = db.Seats.Find(seats[i]);
                    s.status = true;
                    reservation.Seat = db.Seats.Find(seats[i]);
                    reservation.ClientId = 3;
                    reservation.Client = db.Clients.Find(3);
                    db.Reservations.Add(reservation);
                    db.SaveChanges();
                }
                
                

                return RedirectToAction("Index");
            }
            /* foreach (var item in model.selectedSeats)
                 {

                     Reservation reservation = new Reservation();
                     if (item.status == false)
                     {
                         item.status = true;
                     reservation.Seat = item;
                     reservation.SeatId = item.SeatId;


                     db.Reservations.Add(reservation);
                     db.SaveChanges();
                 }


                 }*/

            return RedirectToAction("Index");



            //ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name", reservation.ClientId);
            // ViewBag.SeatId = new SelectList(db.Seats, "SeatId", "SeatId", reservation.SeatId);
            //return View(reservation);
        }
        /*public ActionResult Create(List<Seat> seats)
        {
            Reservation reservation = new Reservation();
            for(int i=0;i<seats.Count();i++)
            {
                reservation.Seat = seats[i];
                reservation.SeatId = seats[i].SeatId;
                if (ModelState.IsValid)
                {
                    db.Reservations.Add(reservation);
                    db.SaveChanges();
                    
                }
            }

            return RedirectToAction("Index");

            //ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name", reservation.ClientId);
            // ViewBag.SeatId = new SelectList(db.Seats, "SeatId", "SeatId", reservation.SeatId);
            return View(reservation);
        }*/
        /*public ActionResult Create([Bind(Include = "ReservationId,ClientId,SeatId")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name", reservation.ClientId);
            ViewBag.SeatId = new SelectList(db.Seats, "SeatId", "SeatId", reservation.SeatId);
            return View(reservation);
        }*/

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name", reservation.ClientId);
            ViewBag.SeatId = new SelectList(db.Seats, "SeatId", "SeatId", reservation.SeatId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationId,ClientId,SeatId")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name", reservation.ClientId);
            ViewBag.SeatId = new SelectList(db.Seats, "SeatId", "SeatId", reservation.SeatId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
