using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Giving_Api.Migrations
{
    public partial class updateDonationRepo : Migration
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
                name: "contacts",
                columns: table => new
                {
                    ContactID = table.Column<Guid>(nullable: false),
                    ContactMessage = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    CauseId = table.Column<Guid>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.ContactID);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CauseId = table.Column<string>(nullable: true),
                    UserEmail = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    CardNumber = table.Column<int>(nullable: false),
                    AccountType = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<string>(nullable: true),
                    CVV = table.Column<string>(nullable: true),
                    Pin = table.Column<string>(nullable: true),
                    Annonymous = table.Column<bool>(nullable: false),
                    Frequency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanDocument",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BusinessPlan = table.Column<string>(nullable: true),
                    CompanyRegistrationDocuments = table.Column<string>(nullable: true),
                    GuarantorLetter = table.Column<string>(nullable: true),
                    IndemnityForm = table.Column<string>(nullable: true),
                    MeansOfIdentification = table.Column<string>(nullable: true),
                    RelevantPictures = table.Column<string>(nullable: true),
                    VideoRecording = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDocument", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanDonorDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    registrationdocuments = table.Column<string>(nullable: true),
                    MeansOfIdentification = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDonorDocuments", x => x.Id);
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
                name: "recurringDonations",
                columns: table => new
                {
                    RecurringDonationID = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    DonationDay = table.Column<DateTime>(nullable: false),
                    Frequency = table.Column<string>(nullable: true),
                    CauseID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    DonationID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recurringDonations", x => x.RecurringDonationID);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationDocument",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    MemorandumOfAssociation_Path = table.Column<string>(nullable: true),
                    AlumniAssociationSetup_Path = table.Column<string>(nullable: true),
                    CAC_RegDocument_Path = table.Column<string>(nullable: true),
                    CorporateGovernanceStructure_Path = table.Column<string>(nullable: true),
                    Identification_Path = table.Column<string>(nullable: true),
                    AuthorizedSignatoryList_Path = table.Column<string>(nullable: true),
                    ValidIdentificationOfAuthorizedSignatories_Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationDocument", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    ReviewID = table.Column<Guid>(nullable: false),
                    ReviewMessage = table.Column<string>(nullable: true),
                    ReviewEmail = table.Column<string>(nullable: true),
                    ReviewTime = table.Column<DateTime>(nullable: false),
                    CauseID = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.ReviewID);
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
                name: "volunteers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Interest = table.Column<string>(nullable: true),
                    InterestDuration = table.Column<string>(nullable: true),
                    VolunteerPledge = table.Column<bool>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_volunteers", x => x.Id);
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
                name: "loans",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    AmountRequested = table.Column<double>(nullable: false),
                    Purpose = table.Column<string>(nullable: true),
                    Tenor = table.Column<string>(nullable: true),
                    Repaymentsource = table.Column<string>(nullable: true),
                    LoanDocumentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_loans_LoanDocument_LoanDocumentId",
                        column: x => x.LoanDocumentId,
                        principalTable: "LoanDocument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoanDonors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    LoanId = table.Column<string>(nullable: true),
                    Options = table.Column<string>(nullable: true),
                    DonorFirstName = table.Column<string>(nullable: true),
                    DonorLastName = table.Column<string>(nullable: true),
                    DonorLocation = table.Column<string>(nullable: true),
                    DonorEmail = table.Column<string>(nullable: true),
                    DonorPhoneNumber = table.Column<string>(nullable: true),
                    EcoFriendlyPurpose = table.Column<string>(nullable: true),
                    ImpactInvestmentAmount = table.Column<double>(nullable: false),
                    PurposePreferred = table.Column<string>(nullable: true),
                    Tenor = table.Column<string>(nullable: true),
                    DonorBank = table.Column<string>(nullable: true),
                    DonorAccountNumber = table.Column<double>(nullable: false),
                    DonorAccountName = table.Column<string>(nullable: true),
                    LoanDonorDocumentsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDonors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanDonors_LoanDonorDocuments_LoanDonorDocumentsId",
                        column: x => x.LoanDonorDocumentsId,
                        principalTable: "LoanDonorDocuments",
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
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Facebook = table.Column<bool>(nullable: false),
                    Twitter = table.Column<bool>(nullable: false),
                    Instagram = table.Column<bool>(nullable: false),
                    RegDocumentId = table.Column<Guid>(nullable: false),
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
                name: "IX_LoanDonors_LoanDonorDocumentsId",
                table: "LoanDonors",
                column: "LoanDonorDocumentsId");

            migrationBuilder.CreateIndex(
                name: "IX_loans_LoanDocumentId",
                table: "loans",
                column: "LoanDocumentId");

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
                name: "contacts");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "LoanDonors");

            migrationBuilder.DropTable(
                name: "loans");

            migrationBuilder.DropTable(
                name: "MyMessages");

            migrationBuilder.DropTable(
                name: "MyRewards");

            migrationBuilder.DropTable(
                name: "recurringDonations");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "volunteers");

            migrationBuilder.DropTable(
                name: "CauseAccounts");

            migrationBuilder.DropTable(
                name: "LoanDonorDocuments");

            migrationBuilder.DropTable(
                name: "LoanDocument");

            migrationBuilder.DropTable(
                name: "RegistrationDocument");
        }
    }
}
