using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfClasses
{
    public class Worker : Entity
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public float Salary { get; set; }
        public DateTime BirthDate { get; set; }
        public string WorkingPosition { get; set; }
    }
}
