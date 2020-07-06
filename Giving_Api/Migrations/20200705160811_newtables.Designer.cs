﻿// <auto-generated />
using System;
using Giving_Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Giving_Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200705160811_newtables")]
    partial class newtables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Giving_Api.Models.Cause", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BeneficiaryAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BeneficiaryNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CauseBeneficiaryAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCountDown")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Device")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Donation")
                        .HasColumnType("float");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpectedProjectImpact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PicturePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TargetAmount")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CauseBeneficiaryAccountId");

                    b.ToTable("Cause");
                });

            modelBuilder.Entity("Giving_Api.Models.CauseAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BeneficiaryAccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BeneficiaryAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BeneficiaryBank")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CauseAccounts");
                });

            modelBuilder.Entity("Giving_Api.Models.Contact", b =>
                {
                    b.Property<Guid>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CauseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Device")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("ContactID");

                    b.ToTable("contacts");
                });

            modelBuilder.Entity("Giving_Api.Models.Donation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<bool>("Annonymous")
                        .HasColumnType("bit");

                    b.Property<string>("CVV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CardNumber")
                        .HasColumnType("int");

                    b.Property<string>("CauseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Device")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpiryDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Frequency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("Giving_Api.Models.LoanDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BusinessPlan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyRegistrationDocuments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Device")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuarantorLetter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IndemnityForm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeansOfIdentification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RelevantPictures")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoRecording")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoanDocument");
                });

            modelBuilder.Entity("Giving_Api.Models.LoanDonor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Device")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonorAccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DonorAccountNumber")
                        .HasColumnType("float");

                    b.Property<string>("DonorBank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonorEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonorFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonorLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonorLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonorPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EcoFriendlyPurpose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ImpactInvestmentAmount")
                        .HasColumnType("float");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LoanDonorDocumentsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoanId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Options")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PurposePreferred")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tenor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LoanDonorDocumentsId");

                    b.ToTable("LoanDonors");
                });

            modelBuilder.Entity("Giving_Api.Models.LoanDonorDocuments", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MeansOfIdentification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("registrationdocuments")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoanDonorDocuments");
                });

            modelBuilder.Entity("Giving_Api.Models.Loans", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AmountRequested")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Device")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LoanDocumentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Purpose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Repaymentsource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tenor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LoanDocumentId");

                    b.ToTable("loans");
                });

            modelBuilder.Entity("Giving_Api.Models.MessageContent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("messageCode")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("messageContents");
                });

            modelBuilder.Entity("Giving_Api.Models.MyMessages", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Device")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MyMessages");
                });

            modelBuilder.Entity("Giving_Api.Models.MyRewards", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Device")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MyRewards");
                });

            modelBuilder.Entity("Giving_Api.Models.RecurringDonations", b =>
                {
                    b.Property<Guid>("RecurringDonationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CauseID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Device")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DonationDay")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DonationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Frequency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("statusId")
                        .HasColumnType("int");

                    b.HasKey("RecurringDonationID");

                    b.ToTable("recurringDonations");
                });

            modelBuilder.Entity("Giving_Api.Models.RegistrationDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AlumniAssociationSetup_Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorizedSignatoryList_Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CAC_RegDocument_Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorporateGovernanceStructure_Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Device")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identification_Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemorandumOfAssociation_Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValidIdentificationOfAuthorizedSignatories_Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RegistrationDocument");
                });

            modelBuilder.Entity("Giving_Api.Models.Review", b =>
                {
                    b.Property<Guid>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CauseID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Device")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReviewTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReviewID");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("Giving_Api.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConfirmationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Device")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Giving_Api.Models.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Device")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Facebook")
                        .HasColumnType("bit");

                    b.Property<bool>("Instagram")
                        .HasColumnType("bit");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PysicalAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegDocumentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Twitter")
                        .HasColumnType("bit");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RegDocumentId");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("Giving_Api.Models.Volunteer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Device")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InterestDuration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("VolunteerPledge")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("volunteers");
                });

            modelBuilder.Entity("Giving_Api.Models.Cause", b =>
                {
                    b.HasOne("Giving_Api.Models.CauseAccount", "CauseBeneficiaryAccount")
                        .WithMany()
                        .HasForeignKey("CauseBeneficiaryAccountId");
                });

            modelBuilder.Entity("Giving_Api.Models.LoanDonor", b =>
                {
                    b.HasOne("Giving_Api.Models.LoanDonorDocuments", "LoanDonorDocuments")
                        .WithMany()
                        .HasForeignKey("LoanDonorDocumentsId");
                });

            modelBuilder.Entity("Giving_Api.Models.Loans", b =>
                {
                    b.HasOne("Giving_Api.Models.LoanDocument", "LoanDocument")
                        .WithMany()
                        .HasForeignKey("LoanDocumentId");
                });

            modelBuilder.Entity("Giving_Api.Models.UserProfile", b =>
                {
                    b.HasOne("Giving_Api.Models.RegistrationDocument", "RegDocument")
                        .WithMany()
                        .HasForeignKey("RegDocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}