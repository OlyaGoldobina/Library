namespace LibraryOfClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Logging")]
    public partial class Logging
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string Login { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(100)]
        public string SecretQuestion { get; set; }

        [StringLength(100)]
        public string SecretAnswer { get; set; }
    }
}
