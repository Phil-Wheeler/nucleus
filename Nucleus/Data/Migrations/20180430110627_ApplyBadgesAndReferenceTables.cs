using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Nucleus.Data.Migrations
{
    public partial class ApplyBadgesAndReferenceTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBadge_Badges_BadgeId",
                table: "UserBadge");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBadge_AspNetUsers_UserId1",
                table: "UserBadge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBadge",
                table: "UserBadge");

            migrationBuilder.DropIndex(
                name: "IX_UserBadge_UserId1",
                table: "UserBadge");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserBadge");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserBadge");

            migrationBuilder.RenameTable(
                name: "UserBadge",
                newName: "UserBadges");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserBadges",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBadges",
                table: "UserBadges",
                columns: new[] { "BadgeId", "ApplicationUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserBadges_ApplicationUserId",
                table: "UserBadges",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadges_AspNetUsers_ApplicationUserId",
                table: "UserBadges",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadges_Badges_BadgeId",
                table: "UserBadges",
                column: "BadgeId",
                principalTable: "Badges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBadges_AspNetUsers_ApplicationUserId",
                table: "UserBadges");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBadges_Badges_BadgeId",
                table: "UserBadges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBadges",
                table: "UserBadges");

            migrationBuilder.DropIndex(
                name: "IX_UserBadges_ApplicationUserId",
                table: "UserBadges");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserBadges");

            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "UserBadges",
                newName: "UserBadge");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserBadge",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserBadge",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBadge",
                table: "UserBadge",
                columns: new[] { "BadgeId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserBadge_UserId1",
                table: "UserBadge",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadge_Badges_BadgeId",
                table: "UserBadge",
                column: "BadgeId",
                principalTable: "Badges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadge_AspNetUsers_UserId1",
                table: "UserBadge",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
