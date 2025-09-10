using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasseioStick.Migrations
{
    /// <inheritdoc />
    public partial class InitialModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameComplete = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CratedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tours_Users_CratedByUserId",
                        column: x => x.CratedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TourPoint",
                columns: table => new
                {
                    PointsOfTourId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToursImOnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourPoint", x => new { x.PointsOfTourId, x.ToursImOnId });
                    table.ForeignKey(
                        name: "FK_TourPoint_Points_PointsOfTourId",
                        column: x => x.PointsOfTourId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourPoint_Tours_ToursImOnId",
                        column: x => x.ToursImOnId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMadeTour",
                columns: table => new
                {
                    ToursThatIMadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersWhoMadeMeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMadeTour", x => new { x.ToursThatIMadeId, x.UsersWhoMadeMeId });
                    table.ForeignKey(
                        name: "FK_UserMadeTour_Tours_ToursThatIMadeId",
                        column: x => x.ToursThatIMadeId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMadeTour_Users_UsersWhoMadeMeId",
                        column: x => x.UsersWhoMadeMeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNeedMakeTour",
                columns: table => new
                {
                    ToursThatINeedMakeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersWhoNeedMakeMeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNeedMakeTour", x => new { x.ToursThatINeedMakeId, x.UsersWhoNeedMakeMeId });
                    table.ForeignKey(
                        name: "FK_UserNeedMakeTour_Tours_ToursThatINeedMakeId",
                        column: x => x.ToursThatINeedMakeId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNeedMakeTour_Users_UsersWhoNeedMakeMeId",
                        column: x => x.UsersWhoNeedMakeMeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourPoint_ToursImOnId",
                table: "TourPoint",
                column: "ToursImOnId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_CratedByUserId",
                table: "Tours",
                column: "CratedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMadeTour_UsersWhoMadeMeId",
                table: "UserMadeTour",
                column: "UsersWhoMadeMeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNeedMakeTour_UsersWhoNeedMakeMeId",
                table: "UserNeedMakeTour",
                column: "UsersWhoNeedMakeMeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourPoint");

            migrationBuilder.DropTable(
                name: "UserMadeTour");

            migrationBuilder.DropTable(
                name: "UserNeedMakeTour");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
