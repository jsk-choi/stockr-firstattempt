use stockr

IF OBJECT_ID('vSymbols') IS NOT NULL
	DROP VIEW [dbo].[vSymbols]
GO

CREATE VIEW [dbo].[vSymbols] 
AS
WITH Sym AS (
	SELECT Id
		, iexId
		, Symbol
		, SymbolName
		, isEnabled
		, SymbolType
		, DateModified
		, Rw = ROW_NUMBER() OVER (PARTITION BY Symbol ORDER BY DateModified DESC)
	FROM dbo.Symbols
)
SELECT s.Id
	, s.iexId
	, s.Symbol
	, s.SymbolName
	, s.isEnabled
	, s.SymbolType
	, ISNULL(ex.companyName, '') companyName
	, ISNULL(ex.primaryExchange, '') primaryExchange
	, ISNULL(ex.sector, '') sector
	, s.DateModified DateModifiedSymbol
	, ISNULL(ex.DateModified, '') DateModifiedSymbolExtd
FROM Sym s
	LEFT JOIN vSymbolsExtended ex
		ON s.Symbol = ex.symbol
WHERE Rw = 1
GO


