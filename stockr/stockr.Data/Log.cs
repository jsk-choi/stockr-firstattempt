namespace stockr.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public partial class Log
    {
        public int Id { get; set; }

        public DateTime SystemTime { get; set; }

        [StringLength(500)]
        public string Msg { get; set; }

        public DateTime DateModified { get; set; }
    }
}
