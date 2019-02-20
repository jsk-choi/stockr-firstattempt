
use stockr
GO

DROP PROC IF EXISTS dbo.spQuotesCleanup
GO

CREATE PROC [dbo].[spQuotesCleanup] (
	@DaysBack INT = 0
)
AS

DECLARE @DateBackDelete DATE = CAST(DATEADD(DD, -ABS(@DaysBack), GETDATE()) AS DATE)

INSERT INTO dbo.Quote___old (
	SystemTime, symbol, avgTotalVolume, calculationPrice, change, changePercent, [close], closeTime, delayedPrice, delayedPriceTime, extendedChange, extendedChangePercent, extendedPrice, extendedPriceTime, high, iexAskPrice, iexAskSize, iexBidPrice, iexBidSize, iexLastUpdated, iexMarketPercent, iexRealtimePrice, iexRealtimeSize, iexVolume, latestPrice, latestSource, latestTime, latestUpdate, latestVolume, low, marketCap, [open], openTime, peRatio, previousClose, week52High, week52Low, ytdChange
)
SELECT SystemTime, symbol, avgTotalVolume, calculationPrice, change, changePercent, [close], closeTime, delayedPrice, delayedPriceTime, extendedChange, extendedChangePercent, extendedPrice, extendedPriceTime, high, iexAskPrice, iexAskSize, iexBidPrice, iexBidSize, iexLastUpdated, iexMarketPercent, iexRealtimePrice, iexRealtimeSize, iexVolume, latestPrice, latestSource, latestTime, latestUpdate, latestVolume, low, marketCap, [open], openTime, peRatio, previousClose, week52High, week52Low, ytdChange 
FROM dbo.Quote
WHERE CAST(SystemTime AS DATE) < @DateBackDelete

DELETE FROM dbo.Quote
WHERE CAST(SystemTime AS DATE) < @DateBackDelete
