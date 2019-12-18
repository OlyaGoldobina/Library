using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfClasses
{
    class TariffRepositiory : IRepository<Tariff>
    {

        OurCinema Cinema = Factory.Instance.GetOurCinema();



        public TariffRepositiory()
        {

        }

        public void AddItem(Tariff item)
        {
            item.TariffID = Cinema.Tariffs.Count() + 1;
            Cinema.Tariffs.Add(item);
            Cinema.SaveChanges();
        }

        public void RemoveItem(Tariff item)
        {
            foreach (Tariff tariff in Cinema.Tariffs)
            {
                if (tariff.TariffID == item.TariffID)
                {
                    Cinema.Tariffs.Remove(tariff);
                    break;
                }
            }

            Cinema.SaveChanges();
        }

        public void UpdateItem(Tariff previous, Tariff updated)
        {
            int id = previous.TariffID;
            updated.TariffID = id;
            foreach (Tariff tariff in Cinema.Tariffs)
            {
                if (tariff.TariffID == previous.TariffID)
                {
                    Cinema.Tariffs.Remove(tariff);
                    break;
                }
            }
            Cinema.Tariffs.Add(updated);
            Cinema.SaveChanges();
        }

        public DbSet SelectItem()
        {
            DbSet dbSet = Cinema.Tariffs;
            return dbSet;
        }
    }
}
