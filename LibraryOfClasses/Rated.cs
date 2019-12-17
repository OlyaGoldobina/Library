using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfClasses
{
    public class Rated
    {
        public int Mark { get; set; }

        [Key]
        public int ViewerID { get; set; }
        public int FilmID { get; set; }
        [ForeignKey("FilmID")]
        public Film Film { get; set; }
        [ForeignKey("ViewerID")]
        public Viewer Viewer { get; set; }
    }
}
