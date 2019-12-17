using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfClasses
{
    public class Factory
    {
        private Factory()
        {

        }
        static Factory _instance;

        public static Factory Instance
        {
            get {
                return _instance ?? (_instance = new Factory());
            }
        }

        OurCinema ourCinema = new OurCinema();
        public OurCinema GetOurCinema() => ourCinema;
    }
}
