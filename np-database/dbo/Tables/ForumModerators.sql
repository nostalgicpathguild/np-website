CREATE TABLE ForumModerators (
	UserID int NOT NULL ,
	ForumID int NOT NULL 
)
GO
ALTER TABLE ForumModerators ADD 
	PRIMARY KEY 
	(
		UserID,
		ForumID
	)