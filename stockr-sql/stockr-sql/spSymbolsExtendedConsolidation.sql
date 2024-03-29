
IF OBJECT_ID('spSymbolsExtendedConsolidation') IS NOT NULL
	DROP PROC [dbo].[spSymbolsExtendedConsolidation]
GO

CREATE PROC [dbo].[spSymbolsExtendedConsolidation]
AS

IF OBJECT_ID('TempDB..#SymbolsExtended') IS NOT NULL
	DROP TABLE #SymbolsExtended
;

DECLARE @dtm DATETIME = GETDATE()
;

WITH SymExt AS (
	SELECT Symbol
		, companyName
		, primaryExchange
		, sector
		, DateModified
	FROM dbo.SymbolsExtended
	UNION
	SELECT Symbol
		, companyName
		, primaryExchange
		, sector
		, @dtm
	FROM dbo.Quote_stag
)
, SymExtUniq AS (
	SELECT Symbol
		, companyName
		, primaryExchange
		, sector
		, DateModified
		, Uniq = ROW_NUMBER() OVER (
			PARTITION BY Symbol
				, companyName
				, primaryExchange
				, sector
			ORDER BY DateModified DESC
		)
	FROM SymExt
)
SELECT Symbol
	, companyName
	, primaryExchange
	, sector
	, DateModified
INTO #SymbolsExtended
FROM SymExtUniq
WHERE Uniq = 1
;

TRUNCATE TABLE dbo.SymbolsExtended
;

INSERT INTO dbo.SymbolsExtended (
	Symbol
	, companyName
	, primaryExchange
	, sector
	, DateModified
)
SELECT Symbol
	, companyName
	, primaryExchange
	, sector
	, DateModified
FROM #SymbolsExtended
;

IF OBJECT_ID('TempDB..#SymbolsExtended') IS NOT NULL
	DROP TABLE #SymbolsExtended
;
