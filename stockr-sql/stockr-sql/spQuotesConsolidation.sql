use stockr
GO

DROP PROC IF EXISTS dbo.spQuotesConsolidation
GO

CREATE PROC [dbo].[spQuotesConsolidation]
AS
INSERT INTO dbo.Quote (
	[SystemTime]
	, [symbol]
	, [avgTotalVolume]
	, [calculationPrice]
	, [change]
	, [changePercent]
	, [close]
	, [closeTime]
	, [delayedPrice]
	, [delayedPriceTime]
	, [extendedChange]
	, [extendedChangePercent]
	, [extendedPrice]
	, [extendedPriceTime]
	, [high]
	, [iexAskPrice]
	, [iexAskSize]
	, [iexBidPrice]
	, [iexBidSize]
	, [iexLastUpdated]
	, [iexMarketPercent]
	, [iexRealtimePrice]
	, [iexRealtimeSize]
	, [iexVolume]
	, [latestPrice]
	, [latestSource]
	, latestTime
	, [latestUpdate]
	, [latestVolume]
	, [low]
	, [marketCap]
	, [open]
	, [openTime]
	, [peRatio]
	, [previousClose]
	, [week52High]
	, [week52Low]
	, [ytdChange]
)
SELECT s.[SystemTime]
	, s.[symbol]
	, s.[avgTotalVolume]
	, s.[calculationPrice]
	, s.[change]
	, s.[changePercent]
	, s.[close]
	, s.[closeTime]
	, s.[delayedPrice]
	, s.[delayedPriceTime]
	, s.[extendedChange]
	, s.[extendedChangePercent]
	, s.[extendedPrice]
	, s.[extendedPriceTime]
	, s.[high]
	, s.[iexAskPrice]
	, s.[iexAskSize]
	, s.[iexBidPrice]
	, s.[iexBidSize]
	, s.[iexLastUpdated]
	, s.[iexMarketPercent]
	, s.[iexRealtimePrice]
	, s.[iexRealtimeSize]
	, s.[iexVolume]
	, s.[latestPrice]
	, s.[latestSource]
	, TRY_CAST(s.[latestTime] AS TIME(0)) latestTime
	, s.[latestUpdate]
	, s.[latestVolume]
	, s.[low]
	, s.[marketCap]
	, s.[open]
	, s.[openTime]
	, s.[peRatio]
	, s.[previousClose]
	, s.[week52High]
	, s.[week52Low]
	, s.[ytdChange]
FROM dbo.Quote_stag s
	LEFT JOIN dbo.Quote q
		ON s.symbol = q.symbol
			AND s.latestUpdate = q.latestUpdate
WHERE q.symbol IS NULL

TRUNCATE TABLE dbo.Quote_stag
