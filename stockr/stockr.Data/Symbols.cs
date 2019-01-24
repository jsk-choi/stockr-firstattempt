namespace stockr.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Symbols
    {
        public int Id { get; set; }

        public int iexId { get; set; }

        [StringLength(50)]
        public string Symbol { get; set; }

        [StringLength(300)]
        public string SymbolName { get; set; }

        public bool? isEnabled { get; set; }

        [StringLength(50)]
        public string SymbolType { get; set; }

        public DateTime DateModified { get; set; }
    }
}
