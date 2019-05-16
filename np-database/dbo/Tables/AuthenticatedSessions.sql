CREATE TABLE [dbo].[AuthenticatedSessions]
(
	[AuthenticatedSessionId] INT IDENTITY (1, 1) NOT NULL, 
    [ASPNetSessionId] NVARCHAR(MAX) NULL, 
    [UserId] INT NOT NULL, 
    [IpAddress] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_AuthenticatedSession] PRIMARY KEY CLUSTERED ([AuthenticatedSessionId] ASC), 
    CONSTRAINT [FK_AuthenticatedSessions_User] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId]), 
)
