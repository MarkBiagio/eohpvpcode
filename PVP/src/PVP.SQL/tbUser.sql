﻿CREATE TABLE [dbo].[tbUser]
(
	[UserId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[LoginName] VARCHAR(20) NOT NULL,
	[Name] VARCHAR(250) NOT NULL,
	[IsActive] bit NOT NULL
)