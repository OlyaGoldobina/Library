using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfClasses
{
    class WorkerRepositiory : IRepository<Worker>
    {
        public List<Film> Films { get; set; } = new List<Film>();

        OurCinema Cinema = Factory.Instance.GetOurCinema();



        public WorkerRepositiory()
        {

        }

        public void AddItem(Worker item)
        {
            item.WorkerID = Cinema.Workers.Count() + 1;
            Cinema.Workers.Add(item);
            Cinema.SaveChanges();
        }

        public void RemoveItem(Worker item)
        {
            foreach (Worker worker in Cinema.Workers)
            {
                if (worker.WorkerID == item.WorkerID)
                {
                    Cinema.Workers.Remove(worker);
                    break;
                }
            }

            Cinema.SaveChanges();
        }

        public void UpdateItem(Worker previous, Worker updated)
        {
            int id = previous.WorkerID;
            updated.WorkerID = id;
            foreach (Worker worker in Cinema.Workers)
            {
                if (worker.WorkerID == previous.WorkerID)
                {
                    Cinema.Workers.Remove(worker);
                    break;
                }
            }
            Cinema.Workers.Add(updated);
            Cinema.SaveChanges();
        }

        public DbSet SelectItem()
        {
            DbSet dbSet = Cinema.Tariffs;
            return dbSet;
        }
    }
}
