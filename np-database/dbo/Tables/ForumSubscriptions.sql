CREATE TABLE ForumSubscriptions (
	UserID int NOT NULL ,
	TopicID int NOT NULL 
)
GO
ALTER TABLE ForumSubscriptions ADD 
	PRIMARY KEY 
	(
		UserID,
		TopicID
	)