namespace LibraryOfClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Worker")]
    public partial class Worker
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Worker()
        {
            Tickets = new HashSet<Ticket>();
            TimeTables = new HashSet<TimeTable>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkerID { get; set; }

        public double Salary { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(100)]
        public string WorkingPosition { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimeTable> TimeTables { get; set; }
    }
}
