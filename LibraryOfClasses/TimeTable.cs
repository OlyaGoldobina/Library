namespace LibraryOfClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TimeTable")]
    public partial class TimeTable
    {
        [Key]
        [Column(Order = 0)]
        public DateTime Datetime { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FilmID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HallID { get; set; }

        public int? WorkerID { get; set; }

        public virtual Film Film { get; set; }

        public virtual Hall Hall { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
