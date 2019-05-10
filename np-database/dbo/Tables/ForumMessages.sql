CREATE TABLE ForumMessages (
	MessageID int IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	TopicID int NOT NULL ,
	UserID int NOT NULL ,
	Body ntext NOT NULL ,
	CreationDate datetime NOT NULL ,
	Visible bit NOT NULL DEFAULT 1,
	IPAddress varchar(50),
	Rating int NOT NULL DEFAULT 0,
	AcceptedAnswer bit NOT NULL DEFAULT 0
)