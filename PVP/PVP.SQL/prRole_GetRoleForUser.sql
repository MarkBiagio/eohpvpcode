CREATE PROCEDURE [dbo].[prRole_GetRoleForUser]
	@UserId int = 0
AS
	SELECT r.RoleId,
			r.Description
	  FROM tbRole r
		INNER JOIN tbUserRole ur
			ON r.RoleId = ur.RoleId
	 WHERE ur.UserId = @UserId

RETURN 0
