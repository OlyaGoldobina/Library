namespace LibraryOfClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Film")]
    public partial class Film
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Film()
        {
            Rateds = new HashSet<Rated>();
            TimeTables = new HashSet<TimeTable>();
        }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FilmID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Start { get; set; }

        [Column(TypeName = "date")]
        public DateTime Finish { get; set; }

        public double Rating { get; set; }

        public float CostOfMovieRental { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rated> Rateds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimeTable> TimeTables { get; set; }
    }
}
