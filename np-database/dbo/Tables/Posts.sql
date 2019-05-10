CREATE TABLE [dbo].[Posts]
(
	[PostId] INT IDENTITY (1, 1) NOT NULL,
	[TimeStamp] DATETIME NOT NULL, 
    [Content] NVARCHAR(MAX) NULL, 
    [AuthorId] INT NOT NULL, 
    [Title] NVARCHAR(MAX) NULL, 
    [EditedDateTime] DATETIME NULL, 
    [Removed] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED ([PostId] ASC), 
    CONSTRAINT [FK_Posts_Author] FOREIGN KEY ([AuthorId]) REFERENCES [Users]([UserId])
)
