using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITF.Infrastructure.Migrations
{
    public partial class AddDeveloperAndRecruiterConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeveloperProfiles_DeveloperContacts_DeveloperContactsId",
                schema: "Itf",
                table: "DeveloperProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_RecruiterProfiles_RecruiterProfileId",
                schema: "Itf",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_RecruiterProfiles_RecruiterContacts_RecruiterContactsId",
                schema: "Itf",
                table: "RecruiterProfiles");

            migrationBuilder.DropIndex(
                name: "IX_RecruiterProfiles_RecruiterContactsId",
                schema: "Itf",
                table: "RecruiterProfiles");

            migrationBuilder.DropIndex(
                name: "IX_DeveloperProfiles_DeveloperContactsId",
                schema: "Itf",
                table: "DeveloperProfiles");

            migrationBuilder.DropColumn(
                name: "RecruiterContactsId",
                schema: "Itf",
                table: "RecruiterProfiles");

            migrationBuilder.DropColumn(
                name: "DeveloperContactsId",
                schema: "Itf",
                table: "DeveloperProfiles");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Itf",
                table: "RecruiterContacts",
                newName: "RecruiterProfileId");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Itf",
                table: "DeveloperContacts",
                newName: "DeveloperProfileId");

            migrationBuilder.AlterColumn<string>(
                name: "Telegram",
                schema: "Itf",
                table: "RecruiterContacts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "Itf",
                table: "RecruiterContacts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LinkedInLink",
                schema: "Itf",
                table: "RecruiterContacts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecruiterProfileId",
                schema: "Itf",
                table: "Positions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DeveloperContacts_DeveloperProfiles_DeveloperProfileId",
                schema: "Itf",
                table: "DeveloperContacts",
                column: "DeveloperProfileId",
                principalSchema: "Itf",
                principalTable: "DeveloperProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_RecruiterProfiles_RecruiterProfileId",
                schema: "Itf",
                table: "Positions",
                column: "RecruiterProfileId",
                principalSchema: "Itf",
                principalTable: "RecruiterProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecruiterContacts_RecruiterProfiles_RecruiterProfileId",
                schema: "Itf",
                table: "RecruiterContacts",
                column: "RecruiterProfileId",
                principalSchema: "Itf",
                principalTable: "RecruiterProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeveloperContacts_DeveloperProfiles_DeveloperProfileId",
                schema: "Itf",
                table: "DeveloperContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_RecruiterProfiles_RecruiterProfileId",
                schema: "Itf",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_RecruiterContacts_RecruiterProfiles_RecruiterProfileId",
                schema: "Itf",
                table: "RecruiterContacts");

            migrationBuilder.RenameColumn(
                name: "RecruiterProfileId",
                schema: "Itf",
                table: "RecruiterContacts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DeveloperProfileId",
                schema: "Itf",
                table: "DeveloperContacts",
                newName: "Id");

            migrationBuilder.AddColumn<Guid>(
                name: "RecruiterContactsId",
                schema: "Itf",
                table: "RecruiterProfiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Telegram",
                schema: "Itf",
                table: "RecruiterContacts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "Itf",
                table: "RecruiterContacts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LinkedInLink",
                schema: "Itf",
                table: "RecruiterContacts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RecruiterProfileId",
                schema: "Itf",
                table: "Positions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "DeveloperContactsId",
                schema: "Itf",
                table: "DeveloperProfiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RecruiterProfiles_RecruiterContactsId",
                schema: "Itf",
                table: "RecruiterProfiles",
                column: "RecruiterContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperProfiles_DeveloperContactsId",
                schema: "Itf",
                table: "DeveloperProfiles",
                column: "DeveloperContactsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeveloperProfiles_DeveloperContacts_DeveloperContactsId",
                schema: "Itf",
                table: "DeveloperProfiles",
                column: "DeveloperContactsId",
                principalSchema: "Itf",
                principalTable: "DeveloperContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_RecruiterProfiles_RecruiterProfileId",
                schema: "Itf",
                table: "Positions",
                column: "RecruiterProfileId",
                principalSchema: "Itf",
                principalTable: "RecruiterProfiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecruiterProfiles_RecruiterContacts_RecruiterContactsId",
                schema: "Itf",
                table: "RecruiterProfiles",
                column: "RecruiterContactsId",
                principalSchema: "Itf",
                principalTable: "RecruiterContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
