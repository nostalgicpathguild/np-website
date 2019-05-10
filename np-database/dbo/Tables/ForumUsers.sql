﻿CREATE TABLE ForumUsers (
	UserID int IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	UserName nvarchar (50) NOT NULL ,
	FirstName nvarchar(100) NULL,
	LastName nvarchar(100) NULL,
	Email nvarchar (50) NOT NULL ,
	[Password] nvarchar (MAX) NOT NULL ,
	Homepage nvarchar (255) NULL ,
	Interests nvarchar (255) NULL ,
	PostsCount int NOT NULL DEFAULT 0,
	RegistrationDate datetime NOT NULL DEFAULT getdate(),
	[Disabled] bit NOT NULL DEFAULT 0,
	ActivationCode nvarchar(50) NOT NULL DEFAULT '',
	AvatarFileName nvarchar(255) NULL,
	Signature nvarchar(1000) NULL,
	LastLogonDate datetime NULL,
	ReputationCache int NOT NULL DEFAULT 0,
	OpenIdUserName nvarchar(255) NULL,
	HidePresence bit NOT NULL DEFAULT 0,
	UseGravatar bit NOT NULL DEFAULT 1,
	TwitterUserName varchar(255) NULL,
	FacebookID varchar(255) NULL
)