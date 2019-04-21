CREATE TABLE [dbo].[Events]
(
	[EventId] INT IDENTITY (1, 1) NOT NULL,
    [EventDateTime] DATETIME NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Leader] NVARCHAR(MAX) NULL, 
    [Removed] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED ([EventId] ASC), 
)
