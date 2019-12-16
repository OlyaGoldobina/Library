using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfClasses
{
    class Tariff : Entity
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public float Price { get; set; }
        public int D { get; set; }
        public bool Weekend { get; set; }
        public bool Morning { get; set; }
    }
}
