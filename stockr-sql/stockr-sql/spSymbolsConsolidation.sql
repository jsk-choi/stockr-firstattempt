IF OBJECT_ID('spSymbolsConsolidation') IS NOT NULL
	DROP PROCEDURE [dbo].[spSymbolsConsolidation]
GO

CREATE PROC [dbo].[spSymbolsConsolidation]
AS

IF OBJECT_ID('TempDB..#SymbolsTemp') IS NOT NULL
	DROP TABLE #SymbolsTemp
;

WITH Sym AS (
	SELECT iexId
		, Symbol
		, SymbolName
		, isEnabled
		, SymbolType
		, DateModified
		, Uniq = DENSE_RANK() OVER (
			PARTITION BY Symbol, SymbolName, isEnabled, SymbolType 
			ORDER BY Id
		)
	FROM dbo.Symbols
)
SELECT iexId
	, Symbol
	, SymbolName
	, isEnabled
	, SymbolType
	, DateModified
INTO #SymbolsTemp
FROM Sym
WHERE Uniq = 1
;

TRUNCATE TABLE dbo.Symbols
;

INSERT INTO dbo.Symbols (
	iexId
	, Symbol
	, SymbolName
	, isEnabled
	, SymbolType
	, DateModified 
)
SELECT iexId
	, Symbol
	, SymbolName
	, isEnabled
	, SymbolType
	, DateModified 
FROM #SymbolsTemp
;

GO


