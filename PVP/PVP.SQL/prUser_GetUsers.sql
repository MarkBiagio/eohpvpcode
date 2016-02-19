CREATE PROCEDURE [dbo].[prUser_GetUsers]
	
AS
	SELECT UserId,
			LoginName,
			Name,
			IsActive
		FROM tbUser

	RETURN 0
