CREATE TABLE ForumAchievements (
	AchievementID int NOT NULL,
	UserID int NOT NULL ,
	DateCreated DateTime NOT NULL,
	TimesAchieved int NOT NULL
)
GO
/*adding complex keys*/

ALTER TABLE ForumAchievements ADD 
	PRIMARY KEY 
	(
		AchievementID,
		UserID
	)