namespace stockr.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vSymbols
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iexId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Symbol { get; set; }

        [StringLength(300)]
        public string SymbolName { get; set; }

        public bool? isEnabled { get; set; }

        [StringLength(50)]
        public string SymbolType { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime DateModified { get; set; }
    }
}
