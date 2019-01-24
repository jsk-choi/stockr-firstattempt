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

        public virtual DbSet<Quote_stag> Quote_stag { get; set; }
        public virtual DbSet<Symbols> Symbols { get; set; }
        public virtual DbSet<vSymbols> vSymbols { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quote_stag>()
                            .Property(e => e.change)
                            .HasPrecision(16, 6);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.changePercent)
                .HasPrecision(16, 6);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.close)
                .HasPrecision(16, 6);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.delayedPrice)
                .HasPrecision(16, 6);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.extendedChange)
                .HasPrecision(16, 6);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.extendedChangePercent)
                .HasPrecision(16, 6);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.extendedPrice)
                .HasPrecision(16, 6);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.high)
                .HasPrecision(16, 6);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.iexMarketPercent)
                .HasPrecision(16, 6);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.iexRealtimePrice)
                .HasPrecision(16, 6);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.latestPrice)
                .HasPrecision(16, 6);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.low)
                .HasPrecision(16, 6);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.open)
                .HasPrecision(16, 6);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.peRatio)
                .HasPrecision(16, 6);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.previousClose)
                .HasPrecision(16, 6);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.week52High)
                .HasPrecision(16, 6);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.ytdChange)
                .HasPrecision(16, 6);

            modelBuilder.Entity<Symbols>()
                .Property(e => e.Symbol)
                .IsUnicode(false);

            modelBuilder.Entity<Symbols>()
                .Property(e => e.SymbolName)
                .IsUnicode(false);

            modelBuilder.Entity<Symbols>()
                .Property(e => e.SymbolType)
                .IsUnicode(false);

            modelBuilder.Entity<vSymbols>()
                .Property(e => e.Symbol)
                .IsUnicode(false);

            modelBuilder.Entity<vSymbols>()
                .Property(e => e.SymbolName)
                .IsUnicode(false);

            modelBuilder.Entity<vSymbols>()
                .Property(e => e.SymbolType)
                .IsUnicode(false);
        }
    }
}
