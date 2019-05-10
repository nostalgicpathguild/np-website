CREATE TABLE ForumMessageRating (
	MessageID int NOT NULL,
	VoterUserID int NOT NULL,
	Score int NOT NULL
)
GO
ALTER TABLE ForumMessageRating ADD 
	PRIMARY KEY 
	(
		MessageID,
		VoterUserID
	)