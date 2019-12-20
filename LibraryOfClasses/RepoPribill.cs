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
                var blogNames = Cinema.Database.SqlQuery<double>(
                                   "select sum(Tar.Price) from [dbo].[Ticket] as T join [dbo].[Tariff] as Tar on T.TariffID = Tar.TariffID where MONTH(T.TimeofBuyng) = Month(SYSDATETIME()) and Year(T.TimeofBuyng) = Year(SYSDATETIME())").ToList();

            return blogNames[0];

        }
        public double VariableCost()
        {
            double VC = new double();
            VC += Cinema.Database.SqlQuery<double>(
                                    "select sum(Salary) from  [dbo].[Worker]").ToList()[0];

            VC += Cinema.Database.SqlQuery<double>(
                                   "select sum(CostOfMovieRental) from [dbo].[Film] where MONTH(Start) = Month(SYSDATETIME()) and Year(Start) = Year(SYSDATETIME())").ToList()[0];

            return VC;
        }
        public double FixCost()
        {
            double FC = new double();
            FC += Cinema.Database.SqlQuery<double>(
                                    "select sum(Cost) from[dbo].[Halls]").ToList()[0];
 
            return FC;
        }
        public double TotalCost() => FixCost() + VariableCost();
        public double TotalProfit() => TotalRevue() - TotalCost();


    }
}
