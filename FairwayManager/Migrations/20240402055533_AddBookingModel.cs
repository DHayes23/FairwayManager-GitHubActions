using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FairwayManager.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeeTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PlayerOneMembershipID = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerTwoMembershipID = table.Column<int>(type: "INTEGER", nullable: true),
                    PlayerThreeMembershipID = table.Column<int>(type: "INTEGER", nullable: true),
                    PlayerFourMembershipID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Bookings_Members_PlayerFourMembershipID",
                        column: x => x.PlayerFourMembershipID,
                        principalTable: "Members",
                        principalColumn: "MembershipID");
                    table.ForeignKey(
                        name: "FK_Bookings_Members_PlayerOneMembershipID",
                        column: x => x.PlayerOneMembershipID,
                        principalTable: "Members",
                        principalColumn: "MembershipID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Members_PlayerThreeMembershipID",
                        column: x => x.PlayerThreeMembershipID,
                        principalTable: "Members",
                        principalColumn: "MembershipID");
                    table.ForeignKey(
                        name: "FK_Bookings_Members_PlayerTwoMembershipID",
                        column: x => x.PlayerTwoMembershipID,
                        principalTable: "Members",
                        principalColumn: "MembershipID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PlayerFourMembershipID",
                table: "Bookings",
                column: "PlayerFourMembershipID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PlayerOneMembershipID",
                table: "Bookings",
                column: "PlayerOneMembershipID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PlayerThreeMembershipID",
                table: "Bookings",
                column: "PlayerThreeMembershipID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PlayerTwoMembershipID",
                table: "Bookings",
                column: "PlayerTwoMembershipID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
