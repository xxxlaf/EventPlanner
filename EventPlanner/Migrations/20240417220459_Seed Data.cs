using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventPlanner.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Organizers",
                columns: new[] { "OrganizerId", "CompanyName", "ContactInfo", "OrganizerName" },
                values: new object[,]
                {
                    { 1, "Cincinnati Insurance", "dude.name@cincinnatiinsurance.com", "A Dude's Name" },
                    { 2, "Bogart's", "josh.bell@bogarts.com", "Josh Bell" }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "VenueId", "Capacity", "Location", "RentalCost", "VenueName" },
                values: new object[,]
                {
                    { 1, 500, "317 E 5th St, Cincinnati, OH 45202", 250, "Cincinnati Masonic Center" },
                    { 2, 1500, "2621 Short Vine St, Cincinnati, OH 45219", 1000, "Bogart's Music Venue" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "EventDate", "EventName", "OrganizerId", "VenueId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 4, 22), "Pizza Party", 1, 1 },
                    { 2, new DateOnly(2024, 4, 26), "John Summit Live", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "AttendeeId", "Email", "EventId", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "attendee1@example.com", 1, "Attendee 1", "123-456-7890" },
                    { 2, "attendee2@example.com", 1, "Attendee 2", "123-456-7891" },
                    { 3, "attendee3@example.com", 1, "Attendee 3", "123-456-7892" },
                    { 4, "attendee4@example.com", 1, "Attendee 4", "123-456-7893" },
                    { 5, "attendee5@example.com", 1, "Attendee 5", "123-456-7894" },
                    { 6, "attendee6@example.com", 2, "Attendee 6", "123-456-7895" },
                    { 7, "attendee7@example.com", 2, "Attendee 7", "123-456-7896" },
                    { 8, "attendee8@example.com", 2, "Attendee 8", "123-456-7897" },
                    { 9, "attendee9@example.com", 2, "Attendee 9", "123-456-7898" },
                    { 10, "attendee10@example.com", 2, "Attendee 10", "123-456-7899" }
                });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "TaskItemId", "Deadline", "Description", "EventId", "Status" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 4, 21), "Book Venue", 1, false },
                    { 2, new DateOnly(2024, 4, 21), "Send Invitations", 1, false },
                    { 3, new DateOnly(2024, 4, 26), "Sound Check w/ John Summit", 2, false },
                    { 4, new DateOnly(2024, 4, 26), "Clean General Floor", 2, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "AttendeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "AttendeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "AttendeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "AttendeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "AttendeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "AttendeeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "AttendeeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "AttendeeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "AttendeeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "AttendeeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "TaskItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "TaskItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "TaskItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "TaskItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Organizers",
                keyColumn: "OrganizerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizers",
                keyColumn: "OrganizerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "VenueId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "VenueId",
                keyValue: 2);
        }
    }
}
