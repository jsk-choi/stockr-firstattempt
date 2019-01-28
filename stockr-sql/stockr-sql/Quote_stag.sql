use stockr

IF OBJECT_ID('Quote_stag') IS NOT NULL
	DROP TABLE dbo.Quote_stag
GO

CREATE TABLE dbo.Quote_stag (
	Id INT IDENTITY(1,1) PRIMARY KEY
	, [SystemTime] DATETIME NOT NULL
	, [avgTotalVolume] BIGINT NULL
	, [calculationPrice] NVARCHAR(500) NULL
	, [change] DECIMAL(32,5) NULL
	, [changePercent] DECIMAL(32,5) NULL
	, [close] DECIMAL(32,5) NULL
	, [closeTime] BIGINT NULL
	, [companyName] NVARCHAR(500) NULL
	, [delayedPrice] DECIMAL(32,5) NULL
	, [delayedPriceTime] BIGINT NULL
	, [extendedChange] DECIMAL(32,5) NULL
	, [extendedChangePercent] DECIMAL(32,5) NULL
	, [extendedPrice] DECIMAL(32,5) NULL
	, [extendedPriceTime] BIGINT NULL
	, [high] DECIMAL(32,5) NULL
	, [iexAskPrice] BIGINT NULL
	, [iexAskSize] BIGINT NULL
	, [iexBidPrice] BIGINT NULL
	, [iexBidSize] BIGINT NULL
	, [iexLastUpdated] BIGINT NULL
	, [iexMarketPercent] DECIMAL(32,5) NULL
	, [iexRealtimePrice] DECIMAL(32,5) NULL
	, [iexRealtimeSize] BIGINT NULL
	, [iexVolume] BIGINT NULL
	, [latestPrice] DECIMAL(32,5) NULL
	, [latestSource] NVARCHAR(500) NULL
	, [latestTime] NVARCHAR(500) NULL
	, [latestUpdate] BIGINT NULL
	, [latestVolume] BIGINT NULL
	, [low] DECIMAL(32,5) NULL
	, [marketCap] BIGINT NULL
	, [open] DECIMAL(32,5) NULL
	, [openTime] BIGINT NULL
	, [peRatio] DECIMAL(32,5) NULL
	, [previousClose] DECIMAL(32,5) NULL
	, [primaryExchange] NVARCHAR(500) NULL
	, [sector] NVARCHAR(500) NULL
	, [symbol] NVARCHAR(500) NULL
	, [week52High] DECIMAL(32,5) NULL
	, [week52Low] BIGINT NULL
	, [ytdChange] DECIMAL(32,5) NULL
)

