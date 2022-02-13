using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITF.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Itf");

            migrationBuilder.CreateTable(
                name: "DeveloperCategories",
                schema: "Itf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperContacts",
                schema: "Itf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Telegram = table.Column<string>(type: "text", nullable: false),
                    PortfolioLink = table.Column<string>(type: "text", nullable: false),
                    LinkedInLink = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecruiterContacts",
                schema: "Itf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Telegram = table.Column<string>(type: "text", nullable: false),
                    LinkedInLink = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruiterContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperProfiles",
                schema: "Itf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false),
                    SalaryExpectation = table.Column<int>(type: "integer", nullable: false),
                    HourlyRate = table.Column<int>(type: "integer", nullable: true),
                    ExperienceInYears = table.Column<int>(type: "integer", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    EnglishProficiency = table.Column<int>(type: "integer", nullable: false),
                    ExperienceDescription = table.Column<string>(type: "text", nullable: true),
                    Expectations = table.Column<string>(type: "text", nullable: true),
                    Achievements = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DeveloperContactsId = table.Column<Guid>(type: "uuid", nullable: true),
                    ApplicantContactsId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeveloperCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Skills = table.Column<List<string>>(type: "text[]", nullable: false),
                    WorkOptions = table.Column<int[]>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeveloperProfiles_DeveloperCategories_DeveloperCategoryId",
                        column: x => x.DeveloperCategoryId,
                        principalSchema: "Itf",
                        principalTable: "DeveloperCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperProfiles_DeveloperContacts_DeveloperContactsId",
                        column: x => x.DeveloperContactsId,
                        principalSchema: "Itf",
                        principalTable: "DeveloperContacts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecruiterProfiles",
                schema: "Itf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false),
                    CompanyDescription = table.Column<string>(type: "text", nullable: false),
                    CompanyWebsite = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RecruiterContactsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruiterProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecruiterProfiles_RecruiterContacts_RecruiterContactsId",
                        column: x => x.RecruiterContactsId,
                        principalSchema: "Itf",
                        principalTable: "RecruiterContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                schema: "Itf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    ExperienceInYears = table.Column<int>(type: "integer", nullable: true),
                    WorkOptions = table.Column<int[]>(type: "integer[]", nullable: false),
                    RecruiterProfileId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_RecruiterProfiles_RecruiterProfileId",
                        column: x => x.RecruiterProfileId,
                        principalSchema: "Itf",
                        principalTable: "RecruiterProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Itf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SelectedProfile = table.Column<int>(type: "integer", nullable: false),
                    DeveloperProfileId = table.Column<Guid>(type: "uuid", nullable: true),
                    RecruiterProfileId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_DeveloperProfiles_DeveloperProfileId",
                        column: x => x.DeveloperProfileId,
                        principalSchema: "Itf",
                        principalTable: "DeveloperProfiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_RecruiterProfiles_RecruiterProfileId",
                        column: x => x.RecruiterProfileId,
                        principalSchema: "Itf",
                        principalTable: "RecruiterProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperProfiles_DeveloperCategoryId",
                schema: "Itf",
                table: "DeveloperProfiles",
                column: "DeveloperCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperProfiles_DeveloperContactsId",
                schema: "Itf",
                table: "DeveloperProfiles",
                column: "DeveloperContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_RecruiterProfileId",
                schema: "Itf",
                table: "Positions",
                column: "RecruiterProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruiterProfiles_RecruiterContactsId",
                schema: "Itf",
                table: "RecruiterProfiles",
                column: "RecruiterContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeveloperProfileId",
                schema: "Itf",
                table: "Users",
                column: "DeveloperProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RecruiterProfileId",
                schema: "Itf",
                table: "Users",
                column: "RecruiterProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Positions",
                schema: "Itf");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Itf");

            migrationBuilder.DropTable(
                name: "DeveloperProfiles",
                schema: "Itf");

            migrationBuilder.DropTable(
                name: "RecruiterProfiles",
                schema: "Itf");

            migrationBuilder.DropTable(
                name: "DeveloperCategories",
                schema: "Itf");

            migrationBuilder.DropTable(
                name: "DeveloperContacts",
                schema: "Itf");

            migrationBuilder.DropTable(
                name: "RecruiterContacts",
                schema: "Itf");
        }
    }
}
