CREATE TABLE ForumPollOptions (
	OptionID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	PollID int NOT NULL,
	OptionText nvarchar(255) NOT NULL
)