﻿using Microsoft.EntityFrameworkCore;
using RoomBookingApp.Domain;

namespace RoomBookingApp.Persistence
{
    public class RoomBookingAppDBContext : DbContext
    {
        public RoomBookingAppDBContext(DbContextOptions<RoomBookingAppDBContext> options) : base(options) 
        {
            
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomBooking> RoomBooking { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1,Name = "Conference Room A"},
                new Room { Id = 2, Name = "Conference Room B" },
                new Room { Id = 3, Name = "Conference Room C" }
            );
        }
        
    }
}
