using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Giving_Api.Migrations
{
    public partial class Docs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CauseAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BeneficiaryAccountNumber = table.Column<string>(nullable: true),
                    BeneficiaryAccountName = table.Column<string>(nullable: true),
                    BeneficiaryBank = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauseAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    CardNumber = table.Column<int>(nullable: false),
                    AccountType = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<string>(nullable: true),
                    CVV = table.Column<string>(nullable: true),
                    Pin = table.Column<string>(nullable: true),
                    Annonymous = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyRewards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyRewards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationDocument",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemorandumOfAssociation = table.Column<string>(nullable: true),
                    AlumniAssociationSetup = table.Column<string>(nullable: true),
                    CAC_RegDocument = table.Column<string>(nullable: true),
                    CorporateGovernanceStructure = table.Column<string>(nullable: true),
                    Identification = table.Column<string>(nullable: true),
                    AuthorizedSignatoryList = table.Column<string>(nullable: true),
                    ValidIdentificationOfAuthorizedSignatories = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationDocument", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    ConfirmationToken = table.Column<string>(nullable: true),
                    IsConfirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cause",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserID = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Donation = table.Column<double>(nullable: false),
                    TargetAmount = table.Column<double>(nullable: false),
                    BeneficiaryAddress = table.Column<string>(nullable: true),
                    BeneficiaryNumber = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    PicturePath = table.Column<string>(nullable: true),
                    VideoPath = table.Column<string>(nullable: true),
                    CauseBeneficiaryAccountId = table.Column<Guid>(nullable: true),
                    ExpectedProjectImpact = table.Column<string>(nullable: true),
                    DateCountDown = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cause", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cause_CauseAccounts_CauseBeneficiaryAccountId",
                        column: x => x.CauseBeneficiaryAccountId,
                        principalTable: "CauseAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PysicalAddress = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    Domi = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Facebook = table.Column<bool>(nullable: false),
                    Twitter = table.Column<bool>(nullable: false),
                    Instagram = table.Column<bool>(nullable: false),
                    RegDocumentId = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfile_RegistrationDocument_RegDocumentId",
                        column: x => x.RegDocumentId,
                        principalTable: "RegistrationDocument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cause_CauseBeneficiaryAccountId",
                table: "Cause",
                column: "CauseBeneficiaryAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_RegDocumentId",
                table: "UserProfile",
                column: "RegDocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cause");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "MyMessages");

            migrationBuilder.DropTable(
                name: "MyRewards");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CauseAccounts");

            migrationBuilder.DropTable(
                name: "RegistrationDocument");
        }
    }
}
