CREATE TABLE ForumTopics (
	TopicID int IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	ForumID int NOT NULL ,
	UserID int NOT NULL ,
	[Subject] nvarchar (255) NOT NULL ,
	Visible bit NOT NULL ,
	LastMessageID int NOT NULL DEFAULT 0,
	IsSticky int NOT NULL DEFAULT 0,
	IsClosed bit NOT NULL DEFAULT 0,
	ViewsCount int NOT NULL DEFAULT 0,
	RepliesCount int NOT NULL DEFAULT 0
)