CREATE   PROCEDURE [Security].[DeleteUserRole]
    @UserRoleId INT
AS
BEGIN
    DELETE FROM [Security].[UserRole]
    WHERE [UserRoleId] = @UserRoleId;
END;