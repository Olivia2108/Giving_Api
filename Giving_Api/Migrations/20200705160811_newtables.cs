using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Giving_Api.Migrations
{
    public partial class newtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "volunteers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Device",
                table: "volunteers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "volunteers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "volunteers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "volunteers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Device",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "UserProfile",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Device",
                table: "UserProfile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "UserProfile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "UserProfile",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "reviews",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Device",
                table: "reviews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "reviews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "reviews",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "RegistrationDocument",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Device",
                table: "RegistrationDocument",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "RegistrationDocument",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "RegistrationDocument",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "recurringDonations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Device",
                table: "recurringDonations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "recurringDonations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "recurringDonations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "recurringDonations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "statusId",
                table: "recurringDonations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Device",
                table: "MyRewards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "MyRewards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "MyRewards",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "MyRewards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Device",
                table: "MyMessages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "MyMessages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "MyMessages",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "loans",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Device",
                table: "loans",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "loans",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "loans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "LoanDonors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Device",
                table: "LoanDonors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "LoanDonors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "LoanDonors",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "LoanDonors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "LoanDocument",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Device",
                table: "LoanDocument",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "LoanDocument",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "LoanDocument",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Donations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Device",
                table: "Donations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "Donations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Donations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "contacts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Device",
                table: "contacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "contacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "contacts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Cause",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Device",
                table: "Cause",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "Cause",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Cause",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "Cause",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "messageContents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    subject = table.Column<string>(nullable: true),
                    body = table.Column<string>(nullable: true),
                    messageCode = table.Column<int>(nullable: false),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messageContents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "messageContents");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "Device",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Device",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "Device",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "Device",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "RegistrationDocument");

            migrationBuilder.DropColumn(
                name: "Device",
                table: "RegistrationDocument");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "RegistrationDocument");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "RegistrationDocument");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "recurringDonations");

            migrationBuilder.DropColumn(
                name: "Device",
                table: "recurringDonations");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "recurringDonations");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "recurringDonations");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "recurringDonations");

            migrationBuilder.DropColumn(
                name: "statusId",
                table: "recurringDonations");

            migrationBuilder.DropColumn(
                name: "Device",
                table: "MyRewards");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "MyRewards");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "MyRewards");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "MyRewards");

            migrationBuilder.DropColumn(
                name: "Device",
                table: "MyMessages");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "MyMessages");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "MyMessages");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "loans");

            migrationBuilder.DropColumn(
                name: "Device",
                table: "loans");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "loans");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "loans");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "LoanDonors");

            migrationBuilder.DropColumn(
                name: "Device",
                table: "LoanDonors");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "LoanDonors");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "LoanDonors");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "LoanDonors");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "LoanDocument");

            migrationBuilder.DropColumn(
                name: "Device",
                table: "LoanDocument");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "LoanDocument");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "LoanDocument");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "Device",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "Device",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Cause");

            migrationBuilder.DropColumn(
                name: "Device",
                table: "Cause");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Cause");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Cause");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "Cause");
        }
    }
}
