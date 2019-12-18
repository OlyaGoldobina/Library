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
        public List<Film> Films { get; set;} = new List<Film>();

        OurCinema Cinema =  Factory.Instance.GetOurCinema();



        public FilmRepositiory()
        {

        }

        public void AddItem(Film item)
        {
            item.FilmID = Cinema.Films.Count() + 1;
            Cinema.Films.Add(item);
            Cinema.SaveChanges();
        }

        public void RemoveItem(Film item)
        {
            foreach (Film film in Cinema.Films)
            {
                if (film.FilmID == item.FilmID)
                {
                    Cinema.Films.Remove(film);
                    break;
                }
            }
          
            Cinema.SaveChanges();
        }

        public void UpdateItem(Film previous, Film updated)
        {

            updated.FilmID = previous.FilmID;
            foreach (Film film in Cinema.Films)
            {
                if (film.FilmID == previous.FilmID)
                {
                    Cinema.Films.Remove(film);
                    break;
                }
            }
            Cinema.Films.Add(updated);
            Cinema.SaveChanges();
        }

        public DbSet SelectItem()
        {
            DbSet dbSet = Cinema.Films;
            return dbSet;
        }
    }
}
