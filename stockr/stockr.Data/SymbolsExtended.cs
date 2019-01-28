namespace stockr.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SymbolsExtended")]
    public partial class SymbolsExtended
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string symbol { get; set; }

        [StringLength(500)]
        public string companyName { get; set; }

        [StringLength(500)]
        public string primaryExchange { get; set; }

        [StringLength(500)]
        public string sector { get; set; }

        public DateTime DateModified { get; set; }
    }
}
