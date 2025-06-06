﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RoomBookingApp.Persistence;

#nullable disable

namespace RoomBookingApp.Persistence.Migrations
{
    [DbContext(typeof(RoomBookingAppDBContext))]
    partial class RoomBookingAppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.4");

            modelBuilder.Entity("RoomBookingApp.Domain.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Rooms", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Conference Room A"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Conference Room B"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Conference Room C"
                        });
                });

            modelBuilder.Entity("RoomBookingApp.Domain.RoomBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomBooking", (string)null);
                });

            modelBuilder.Entity("RoomBookingApp.Domain.RoomBooking", b =>
                {
                    b.HasOne("RoomBookingApp.Domain.Room", "Room")
                        .WithMany("RoomBooking")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("RoomBookingApp.Domain.Room", b =>
                {
                    b.Navigation("RoomBooking");
                });
#pragma warning restore 612, 618
        }
    }
}
