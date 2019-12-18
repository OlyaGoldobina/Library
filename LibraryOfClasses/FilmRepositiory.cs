using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfClasses
{
    class FilmRepositiory : IRepository<Film>
    {

        OurCinema Cinema =  Factory.Instance.GetOurCinema();



        public FilmRepositiory()
        {

        }

        public bool AddItem(Film item)
        {
            try
            {
                item.FilmID = Cinema.Films.Count() + 1;
                Cinema.Films.Add(item);
                Cinema.SaveChanges();
                return true;
            }
            catch 
            {

                return false;
            }

        }

        public bool RemoveItem(Film item)
        {
            try
            {
                foreach (Film film in Cinema.Films)
                {
                    if (film.FilmID == item.FilmID)
                    {
                        Cinema.Films.Remove(film);
                        Cinema.SaveChanges();
                        return true;
                    }
                }

            }
            catch (Exception)
            {

                return false;
            }
            return false;
        }

        public bool UpdateItem(Film previous, Film updated)
        {
            try
            {
                int id = previous.FilmID;
                updated.FilmID = id;
                foreach (Film film in Cinema.Films)
                {
                    if (film.FilmID == previous.FilmID)
                    {
                        Cinema.Films.Remove(film);
                        Cinema.Films.Add(updated);
                        Cinema.SaveChanges();
                        return true;

                    }
                }

            }
            catch
            {

                return false;
            }
            return false;
            
        }

        public DbSet SelectItem()
        {
            DbSet dbSet = Cinema.Films;
            return dbSet;
        }
    }
}
