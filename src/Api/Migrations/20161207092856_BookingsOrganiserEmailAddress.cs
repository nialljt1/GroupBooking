using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class BookingsOrganiserEmailAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_OrganiserId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_OrganiserId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "OrganiserId",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "OrganiserEmailAddress",
                table: "Bookings",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganiserEmailAddress",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "OrganiserId",
                table: "Bookings",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_OrganiserId",
                table: "Bookings",
                column: "OrganiserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_OrganiserId",
                table: "Bookings",
                column: "OrganiserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
