IF OBJECT_ID('vSymbolsExtended') IS NOT NULL
	DROP VIEW [dbo].[vSymbolsExtended]
GO

CREATE VIEW [dbo].[vSymbolsExtended] 
AS
WITH SymExt AS (
	SELECT Id
		, symbol
		, companyName
		, primaryExchange
		, sector
		, DateModified
		, Rw = ROW_NUMBER() OVER (PARTITION BY Symbol ORDER BY DateModified DESC)
	FROM dbo.SymbolsExtended
)
SELECT Id
	, symbol
	, companyName
	, primaryExchange
	, sector
	, DateModified
FROM SymExt
WHERE Rw = 1
GO


