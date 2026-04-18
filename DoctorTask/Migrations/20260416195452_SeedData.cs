using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DoctorTask.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "specilizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specilizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecilizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_specilizations_SpecilizationId",
                        column: x => x.SpecilizationId,
                        principalTable: "specilizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeSlot = table.Column<TimeSpan>(type: "time", nullable: false),
                    Problem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointements_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "specilizations",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Heart specialist", "Cardiology" },
                    { 2, "Skin specialist", "Dermatology" },
                    { 3, "Brain specialist", "Neurology" },
                    { 4, "Bone specialist", "Orthopedics" },
                    { 5, "Children specialist", "Pediatrics" },
                    { 6, "Eye specialist", "Ophthalmology" },
                    { 7, "Ear Nose Throat", "ENT" },
                    { 8, "Teeth specialist", "Dentistry" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Email", "ImageUrl", "Name", "Phone", "SpecilizationId" },
                values: new object[,]
                {
                    { 1, "ahmed@test.com", "team-1.jpg", "Dr. Ahmed", "0100000001", 1 },
                    { 2, "sara@test.com", "team-2.jpg", "Dr. Sara", "0100000002", 2 },
                    { 3, "ali@test.com", "team-3.jpg", "Dr. Ali", "0100000003", 3 },
                    { 4, "omar@test.com", "team-4.jpg", "Dr. Omar", "0100000004", 4 },
                    { 5, "nada@test.com", "team5.jpg", "Dr. Nada", "0100000005", 5 },
                    { 6, "hassan@test.com", "team6.jpg", "Dr. Hassan", "0100000006", 6 },
                    { 7, "laila@test.com", "team7.jpg", "Dr. Laila", "0100000007", 7 },
                    { 8, "karim@test.com", "team8.jpg", "Dr. Karim", "0100000008", 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointements_DoctorId",
                table: "Appointements",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecilizationId",
                table: "Doctors",
                column: "SpecilizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointements");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "specilizations");
        }
    }
}
