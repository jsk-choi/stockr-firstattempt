namespace stockr.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MarketOpen")]
    public partial class MarketOpen
    {
        public int Id { get; set; }

        public DateTime DtOpen { get; set; }

        public DateTime DtClose { get; set; }

        public DateTime DateModified { get; set; }
    }
}
