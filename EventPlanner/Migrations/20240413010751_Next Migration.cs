using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlanner.Migrations
{
    /// <inheritdoc />
    public partial class NextMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 5, 13, 21, 7, 51, 226, DateTimeKind.Local).AddTicks(1213), new DateTime(2024, 5, 12, 21, 7, 51, 226, DateTimeKind.Local).AddTicks(1171) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 5, 18, 21, 7, 51, 226, DateTimeKind.Local).AddTicks(1217), new DateTime(2024, 5, 17, 21, 7, 51, 226, DateTimeKind.Local).AddTicks(1215) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 5, 20, 21, 7, 51, 226, DateTimeKind.Local).AddTicks(1221), new DateTime(2024, 5, 19, 21, 7, 51, 226, DateTimeKind.Local).AddTicks(1219) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 5, 11, 17, 18, 59, 518, DateTimeKind.Local).AddTicks(3970), new DateTime(2024, 5, 10, 17, 18, 59, 518, DateTimeKind.Local).AddTicks(3930) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 5, 16, 17, 18, 59, 518, DateTimeKind.Local).AddTicks(3974), new DateTime(2024, 5, 15, 17, 18, 59, 518, DateTimeKind.Local).AddTicks(3973) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 5, 18, 17, 18, 59, 518, DateTimeKind.Local).AddTicks(3978), new DateTime(2024, 5, 17, 17, 18, 59, 518, DateTimeKind.Local).AddTicks(3977) });
        }
    }
}
