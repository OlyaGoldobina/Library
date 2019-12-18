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
                //Console.Write("Enter a name for a new Hall: ");
                //var name = Console.ReadLine();
                //Console.Write("\n Enter an id for a new Hall: ");
                //var id = int.Parse(Console.ReadLine());
                //var hall = new Hall { HallName = name, Cost = 100, HallID = id };
                //db.Halls.Add(hall);
                //db.SaveChanges();

                //// Display all Blogs from the database
                //var query = from b in db.Halls
                //            orderby b.HallName
                //            select b;

                //Console.WriteLine("All blogs in the database:");
                //foreach (var item in query)
                //{
                //    Console.WriteLine(item.HallName);
                //}
                FilmRepositiory rep = new FilmRepositiory();
                var Cinema = new OurCinema();
                //Cinema.Loggings.Add(new Logging() { Login = "123", Password = "123", SecretAnswer = "Obes", SecretQuestion = "NeObes" });
                //Cinema.SaveChanges();
                var film = new Film { FilmID = 22, Name = "Samy Luchiy Film 3", Start= DateTime.Parse("2019-12-17 00:00:00.0000000"), Finish = DateTime.Parse("2019-12-17 00:00:00.0000000"), Rating = 0, CostOfMovieRental = 0};
                rep.RemoveItem(film);
                //var film2 = new Film { FilmID = 21, Name = "Samy Luchiy Film 3", Start = DateTime.Now, Finish = DateTime.Now, Rating = 4, CostOfMovieRental = 110000 };
                ////rep.RemoveItem(film);
                //rep.UpdateItem(film, film2);
                Console.WriteLine("Press any key to exit....");
                Console.ReadKey();

            }
        }
    }
}
