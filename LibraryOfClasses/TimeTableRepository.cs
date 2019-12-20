using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfClasses
{
    public class TimeTableRepository : IRepository<TimeTable>
    {
        OurCinema Cinema = Factory.Instance.GetOurCinema();
        public TimeTableRepository()
        {

        }

        public bool AddItem(TimeTable item)
        {
            try
            {
                Cinema.TimeTables.Add(item);
                Cinema.SaveChanges();
                return true;

            }
            catch 
            {
                return false;
              
            }

        }

        public bool RemoveItem(TimeTable item)
        {
            try
            {

                Cinema.TimeTables.Remove(item);
                Cinema.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool UpdateItem(TimeTable previous, TimeTable updated)
        {
            try
            {
                foreach (TimeTable timeTable in Cinema.TimeTables)
                {
                    if ((timeTable.FilmID == previous.FilmID) & (timeTable.HallID == previous.HallID) & (timeTable.Datetime == previous.Datetime))
                    {
                        //Cinema.Films.Find(previous.FilmID).TimeTables.Remove(previous);
                        //Cinema.Halls.Find(previous.HallID).TimeTables.Remove(previous);
                        //Cinema.Workers.Find(previous.WorkerID).TimeTables.Remove(previous);
                        timeTable.Datetime = updated.Datetime;
                        timeTable.Film = updated.Film;

                        timeTable.FilmID = updated.FilmID;
                        timeTable.Hall = updated.Hall;
                        timeTable.HallID = updated.HallID;
                        timeTable.Worker = updated.Worker;
                        timeTable.WorkerID = updated.WorkerID;

                        //Cinema.Films.Find(updated.FilmID).TimeTables.Add(previous);

                        //Cinema.Halls.Find(updated.HallID).TimeTables.Add(previous);

                        //Cinema.Workers.Find(updated.WorkerID).TimeTables.Add(previous);
                        
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

        public List<TimeTable> SelectItem()
        {
            List<TimeTable> timetable = new List<TimeTable>();
            DbSet<TimeTable> dbSet = Cinema.TimeTables;
            foreach (TimeTable item in dbSet)
                timetable.Add(item);
            timetable.Sort((x, y) => x.Datetime.CompareTo(y.Datetime));
            return timetable;
        }

        public Film GetFilm(string name)
        {
            foreach(var film in Cinema.Films)
            {
                if(film.Name == name)
                    return film;
            }
            return null;
        }

        public Hall GetHall(string name)
        {
            foreach(var hall in Cinema.Halls)
            {
                if(hall.HallName == name)
                    return hall;
            }
            return null;
        }

        public Worker GetWorker(string name)
        {
            foreach(var worker in Cinema.Workers)
            {
                if(worker.Name == name)
                {
                    return worker;
                }
            }
            return null;
        }
    }
}
