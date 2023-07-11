using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travel.API.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DestinationTrips_Destinations_DestinationId1",
                table: "DestinationTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_DestinationTrips_Trips_TripId1",
                table: "DestinationTrips");

            migrationBuilder.DropIndex(
                name: "IX_DestinationTrips_DestinationId1",
                table: "DestinationTrips");

            migrationBuilder.DropIndex(
                name: "IX_DestinationTrips_TripId1",
                table: "DestinationTrips");

            migrationBuilder.DropColumn(
                name: "DestinationId1",
                table: "DestinationTrips");

            migrationBuilder.DropColumn(
                name: "TripId1",
                table: "DestinationTrips");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinationId1",
                table: "DestinationTrips",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TripId1",
                table: "DestinationTrips",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DestinationTrips_DestinationId1",
                table: "DestinationTrips",
                column: "DestinationId1");

            migrationBuilder.CreateIndex(
                name: "IX_DestinationTrips_TripId1",
                table: "DestinationTrips",
                column: "TripId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationTrips_Destinations_DestinationId1",
                table: "DestinationTrips",
                column: "DestinationId1",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationTrips_Trips_TripId1",
                table: "DestinationTrips",
                column: "TripId1",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
