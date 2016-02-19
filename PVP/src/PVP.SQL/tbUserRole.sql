CREATE TABLE [dbo].[tbUserRole]
(
	[UserRoleId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[UserId] INT NOT NULL,
	[RoleId] INT NOT NULL, 
    CONSTRAINT [FK_tbUserRole_TotbUser] FOREIGN KEY ([UserId]) REFERENCES [tbUser]([UserId]),
	CONSTRAINT [FK_tbUserRole_TotbRole] FOREIGN KEY ([RoleId]) REFERENCES [tbRole]([RoleId]), 
    CONSTRAINT [UQ_tbUserRole_UserId_RoleId] UNIQUE ([UserId],[RoleId])
)
