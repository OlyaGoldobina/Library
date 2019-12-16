using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryOfClasses
{
    class Repository
    {

        public OurCinema Cinema { get; set; } 

        public Repository()
        {
            OurCinema Cinema = new OurCinema();
        }
    }
}
