CREATE TABLE ForumNewForumMsgSubscriptions (
	UserID int NOT NULL ,
	ForumID int NOT NULL 
)
GO
ALTER TABLE ForumNewForumMsgSubscriptions ADD 
	PRIMARY KEY 
	(
		UserID,
		ForumID
	)