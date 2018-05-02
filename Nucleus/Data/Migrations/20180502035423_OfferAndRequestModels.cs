using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Nucleus.Data.Migrations
{
    public partial class OfferAndRequestModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Confirmations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AcceptedOn = table.Column<DateTime>(nullable: false),
                    AgreementId = table.Column<Guid>(nullable: false),
                    EndedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confirmations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Ends = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    MemberId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    TrackId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_AspNetUsers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OfferId = table.Column<Guid>(nullable: true),
                    Recurrence = table.Column<int>(nullable: false),
                    Unit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credits_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreditId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    MemberId = table.Column<string>(nullable: true),
                    Recurrence = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    TrackId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Credits_CreditId",
                        column: x => x.CreditId,
                        principalTable: "Credits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Credits_OfferId",
                table: "Credits",
                column: "OfferId",
                unique: true,
                filter: "[OfferId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_MemberId",
                table: "Offers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_TrackId",
                table: "Offers",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CreditId",
                table: "Requests",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_MemberId",
                table: "Requests",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_TrackId",
                table: "Requests",
                column: "TrackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confirmations");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Credits");

            migrationBuilder.DropTable(
                name: "Offers");
        }
    }
}
