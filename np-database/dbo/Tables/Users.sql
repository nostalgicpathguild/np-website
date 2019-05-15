CREATE TABLE [dbo].[Users]
(
	[UserId] INT IDENTITY (1, 1) NOT NULL,
    [Email] NVARCHAR(MAX) NOT NULL, 
    [Password] VARBINARY(1024) NOT NULL, 
    [PasswordSalt] VARBINARY(1024) NOT NULL, 
    [CharacterName] NVARCHAR(MAX) NULL, 
    [UserLevelId] INT NOT NULL, 
    [DiscordAccessToken] NVARCHAR(MAX) NULL, 
    [DiscordRefreshToken] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC), 
    CONSTRAINT [FK_Users_UserLevel] FOREIGN KEY ([UserLevelId]) REFERENCES [UserLevels]([UserLevelId])
)
