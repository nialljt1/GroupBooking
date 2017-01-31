using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class PluraliseDiners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diner_Bookings_BookingId",
                table: "Diner");

            migrationBuilder.DropForeignKey(
                name: "FK_Diner_AspNetUsers_CreatedById",
                table: "Diner");

            migrationBuilder.DropForeignKey(
                name: "FK_Diner_AspNetUsers_LastUpdatedById",
                table: "Diner");

            migrationBuilder.DropForeignKey(
                name: "FK_DinerMenuItems_Diner_DinerId",
                table: "DinerMenuItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diner",
                table: "Diner");

            migrationBuilder.RenameTable(
                name: "Diner",
                newName: "Diners");

            migrationBuilder.RenameIndex(
                name: "IX_Diner_LastUpdatedById",
                table: "Diners",
                newName: "IX_Diners_LastUpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Diner_CreatedById",
                table: "Diners",
                newName: "IX_Diners_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Diner_BookingId",
                table: "Diners",
                newName: "IX_Diners_BookingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diners",
                table: "Diners",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Diners_Bookings_BookingId",
                table: "Diners",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diners_AspNetUsers_CreatedById",
                table: "Diners",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diners_AspNetUsers_LastUpdatedById",
                table: "Diners",
                column: "LastUpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DinerMenuItems_Diners_DinerId",
                table: "DinerMenuItems",
                column: "DinerId",
                principalTable: "Diners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diners_Bookings_BookingId",
                table: "Diners");

            migrationBuilder.DropForeignKey(
                name: "FK_Diners_AspNetUsers_CreatedById",
                table: "Diners");

            migrationBuilder.DropForeignKey(
                name: "FK_Diners_AspNetUsers_LastUpdatedById",
                table: "Diners");

            migrationBuilder.DropForeignKey(
                name: "FK_DinerMenuItems_Diners_DinerId",
                table: "DinerMenuItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diners",
                table: "Diners");

            migrationBuilder.RenameTable(
                name: "Diners",
                newName: "Diner");

            migrationBuilder.RenameIndex(
                name: "IX_Diners_LastUpdatedById",
                table: "Diner",
                newName: "IX_Diner_LastUpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Diners_CreatedById",
                table: "Diner",
                newName: "IX_Diner_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Diners_BookingId",
                table: "Diner",
                newName: "IX_Diner_BookingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diner",
                table: "Diner",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Diner_Bookings_BookingId",
                table: "Diner",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diner_AspNetUsers_CreatedById",
                table: "Diner",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diner_AspNetUsers_LastUpdatedById",
                table: "Diner",
                column: "LastUpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DinerMenuItems_Diner_DinerId",
                table: "DinerMenuItems",
                column: "DinerId",
                principalTable: "Diner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
