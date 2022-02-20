using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITF.Infrastructure.Migrations
{
    public partial class RenameDeveloperProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeveloperProfiles_DeveloperContacts_DeveloperContactsId",
                schema: "Itf",
                table: "DeveloperProfiles");

            migrationBuilder.DropColumn(
                name: "ApplicantContactsId",
                schema: "Itf",
                table: "DeveloperProfiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeveloperContactsId",
                schema: "Itf",
                table: "DeveloperProfiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telegram",
                schema: "Itf",
                table: "DeveloperContacts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PortfolioLink",
                schema: "Itf",
                table: "DeveloperContacts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "Itf",
                table: "DeveloperContacts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LinkedInLink",
                schema: "Itf",
                table: "DeveloperContacts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "Itf",
                table: "DeveloperContacts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Itf",
                table: "DeveloperContacts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_DeveloperProfiles_DeveloperContacts_DeveloperContactsId",
                schema: "Itf",
                table: "DeveloperProfiles",
                column: "DeveloperContactsId",
                principalSchema: "Itf",
                principalTable: "DeveloperContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeveloperProfiles_DeveloperContacts_DeveloperContactsId",
                schema: "Itf",
                table: "DeveloperProfiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeveloperContactsId",
                schema: "Itf",
                table: "DeveloperProfiles",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicantContactsId",
                schema: "Itf",
                table: "DeveloperProfiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Telegram",
                schema: "Itf",
                table: "DeveloperContacts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PortfolioLink",
                schema: "Itf",
                table: "DeveloperContacts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "Itf",
                table: "DeveloperContacts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LinkedInLink",
                schema: "Itf",
                table: "DeveloperContacts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "Itf",
                table: "DeveloperContacts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Itf",
                table: "DeveloperContacts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DeveloperProfiles_DeveloperContacts_DeveloperContactsId",
                schema: "Itf",
                table: "DeveloperProfiles",
                column: "DeveloperContactsId",
                principalSchema: "Itf",
                principalTable: "DeveloperContacts",
                principalColumn: "Id");
        }
    }
}
