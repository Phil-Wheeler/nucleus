using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Nucleus.Data.Migrations
{
    public partial class OfferRequestSetMemberToGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_AspNetUsers_MemberId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_MemberId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_MemberId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Offers_MemberId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Offers");

            migrationBuilder.AddColumn<Guid>(
                name: "Member",
                table: "Requests",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Member",
                table: "Offers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Member",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Member",
                table: "Offers");

            migrationBuilder.AddColumn<string>(
                name: "MemberId",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemberId",
                table: "Offers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_MemberId",
                table: "Requests",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_MemberId",
                table: "Offers",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_AspNetUsers_MemberId",
                table: "Offers",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_MemberId",
                table: "Requests",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
