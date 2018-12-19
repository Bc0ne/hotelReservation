using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservation.Data.Migrations
{
    public partial class AddingReservationTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Adults = table.Column<int>(nullable: false),
                    Children = table.Column<int>(nullable: false),
                    RoomId = table.Column<long>(nullable: false),
                    MealId = table.Column<long>(nullable: false),
                    SeasonId = table.Column<long>(nullable: false),
                    CheckIn = table.Column<DateTime>(nullable: false),
                    CheckOut = table.Column<DateTime>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MealId",
                table: "Reservations",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SeasonId",
                table: "Reservations",
                column: "SeasonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
