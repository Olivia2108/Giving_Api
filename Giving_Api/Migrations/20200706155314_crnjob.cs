using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Giving_Api.Migrations
{
    public partial class crnjob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Interval",
                table: "recurringDonations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "recurringDonations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interval",
                table: "recurringDonations");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "recurringDonations");
        }
    }
}
