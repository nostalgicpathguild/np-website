CREATE TABLE ForumPersonalMessages (
	MessageID int IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	FromUserID int NOT NULL ,
	ToUserID int NOT NULL ,
	Body ntext NOT NULL ,
	CreationDate datetime NOT NULL ,
	New bit NOT NULL DEFAULT 1 ,
	HiddenBySender bit NOT NULL DEFAULT 0 ,
	HiddenByRecipient bit NOT NULL DEFAULT 0
)