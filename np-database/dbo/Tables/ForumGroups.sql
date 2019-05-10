CREATE TABLE ForumGroups (
	GroupID int IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	GroupName nvarchar (50) NOT NULL,
	OrderByNumber int NOT NULL DEFAULT 0
)