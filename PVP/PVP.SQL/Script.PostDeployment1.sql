/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DELETE FROM tbUserRole;
DELETE FROM tbRole;
DELETE FROM tbUser;

INSERT INTO tbRole(Description) VALUES('User');
INSERT INTO tbRole(Description) VALUES('Administrator');

INSERT INTO tbUser(LoginName, Name, IsActive) VALUES('mark@eoh.co.za', 'mark', 1);
INSERT INTO tbUser(LoginName, Name, IsActive) VALUES('adriaan@eoh.co.za', 'adriaan', 1);
INSERT INTO tbUser(LoginName, Name, IsActive) VALUES('denzil@eoh.co.za', 'denzil', 1);
INSERT INTO tbUser(LoginName, Name, IsActive) VALUES('deon@eoh.co.za', 'deon', 0);

INSERT INTO tbUserRole(UserId, RoleId)
SELECT u.UserId, r.RoleId
	FROM tbUser u 
		CROSS JOIN tbRole r
  WHERE  u.LoginName IN ('mark@eoh.co.za', 'adriaan@eoh.co.za')


INSERT INTO tbUserRole(UserId, RoleId)
SELECT u.UserId, r.RoleId
	FROM tbUser u 
		CROSS JOIN tbRole r
  WHERE  u.LoginName IN ( 'deon@eoh.co.za', 'denzil@eoh.co.za') 
  AND r.Description ='User'


