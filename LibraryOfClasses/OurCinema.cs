using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LibraryOfClasses
{
    public class OurCinema : DbContext
    {
        public OurCinema() : base("OurCinema")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OurCinema>());
        }
        public DbSet<Film> Films { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<Viewer> Viewers { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Rated> Ratings { get; set; }

    }
}
