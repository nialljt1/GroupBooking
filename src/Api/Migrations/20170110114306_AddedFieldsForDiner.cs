using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class AddedFieldsForDiner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diners_AspNetUsers_CreatedById",
                table: "Diners");

            migrationBuilder.DropIndex(
                name: "IX_Diners_CreatedById",
                table: "Diners");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Diners");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Diners",
                newName: "AddedAt");

            migrationBuilder.AddColumn<string>(
                name: "AddedByEmailAddress",
                table: "Diners",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedByForename",
                table: "Diners",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedBySurname",
                table: "Diners",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedByEmailAddress",
                table: "Diners");

            migrationBuilder.DropColumn(
                name: "AddedByForename",
                table: "Diners");

            migrationBuilder.DropColumn(
                name: "AddedBySurname",
                table: "Diners");

            migrationBuilder.RenameColumn(
                name: "AddedAt",
                table: "Diners",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Diners",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diners_CreatedById",
                table: "Diners",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Diners_AspNetUsers_CreatedById",
                table: "Diners",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
