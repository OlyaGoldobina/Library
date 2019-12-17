namespace LibraryOfClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TicketID { get; set; }

        public DateTime TimeofBuyng { get; set; }

        public int TariffID { get; set; }

        public int? ViewerID { get; set; }

        public int SalerID { get; set; }

        public virtual Tariff Tariff { get; set; }

        public virtual Viewer Viewer { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
