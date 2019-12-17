namespace LibraryOfClasses
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OurCinema : DbContext
    {
        public OurCinema()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<Rated> Rateds { get; set; }
        public virtual DbSet<Tariff> Tariffs { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TimeTable> TimeTables { get; set; }
        public virtual DbSet<Viewer> Viewers { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
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
