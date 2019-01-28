use stockr

IF OBJECT_ID('Log') IS NOT NULL
	DROP TABLE [dbo].[Log]
GO

CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SystemTime] DATETIME NOT NULL,	
	[Msg] NVARCHAR(500) NULL,
	[DateModified] DATETIME NOT NULL DEFAULT GETDATE(),
	CONSTRAINT PK_Log PRIMARY KEY (Id)
)
GO