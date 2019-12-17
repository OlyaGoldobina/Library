using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfClasses
{
    public class TimeTable
    {
        public int WorkerID { get; set; }

        [Key]
        public DateTime DateTime { get; set; }
        public int FilmID { get; set; }
        public int HallID { get; set; }
        [ForeignKey("WorkerID")]
        public Worker Worker { get; set; }
        [ForeignKey("FilmID")]
        public Film Film { get; set; }

        [ForeignKey("HallID")]
        public Hall Hall { get; set; }


    }
}
