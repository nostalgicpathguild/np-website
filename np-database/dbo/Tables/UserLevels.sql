CREATE TABLE [dbo].[UserLevels]
(
	[UserLevelId] INT IDENTITY (1, 1) NOT NULL, 
    [Name] NVARCHAR(MAX) NULL, 
    [Description] NVARCHAR(MAX) NULL,
    CONSTRAINT [PK_UserLevel] PRIMARY KEY CLUSTERED ([UserLevelId] ASC), 
)
