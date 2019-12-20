namespace LibraryOfClasses
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;

    public partial class OurCinema : DbContext
    {
        public OurCinema()
            : base("name=Model1")
        {
        }
        public virtual void ChangeQuestionAndAnswer(string Password, string NewQuestion, string NewAnswer)
        {
            foreach (var item in Loggings)
            {
                if ((item.Login == LoginUser) && (item.Password == Password))
                {
                    item.SecretQuestion = NewQuestion;
                    item.SecretAnswer = NewAnswer;
                    SaveChanges();
                    break;
                }
            }
        }  

        public virtual void ChangePassword(string OldPassword, string NewPassword)
        {
            foreach (var item in Loggings)
            {
                if ((item.Login == LoginUser)&&( item.Password == OldPassword ))
                {
                    item.Password = NewPassword;
                    SaveChanges();
                    break;
                }
            }
        }

        public virtual string LoginUser { get; set; }
        public virtual string ReturnQuestionOnLogin(string Login)
        {
            foreach (var item in Loggings)
            {
                if (item.Login == Login)
                {
                    return item.SecretQuestion;
                }
            }
            return null;
        }
        public static List<string> ListOfQuest = new List<string>() {"What is your mother second name","What is your first pet name?","What is your favorite food?" };
        public virtual bool ReturnPasswordOnSA(string Answer, string Login)
        {
            foreach (var item in Loggings)
            {
                if ((item.SecretAnswer == Answer) && (item.Login == Login))
                {
                    return true;
                }
            }
            return false;
        }

        public virtual bool CheckLog(string Login, string Password)
        {
            foreach (var item in Loggings)
            {
                if ((item.Password == Password) && (item.Login == Login))
                {
                    LoginUser = item.Login;
                    return true;
                }
            }
            return false;
        }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<Rated> Rateds { get; set; }
        public virtual DbSet<Tariff> Tariffs { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TimeTable> TimeTables { get; set; }
        public virtual DbSet<Viewer> Viewers { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<Logging> Loggings { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                .HasMany(e => e.Rateds)
                .WithRequired(e => e.Film)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Film>()
                .HasMany(e => e.TimeTables)
                .WithRequired(e => e.Film)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hall>()
                .HasMany(e => e.TimeTables)
                .WithRequired(e => e.Hall)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tariff>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Tariff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Viewer>()
                .HasMany(e => e.Rateds)
                .WithRequired(e => e.Viewer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Worker>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Worker)
                .HasForeignKey(e => e.SalerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.start_ip_address)
                .IsUnicode(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.end_ip_address)
                .IsUnicode(false);
        }
    }
}
