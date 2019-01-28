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

        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<MarketOpen> MarketOpen { get; set; }

        public virtual DbSet<Quote> Quote { get; set; }
        public virtual DbSet<Quote_stag> Quote_stag { get; set; }

        public virtual DbSet<Symbols> Symbols { get; set; }
        public virtual DbSet<SymbolsExtended> SymbolsExtended { get; set; }

        public virtual DbSet<vSymbols> vSymbols { get; set; }
        public virtual DbSet<vSymbolsExtended> vSymbolsExtended { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Quote>()
                .Property(e => e.change)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote>()
                .Property(e => e.changePercent)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote>()
                .Property(e => e.close)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote>()
                .Property(e => e.delayedPrice)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote>()
                .Property(e => e.extendedChange)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote>()
                .Property(e => e.extendedChangePercent)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote>()
                .Property(e => e.extendedPrice)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote>()
                .Property(e => e.high)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote>()
                .Property(e => e.iexMarketPercent)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote>()
                .Property(e => e.iexRealtimePrice)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote>()
                .Property(e => e.latestPrice)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote>()
                .Property(e => e.low)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote>()
                .Property(e => e.open)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote>()
                .Property(e => e.peRatio)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote>()
                .Property(e => e.previousClose)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote>()
                .Property(e => e.week52High)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote>()
                .Property(e => e.ytdChange)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.change)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.changePercent)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.close)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.delayedPrice)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.extendedChange)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.extendedChangePercent)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.extendedPrice)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.high)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.iexMarketPercent)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.iexRealtimePrice)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.latestPrice)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.low)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.open)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.peRatio)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.previousClose)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.week52High)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Quote_stag>()
                .Property(e => e.ytdChange)
                .HasPrecision(32, 5);

            modelBuilder.Entity<Symbols>()
                .Property(e => e.Symbol)
                .IsUnicode(false);

            modelBuilder.Entity<Symbols>()
                .Property(e => e.SymbolName)
                .IsUnicode(false);

            modelBuilder.Entity<Symbols>()
                .Property(e => e.SymbolType)
                .IsUnicode(false);

            modelBuilder.Entity<SymbolsExtended>()
                .Property(e => e.symbol)
                .IsUnicode(false);

            modelBuilder.Entity<SymbolsExtended>()
                .Property(e => e.primaryExchange)
                .IsUnicode(false);

            modelBuilder.Entity<SymbolsExtended>()
                .Property(e => e.sector)
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

            modelBuilder.Entity<vSymbols>()
                .Property(e => e.primaryExchange)
                .IsUnicode(false);

            modelBuilder.Entity<vSymbols>()
                .Property(e => e.sector)
                .IsUnicode(false);

            modelBuilder.Entity<vSymbolsExtended>()
                .Property(e => e.symbol)
                .IsUnicode(false);

            modelBuilder.Entity<vSymbolsExtended>()
                .Property(e => e.primaryExchange)
                .IsUnicode(false);

            modelBuilder.Entity<vSymbolsExtended>()
                .Property(e => e.sector)
                .IsUnicode(false);
        }
    }
}
