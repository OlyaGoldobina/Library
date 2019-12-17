using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfClasses
{
    class FilmRepositiory : IRepository<Film>
    {
        public List<Film> Films { get; set;} = new List<Film>();

        public FilmRepositiory()
        {

        }

        public void AddItem(Film item)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(Film item)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Film item)
        {
            throw new NotImplementedException();
        }
    }
}
