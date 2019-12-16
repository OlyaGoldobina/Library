using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            Repository repo = new Repository();
            repo.Cinema.Halls.Add(new Hall()
            {
                ID = 1000,
                Name = "HALLOFPOWER",
                Cost = 100
            });
            repo.Cinema.SaveChanges();
        }
    }
}
