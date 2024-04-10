using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventPlanner.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    EventDescription = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Location = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "EndDate", "EventDescription", "EventName", "Location", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 11, 17, 18, 59, 518, DateTimeKind.Local).AddTicks(3970), "A lowkey party in the center of the Pacific Ocean.", "Danny's Graduation Party", "Pacific Ocean", new DateTime(2024, 5, 10, 17, 18, 59, 518, DateTimeKind.Local).AddTicks(3930) },
                    { 2, new DateTime(2024, 5, 16, 17, 18, 59, 518, DateTimeKind.Local).AddTicks(3974), "An EDM concert at Bogart's.", "EDM Concert", "2621 Short Vine St, Cincinnati, OH 45219", new DateTime(2024, 5, 15, 17, 18, 59, 518, DateTimeKind.Local).AddTicks(3973) },
                    { 3, new DateTime(2024, 5, 18, 17, 18, 59, 518, DateTimeKind.Local).AddTicks(3978), "A retirement party for Joe.", "Retirement Party", "400 Broadway, Cincinnati, OH 45202", new DateTime(2024, 5, 17, 17, 18, 59, 518, DateTimeKind.Local).AddTicks(3977) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
