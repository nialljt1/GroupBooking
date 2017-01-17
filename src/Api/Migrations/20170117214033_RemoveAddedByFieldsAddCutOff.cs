using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class RemoveAddedByFieldsAddCutOff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedByForename",
                table: "Diners");

            migrationBuilder.DropColumn(
                name: "AddedBySurname",
                table: "Diners");

            migrationBuilder.AddColumn<DateTime>(
                name: "CutOffDate",
                table: "Bookings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "Identifier",
                table: "Bookings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CutOffDate",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "AddedByForename",
                table: "Diners",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddedBySurname",
                table: "Diners",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
