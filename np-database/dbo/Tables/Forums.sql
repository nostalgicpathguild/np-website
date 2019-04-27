CREATE TABLE Forums (
	ForumID int IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	Title nvarchar (50)  NOT NULL ,
	[Description] nvarchar (255) NOT NULL ,
	Premoderated bit NOT NULL DEFAULT 0,
	GroupID int NOT NULL,
	MembersOnly bit NOT NULL DEFAULT 0,
	OrderByNumber int NOT NULL DEFAULT 0,
	RestrictTopicCreation bit NOT NULL DEFAULT 0,
	IconFile nvarchar(50) NULL
)