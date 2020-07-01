using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Giving_Api.Migrations
{
    public partial class DonationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Donations");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Donations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Donations");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
