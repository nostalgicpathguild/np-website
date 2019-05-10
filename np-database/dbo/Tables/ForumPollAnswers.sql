CREATE TABLE ForumPollAnswers (
	UserID int NOT NULL,
	OptionID int NOT NULL
)
GO
ALTER TABLE ForumPollAnswers ADD 
	PRIMARY KEY 
	(
		UserID,
		OptionID
	)