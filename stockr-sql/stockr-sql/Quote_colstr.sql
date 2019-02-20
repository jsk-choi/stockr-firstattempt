use stockr

IF OBJECT_ID('Quote_colstr') IS NOT NULL
	DROP TABLE [dbo].[Quote_colstr]
GO

CREATE TABLE [dbo].[Quote_colstr](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SystemTime] DATETIME NOT NULL,
	[symbol] [nvarchar](500) NULL,
	[avgTotalVolume] [bigint] NULL,
	[calculationPrice] [nvarchar](500) NULL,
	[change] [decimal](32, 5) NULL,
	[changePercent] [decimal](32, 5) NULL,
	[close] [decimal](32, 5) NULL,
	[closeTime] [bigint] NULL,
	[delayedPrice] [decimal](32, 5) NULL,
	[delayedPriceTime] [bigint] NULL,
	[extendedChange] [decimal](32, 5) NULL,
	[extendedChangePercent] [decimal](32, 5) NULL,
	[extendedPrice] [decimal](32, 5) NULL,
	[extendedPriceTime] [bigint] NULL,
	[high] [decimal](32, 5) NULL,
	[iexAskPrice] [bigint] NULL,
	[iexAskSize] [bigint] NULL,
	[iexBidPrice] [bigint] NULL,
	[iexBidSize] [bigint] NULL,
	[iexLastUpdated] [bigint] NULL,
	[iexMarketPercent] [decimal](32, 5) NULL,
	[iexRealtimePrice] [decimal](32, 5) NULL,
	[iexRealtimeSize] [bigint] NULL,
	[iexVolume] [bigint] NULL,
	[latestPrice] [decimal](32, 5) NULL,
	[latestSource] [nvarchar](500) NULL,
	[latestTime] time NULL,
	[latestUpdate] [bigint] NULL,
	[latestVolume] [bigint] NULL,
	[low] [decimal](32, 5) NULL,
	[marketCap] [bigint] NULL,
	[open] [decimal](32, 5) NULL,
	[openTime] [bigint] NULL,
	[peRatio] [decimal](32, 5) NULL,
	[previousClose] [decimal](32, 5) NULL,
	[week52High] [decimal](32, 5) NULL,
	[week52Low] [bigint] NULL,
	[ytdChange] [decimal](32, 5) NULL
	CONSTRAINT PK_Quote_colstr PRIMARY KEY (Id)
)
GO

CREATE NONCLUSTERED INDEX IX_Quote_colstr_Symbol
    ON dbo.Quote_colstr (Symbol)
	INCLUDE (SystemTime);

CREATE COLUMNSTORE INDEX IX_Quote_colstr 
	ON dbo.Quote_colstr (symbol, latestPrice, SystemTime);

CREATE NONCLUSTERED INDEX IX_Quote_colstr_SystemTime
    ON dbo.Quote_colstr (SystemTime)
	INCLUDE (symbol, latestPrice);
