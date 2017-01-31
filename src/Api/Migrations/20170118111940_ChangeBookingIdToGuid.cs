using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api.Migrations
{
    public partial class ChangeBookingIdToGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
            name: "IX_Diners_BookingId",
            table: "Diners");

            migrationBuilder.DropForeignKey(
                name: "FK_Diners_Bookings_BookingId",
                table: "Diners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Bookings");

            migrationBuilder.DropColumn(
            name: "BookingId",
            table: "Diners");

            migrationBuilder.AddColumn<Guid>(
                name: "BookingId",
                table: "Diners",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Identifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Diners_Bookings_BookingId",
                table: "Diners",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diners_Bookings_BookingId",
                table: "Diners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropColumn(
            name: "BookingId",
            table: "Diners");

            migrationBuilder.AddColumn<int>(
            name: "BookingId",
            table: "Diners",
            nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Bookings",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Diners_Bookings_BookingId",
                table: "Diners",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
