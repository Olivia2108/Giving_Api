using Giving_Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Giving_Api.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> Options) : base(Options)
        {
            //this.Database.EnsureCreated();

        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<RegistrationDocument> Documents { get; set; }
        public DbSet<Cause> Cause { get; set; }
        public DbSet<CauseAccount> CauseAccounts { get; set; }
        public DbSet<RegistrationDocument> RegistrationDocument { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<MyRewards> MyRewards { get; set; }
        public DbSet<MyMessages> MyMessages { get; set; }
        public DbSet<Volunteer> volunteers { get; set; }
        public DbSet<Loans> loans { get; set; }
        public DbSet<LoanDonor> LoanDonors { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<RecurringDonations> recurringDonations { get; set;}
        public DbSet<MessageContent> messageContents { get; set; }
    }
}
