using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfClasses
{
    class Ticket
    {
        public int ID { get; set; }
        public DateTime TimeOfBuying { get; set; }
        public Tariff Tariff { get; set; }
        public Viewer Viewer { get; set; }
        public Worker Saler { get; set; }
    }
}
