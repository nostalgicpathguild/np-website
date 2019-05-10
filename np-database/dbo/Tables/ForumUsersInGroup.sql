CREATE TABLE ForumUsersInGroup (
	GroupID int NOT NULL ,
	UserID int NOT NULL
)
GO
ALTER TABLE ForumUsersInGroup ADD 
	PRIMARY KEY 
	(
		UserID,
		GroupID
	)