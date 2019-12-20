using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfClasses
{
    public class RepoPribill
    {
        OurCinema Cinema = Factory.Instance.GetOurCinema();
        public double TotalRevue()
        {
            double Revue = new double();
            foreach (var item in Cinema.Tickets)
            {
                if ((item.TimeofBuyng.Month == DateTime.Now.Month) && (item.TimeofBuyng.Year == DateTime.Now.Year))
                {
                    Revue += item.Tariff.Price;
                }

            }
            return Revue;
        }
        public double VariableCost()
        {
            double VC = new double();
            foreach (var item in Cinema.Workers)
            {
                VC += item.Salary;
            }
            foreach (var item in Cinema.Films)
            {
                if ((item.Start.Month == DateTime.Now.Month) && (item.Start.Year == DateTime.Now.Year))
                {
                    VC += item.CostOfMovieRental;
                }

            }
            return VC;
        }
        public double FixCost()
        {
            double FC = new double();
            foreach (var item in Cinema.Halls)
            {
                FC += item.Cost;
            }
            return FC;
        }
        public double TotalCost() => FixCost() + VariableCost();
        public double TotalProfit() => TotalRevue() - TotalCost();


    }
}
