using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Nucleus.Data.Migrations
{
    public partial class TweakCreditReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Offers_OfferId",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_Credits_OfferId",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Credits");

            migrationBuilder.AddColumn<int>(
                name: "CreditsId",
                table: "Offers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CreditsId",
                table: "Offers",
                column: "CreditsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Credits_CreditsId",
                table: "Offers",
                column: "CreditsId",
                principalTable: "Credits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Credits_CreditsId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_CreditsId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "CreditsId",
                table: "Offers");

            migrationBuilder.AddColumn<Guid>(
                name: "OfferId",
                table: "Credits",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Credits_OfferId",
                table: "Credits",
                column: "OfferId",
                unique: true,
                filter: "[OfferId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_Offers_OfferId",
                table: "Credits",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
