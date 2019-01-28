IF OBJECT_ID('Quote') IS NOT NULL
	DROP TABLE [dbo].[Quote]
GO

CREATE TABLE [dbo].[Quote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[symbol] [nvarchar](500) NULL,
	[avgTotalVolume] [bigint] NULL,
	[calculationPrice] [nvarchar](500) NULL,
	[change] [decimal](16, 6) NULL,
	[changePercent] [decimal](16, 6) NULL,
	[close] [decimal](16, 6) NULL,
	[closeTime] [bigint] NULL,
	[delayedPrice] [decimal](16, 6) NULL,
	[delayedPriceTime] [bigint] NULL,
	[extendedChange] [decimal](16, 6) NULL,
	[extendedChangePercent] [decimal](16, 6) NULL,
	[extendedPrice] [decimal](16, 6) NULL,
	[extendedPriceTime] [bigint] NULL,
	[high] [decimal](16, 6) NULL,
	[iexAskPrice] [bigint] NULL,
	[iexAskSize] [bigint] NULL,
	[iexBidPrice] [bigint] NULL,
	[iexBidSize] [bigint] NULL,
	[iexLastUpdated] [bigint] NULL,
	[iexMarketPercent] [decimal](16, 6) NULL,
	[iexRealtimePrice] [decimal](16, 6) NULL,
	[iexRealtimeSize] [bigint] NULL,
	[iexVolume] [bigint] NULL,
	[latestPrice] [decimal](16, 6) NULL,
	[latestSource] [nvarchar](500) NULL,
	[latestTime] time NULL,
	[latestUpdate] [bigint] NULL,
	[latestVolume] [bigint] NULL,
	[low] [decimal](16, 6) NULL,
	[marketCap] [bigint] NULL,
	[open] [decimal](16, 6) NULL,
	[openTime] [bigint] NULL,
	[peRatio] [decimal](16, 6) NULL,
	[previousClose] [decimal](16, 6) NULL,
	[week52High] [decimal](16, 6) NULL,
	[week52Low] [bigint] NULL,
	[ytdChange] [decimal](16, 6) NULL
	CONSTRAINT PK_Quote PRIMARY KEY (Id)
)
GO

CREATE NONCLUSTERED INDEX IX_Quote_Symbol
    ON dbo.Quote (Symbol)
	INCLUDE (iexLastUpdated
);
