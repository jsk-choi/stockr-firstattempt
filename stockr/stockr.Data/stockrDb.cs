namespace stockr.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class stockrDb : DbContext
    {
        public stockrDb()
            : base("name=stockrDb")
        {
        }

        public virtual DbSet<Symbols> Symbols { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Symbols>()
                .Property(e => e.Symbol)
                .IsUnicode(false);

            modelBuilder.Entity<Symbols>()
                .Property(e => e.SymbolName)
                .IsUnicode(false);

            modelBuilder.Entity<Symbols>()
                .Property(e => e.SymbolType)
                .IsUnicode(false);
        }
    }
}
