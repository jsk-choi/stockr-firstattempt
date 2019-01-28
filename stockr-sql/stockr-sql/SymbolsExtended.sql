IF OBJECT_ID('SymbolsExtended') IS NOT NULL
	DROP TABLE dbo.SymbolsExtended
GO

CREATE TABLE dbo.SymbolsExtended (
	Id INT NOT NULL IDENTITY(1,1)
	, symbol VARCHAR(50) NULL
	, companyName NVARCHAR(500) NULL
	, primaryExchange VARCHAR(500) NULL
	, sector VARCHAR(500) NULL
	, DateModified DATETIME NOT NULL
	CONSTRAINT PK_SymbolsExtended PRIMARY KEY (Id)
)
GO

CREATE NONCLUSTERED INDEX IX_SymbolsExtended_Symbol
    ON dbo.SymbolsExtended (Symbol)
	INCLUDE (DateModified);
