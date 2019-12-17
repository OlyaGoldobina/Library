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
            using (var db = new OurCinema())
            {
                // Create and save a new Blog
                Console.Write("Enter a name for a new Hall: ");
                var name = Console.ReadLine();

                var hall = new Hall { HallName = name, Cost = 100, HallID = 200 };
                db.Halls.Add(hall);
                db.SaveChanges();

                // Display all Blogs from the database
                var query = from b in db.Halls
                            orderby b.HallName
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.HallName);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
