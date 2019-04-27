CREATE TABLE ForumPolls (
	PollID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	TopicID int NOT NULL,
	Question nvarchar(255) NOT NULL
)