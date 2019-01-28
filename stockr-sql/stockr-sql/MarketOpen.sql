use stockr

IF OBJECT_ID('MarketOpen') IS NOT NULL
	DROP TABLE [dbo].[MarketOpen]
GO

CREATE TABLE [dbo].[MarketOpen] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DtOpen] DATETIME NOT NULL,
	[DtClose] DATETIME NOT NULL,
	[DateModified] DATETIME NOT NULL DEFAULT GETDATE(),
	CONSTRAINT PK_MarketOpen PRIMARY KEY (Id)
)
GO

CREATE NONCLUSTERED INDEX IX_MarketOpen_Dates
    ON dbo.MarketOpen (DtOpen, DtClose);
