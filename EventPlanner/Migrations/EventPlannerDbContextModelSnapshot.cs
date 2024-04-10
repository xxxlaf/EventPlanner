﻿// <auto-generated />
using System;
using EventPlanner.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventPlanner.Migrations
{
    [DbContext(typeof(EventPlannerDbContext))]
    partial class EventPlannerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("EventPlanner.Entities.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventDescription")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("EventName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("EventId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            EndDate = new DateTime(2024, 5, 11, 17, 18, 59, 518, DateTimeKind.Local).AddTicks(3970),
                            EventDescription = "A lowkey party in the center of the Pacific Ocean.",
                            EventName = "Danny's Graduation Party",
                            Location = "Pacific Ocean",
                            StartDate = new DateTime(2024, 5, 10, 17, 18, 59, 518, DateTimeKind.Local).AddTicks(3930)
                        },
                        new
                        {
                            EventId = 2,
                            EndDate = new DateTime(2024, 5, 16, 17, 18, 59, 518, DateTimeKind.Local).AddTicks(3974),
                            EventDescription = "An EDM concert at Bogart's.",
                            EventName = "EDM Concert",
                            Location = "2621 Short Vine St, Cincinnati, OH 45219",
                            StartDate = new DateTime(2024, 5, 15, 17, 18, 59, 518, DateTimeKind.Local).AddTicks(3973)
                        },
                        new
                        {
                            EventId = 3,
                            EndDate = new DateTime(2024, 5, 18, 17, 18, 59, 518, DateTimeKind.Local).AddTicks(3978),
                            EventDescription = "A retirement party for Joe.",
                            EventName = "Retirement Party",
                            Location = "400 Broadway, Cincinnati, OH 45202",
                            StartDate = new DateTime(2024, 5, 17, 17, 18, 59, 518, DateTimeKind.Local).AddTicks(3977)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
