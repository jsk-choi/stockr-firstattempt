USE stockr

DROP TABLE dbo.Symbols
GO

CREATE TABLE dbo.Symbols (
	Id INT NOT NULL IDENTITY(1,1)
	, iexId INT NOT NULL
	, Symbol VARCHAR(50) NOT NULL
	, SymbolName VARCHAR(300) NULL
	, isEnabled BIT NULL
	, SymbolType VARCHAR(50) NULL
	, DateModified DATETIME NOT NULL
	CONSTRAINT PK_Symbols PRIMARY KEY (Id)
)
GO

CREATE NONCLUSTERED INDEX IX_Symbols_Symbol
    ON dbo.Symbols (Symbol)
	INCLUDE (DateModified);
