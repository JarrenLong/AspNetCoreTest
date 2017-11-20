using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MnkyTv.Migrations
{
    public partial class DbTableBaseClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "MediaVotes");

            migrationBuilder.DropColumn(
                name: "Complete",
                table: "MediaRequests");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "MediaVotes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "MediaVotes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "MediaRequests",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "MediaVotes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "MediaVotes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "MediaRequests");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserID",
                table: "MediaVotes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Complete",
                table: "MediaRequests",
                nullable: false,
                defaultValue: false);
        }
    }
}
