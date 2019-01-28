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
SELECT Id
	, iexId
	, Symbol
	, SymbolName
	, isEnabled
	, SymbolType
	, DateModified
FROM Sym
WHERE Rw = 1
GO


