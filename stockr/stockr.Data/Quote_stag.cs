namespace stockr.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Quote_stag
    {
        public int Id { get; set; }

        public long? avgTotalVolume { get; set; }

        [StringLength(500)]
        public string calculationPrice { get; set; }

        public decimal? change { get; set; }

        public decimal? changePercent { get; set; }

        public decimal? close { get; set; }

        public long? closeTime { get; set; }

        [StringLength(500)]
        public string companyName { get; set; }

        public decimal? delayedPrice { get; set; }

        public long? delayedPriceTime { get; set; }

        public decimal? extendedChange { get; set; }

        public decimal? extendedChangePercent { get; set; }

        public decimal? extendedPrice { get; set; }

        public long? extendedPriceTime { get; set; }

        public decimal? high { get; set; }

        public long? iexAskPrice { get; set; }

        public long? iexAskSize { get; set; }

        public long? iexBidPrice { get; set; }

        public long? iexBidSize { get; set; }

        public long? iexLastUpdated { get; set; }

        public decimal? iexMarketPercent { get; set; }

        public decimal? iexRealtimePrice { get; set; }

        public long? iexRealtimeSize { get; set; }

        public long? iexVolume { get; set; }

        public decimal? latestPrice { get; set; }

        [StringLength(500)]
        public string latestSource { get; set; }

        [StringLength(500)]
        public string latestTime { get; set; }

        public long? latestUpdate { get; set; }

        public long? latestVolume { get; set; }

        public decimal? low { get; set; }

        public long? marketCap { get; set; }

        public decimal? open { get; set; }

        public long? openTime { get; set; }

        public decimal? peRatio { get; set; }

        public decimal? previousClose { get; set; }

        [StringLength(500)]
        public string primaryExchange { get; set; }

        [StringLength(500)]
        public string sector { get; set; }

        [StringLength(500)]
        public string symbol { get; set; }

        public decimal? week52High { get; set; }

        public long? week52Low { get; set; }

        public decimal? ytdChange { get; set; }
    }
}
