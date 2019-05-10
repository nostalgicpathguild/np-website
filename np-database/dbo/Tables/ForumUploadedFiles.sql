CREATE TABLE ForumUploadedFiles (
	FileID int IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	FileName nvarchar (255)  NOT NULL ,
	MessageID int NOT NULL ,
	UserID int NOT NULL 
)