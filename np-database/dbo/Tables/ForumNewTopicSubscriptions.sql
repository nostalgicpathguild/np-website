CREATE TABLE ForumNewTopicSubscriptions (
	UserID int NOT NULL ,
	ForumID int NOT NULL 
)
GO
ALTER TABLE ForumNewTopicSubscriptions ADD 
	PRIMARY KEY 
	(
		UserID,
		ForumID
	)