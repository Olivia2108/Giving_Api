using MessagingAlertSender.Models;
using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Giving.MonitoringMessagesSender.Models;

namespace MessagingAlertSender.Data
{

    

    
    [DbConfigurationType(typeof(SqlDatabaseConfiguration))]
    public partial class DataContext : System.Data.Entity.DbContext
    {
        public DataContext()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer<DataContext>(null);
        }

        public virtual DbSet<RecurringDonations> recurringDonations { get; set; }
        public virtual DbSet<MessageContent> messageContent { get; set; }



        //public class DataContext:DbContext
        //{
        //    public DataContext(DbContextOptions<DataContext> Options) : base(Options)
        //    {
        //        //this.Database.EnsureCreated();

        //    }

        //    public DbSet<RecurringDonations> recurringDonations { get; set;}
        //    public DbSet<MessageContent> messageContent { get; set; }
        //}
     }
}
