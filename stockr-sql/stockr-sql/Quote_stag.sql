DROP TABLE dbo.Quote_stag
GO

CREATE TABLE dbo.Quote_stag (
	Id INT IDENTITY(1,1) PRIMARY KEY
	, [avgTotalVolume] BIGINT NULL
	, [calculationPrice] NVARCHAR(500) NULL
	, [change] DECIMAL(16,6) NULL
	, [changePercent] DECIMAL(16,6) NULL
	, [close] DECIMAL(16,6) NULL
	, [closeTime] BIGINT NULL
	, [companyName] NVARCHAR(500) NULL
	, [delayedPrice] DECIMAL(16,6) NULL
	, [delayedPriceTime] BIGINT NULL
	, [extendedChange] DECIMAL(16,6) NULL
	, [extendedChangePercent] DECIMAL(16,6) NULL
	, [extendedPrice] DECIMAL(16,6) NULL
	, [extendedPriceTime] BIGINT NULL
	, [high] DECIMAL(16,6) NULL
	, [iexAskPrice] BIGINT NULL
	, [iexAskSize] BIGINT NULL
	, [iexBidPrice] BIGINT NULL
	, [iexBidSize] BIGINT NULL
	, [iexLastUpdated] BIGINT NULL
	, [iexMarketPercent] DECIMAL(16,6) NULL
	, [iexRealtimePrice] DECIMAL(16,6) NULL
	, [iexRealtimeSize] BIGINT NULL
	, [iexVolume] BIGINT NULL
	, [latestPrice] DECIMAL(16,6) NULL
	, [latestSource] NVARCHAR(500) NULL
	, [latestTime] NVARCHAR(500) NULL
	, [latestUpdate] BIGINT NULL
	, [latestVolume] BIGINT NULL
	, [low] DECIMAL(16,6) NULL
	, [marketCap] BIGINT NULL
	, [open] DECIMAL(16,6) NULL
	, [openTime] BIGINT NULL
	, [peRatio] DECIMAL(16,6) NULL
	, [previousClose] DECIMAL(16,6) NULL
	, [primaryExchange] NVARCHAR(500) NULL
	, [sector] NVARCHAR(500) NULL
	, [symbol] NVARCHAR(500) NULL
	, [week52High] DECIMAL(16,6) NULL
	, [week52Low] BIGINT NULL
	, [ytdChange] DECIMAL(16,6) NULL
)

