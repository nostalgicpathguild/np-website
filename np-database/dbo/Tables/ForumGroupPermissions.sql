CREATE TABLE ForumGroupPermissions (
	ForumID int NOT NULL ,
	GroupID int NOT NULL ,
	AllowReading bit NOT NULL ,
	AllowPosting bit NOT NULL
)
GO
ALTER TABLE ForumGroupPermissions ADD 
	PRIMARY KEY 
	(
		ForumID,
		GroupID
	)