﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventScheduling.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    EventType = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTimeUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTimeUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CountryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UtcOffset = table.Column<string>(type: "TEXT", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTeam",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTeam", x => new { x.TeamId, x.Email });
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CountryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeZoneId = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invitation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invitation_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 254, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Mobile = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    CityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TeamId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3eb63894-c376-4eea-923a-ac1f3bfc6235"), "Paraguay" },
                    { new Guid("8217f508-c17d-431e-9cf0-05ca8984971b"), "Colombia" },
                    { new Guid("c39c3b71-78e9-4dcd-bbbd-35ac159f984b"), "Uruguay" },
                    { new Guid("e0007308-e1e3-4892-a5a7-883c02c6de22"), "Peru" }
                });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7c9c3d92-40c1-4ac3-95dc-fd2916e1beda"), "team_two" },
                    { new Guid("fc74ff91-3de6-4267-bce9-f390d3b0ca7c"), "team_one" }
                });

            migrationBuilder.InsertData(
                table: "UserTeam",
                columns: new[] { "Email", "TeamId" },
                values: new object[,]
                {
                    { "developer_five@yopmail.com", new Guid("7c9c3d92-40c1-4ac3-95dc-fd2916e1beda") },
                    { "developer_six@yopmail.com", new Guid("7c9c3d92-40c1-4ac3-95dc-fd2916e1beda") },
                    { "developer_three@yopmail.com", new Guid("7c9c3d92-40c1-4ac3-95dc-fd2916e1beda") },
                    { "qa_one@yopmail.com", new Guid("7c9c3d92-40c1-4ac3-95dc-fd2916e1beda") },
                    { "developer_four@yopmail.com", new Guid("fc74ff91-3de6-4267-bce9-f390d3b0ca7c") },
                    { "developer_one@yopmail.com", new Guid("fc74ff91-3de6-4267-bce9-f390d3b0ca7c") },
                    { "developer_two@yopmail.com", new Guid("fc74ff91-3de6-4267-bce9-f390d3b0ca7c") },
                    { "qa_one@yopmail.com", new Guid("fc74ff91-3de6-4267-bce9-f390d3b0ca7c") }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CountryId", "Name", "TimeZoneId" },
                values: new object[,]
                {
                    { new Guid("0de67652-5cc0-42ca-8005-aa41b3a41802"), new Guid("3eb63894-c376-4eea-923a-ac1f3bfc6235"), "Asuncion", "America/Asuncion" },
                    { new Guid("102077ed-f0de-442c-8d97-fbb7dfd96d08"), new Guid("c39c3b71-78e9-4dcd-bbbd-35ac159f984b"), "Montevideo", "America/Montevideo" },
                    { new Guid("386a04f3-e4c4-4922-9e79-e75ac0fa3a6a"), new Guid("e0007308-e1e3-4892-a5a7-883c02c6de22"), "Lima", "America/Lima" },
                    { new Guid("5ebf0600-c390-4b16-945d-eb0e734cf51c"), new Guid("8217f508-c17d-431e-9cf0-05ca8984971b"), "Medellin", "America/Bogota" },
                    { new Guid("9b862593-628a-4bc1-8cc4-038e01f34241"), new Guid("8217f508-c17d-431e-9cf0-05ca8984971b"), "Bogota", "America/Bogota" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "Mobile", "Name", "Role", "TeamId" },
                values: new object[,]
                {
                    { new Guid("140c7396-cb76-45ea-88c5-e709702dd927"), new Guid("386a04f3-e4c4-4922-9e79-e75ac0fa3a6a"), "developer_four@yopmail.com", "444 4444444", "developer_four", 1, null },
                    { new Guid("4a76384b-d4c7-4e4f-9dd8-3ae32515804b"), new Guid("5ebf0600-c390-4b16-945d-eb0e734cf51c"), "developer_two@yopmail.com", "222 2222222", "developer_two", 1, null },
                    { new Guid("50aeb858-723f-4b15-a3a1-6214f7e1b90c"), new Guid("0de67652-5cc0-42ca-8005-aa41b3a41802"), "qa_one@yopmail.com", "777 7777777", "qa_one", 2, null },
                    { new Guid("ad70475f-1821-405d-880b-151c9ae767ce"), new Guid("102077ed-f0de-442c-8d97-fbb7dfd96d08"), "developer_five@yopmail.com", "555 5555555", "developer_five", 1, null },
                    { new Guid("b2181377-6a51-446e-afb6-07f1402834e3"), new Guid("5ebf0600-c390-4b16-945d-eb0e734cf51c"), "developer_one@yopmail.com", "111 1111111", "developer_one", 1, null },
                    { new Guid("c9caec51-5a70-480b-b8cb-9b37507e6727"), new Guid("9b862593-628a-4bc1-8cc4-038e01f34241"), "developer_three@yopmail.com", "333 3333333", "developer_three", 1, null },
                    { new Guid("f75d4368-bbf5-4d50-97d7-baea7689f1e3"), new Guid("0de67652-5cc0-42ca-8005-aa41b3a41802"), "developer_six@yopmail.com", "666 6666666", "developer_six", 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitation_EventId",
                table: "Invitation",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamId",
                table: "Users",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invitation");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTeam");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
