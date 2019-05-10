CREATE TABLE ForumSubforums(
	ParentForumID int NOT NULL,
	SubForumID int NOT NULL
)
GO
ALTER TABLE ForumSubforums ADD 
	PRIMARY KEY 
	(
		ParentForumID,
		SubForumID
	)