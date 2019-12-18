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

        OurCinema Cinema = Factory.Instance.GetOurCinema();


        public WorkerRepositiory()
        {

        }

        public bool AddItem(Worker item)
        {
            try
            {
                int tempID = 0;
                foreach (Worker worker in Cinema.Workers)
                {
                    if (worker.WorkerID > tempID)
                    {
                        tempID = worker.WorkerID;
                    }
                }
                item.WorkerID = tempID + 1;
                Cinema.Workers.Add(item);
                Cinema.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveItem(Worker item)
        {
            try
            {
                foreach (Worker worker in Cinema.Workers)
                {
                    if (worker.WorkerID == item.WorkerID)
                    {
                        Cinema.Workers.Remove(worker);
                        
                    }
                }
                Cinema.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateItem(Worker previous, Worker updated)
        {
            try
            {
                int id = previous.WorkerID;
                updated.WorkerID = id;
                foreach (Worker worker in Cinema.Workers)
                {
                    if (worker.WorkerID == previous.WorkerID)
                    {
                        worker.Name = updated.Name;
                        worker.Salary = updated.Salary;
                        worker.Tickets = updated.Tickets;
                        worker.WorkingPosition = updated.WorkingPosition;
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public List<Worker> SelectItem()
        {
            List<Worker> workers = new List<Worker>();
            DbSet<Worker> dbSet = Cinema.Workers;
            foreach (Worker item in dbSet)
                workers.Add(item);
            return workers;
        }
    }
}
