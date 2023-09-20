using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    Lecture_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lecture_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lecture_CourseID = table.Column<int>(type: "int", nullable: false),
                    Lecture_CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lecture_Semester = table.Column<int>(type: "int", nullable: false),
                    Lecture_Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lecture_TotalHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Lecture_ID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Room_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Room_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Room_Building = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Room_BuildingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Room_Capacity = table.Column<int>(type: "int", nullable: false),
                    Room_Type = table.Column<int>(type: "int", nullable: false),
                    Room_ComputersCount = table.Column<int>(type: "int", nullable: false),
                    Room_HasProjector = table.Column<bool>(type: "bit", nullable: false),
                    Room_IsLocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Room_ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Reservation_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reservation_EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reservation_IsRecurring = table.Column<bool>(type: "bit", nullable: false),
                    Reservation_StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reservation_EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reservation_ExactDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reservation_Day = table.Column<int>(type: "int", nullable: false),
                    Reservation_StartTime = table.Column<int>(type: "int", nullable: false),
                    Reservation_EndTime = table.Column<int>(type: "int", nullable: false),
                    Room_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Reservation_ID);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_Room_ID",
                        column: x => x.Room_ID,
                        principalTable: "Rooms",
                        principalColumn: "Room_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomAvailabilities",
                columns: table => new
                {
                    RoomAvailability_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomAvailability_Day = table.Column<int>(type: "int", nullable: false),
                    RoomAvailability_StartTime = table.Column<int>(type: "int", nullable: false),
                    RoomAvailability_EndTime = table.Column<int>(type: "int", nullable: false),
                    Room_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAvailabilities", x => x.RoomAvailability_ID);
                    table.ForeignKey(
                        name: "FK_RoomAvailabilities_Rooms_Room_ID",
                        column: x => x.Room_ID,
                        principalTable: "Rooms",
                        principalColumn: "Room_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Teacher_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teacher_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacher_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Teacher_ID);
                    table.ForeignKey(
                        name: "FK_Teachers_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubRequests",
                columns: table => new
                {
                    SubRequest_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubRequest_EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubRequest_Status = table.Column<int>(type: "int", nullable: false),
                    SubRequest_OriginalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubRequest_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubRequest_StartTime = table.Column<int>(type: "int", nullable: false),
                    SubRequest_EndTime = table.Column<int>(type: "int", nullable: false),
                    Reservation_ID = table.Column<int>(type: "int", nullable: false),
                    Room_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubRequests", x => x.SubRequest_ID);
                    table.ForeignKey(
                        name: "FK_SubRequests_Reservations_Reservation_ID",
                        column: x => x.Reservation_ID,
                        principalTable: "Reservations",
                        principalColumn: "Reservation_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubRequests_Rooms_Room_ID",
                        column: x => x.Room_ID,
                        principalTable: "Rooms",
                        principalColumn: "Room_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherLectures",
                columns: table => new
                {
                    Teacher_ID = table.Column<int>(type: "int", nullable: false),
                    Lecture_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherLectures", x => new { x.Teacher_ID, x.Lecture_ID });
                    table.ForeignKey(
                        name: "FK_TeacherLectures_Lectures_Lecture_ID",
                        column: x => x.Lecture_ID,
                        principalTable: "Lectures",
                        principalColumn: "Lecture_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherLectures_Teachers_Teacher_ID",
                        column: x => x.Teacher_ID,
                        principalTable: "Teachers",
                        principalColumn: "Teacher_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Room_ID",
                table: "Reservations",
                column: "Room_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAvailabilities_Room_ID",
                table: "RoomAvailabilities",
                column: "Room_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SubRequests_Reservation_ID",
                table: "SubRequests",
                column: "Reservation_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SubRequests_Room_ID",
                table: "SubRequests",
                column: "Room_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherLectures_Lecture_ID",
                table: "TeacherLectures",
                column: "Lecture_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_User_ID",
                table: "Teachers",
                column: "User_ID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomAvailabilities");

            migrationBuilder.DropTable(
                name: "SubRequests");

            migrationBuilder.DropTable(
                name: "TeacherLectures");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
