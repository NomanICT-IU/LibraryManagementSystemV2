CREATE   PROCEDURE [Security].[GetUserRoleById]
    @UserRoleId INT
AS
BEGIN
    SELECT
        [UserRoleId],
        [UserId],
        [RoleId],
        [AssignedAt]
    FROM [Security].[UserRole]
    WHERE [UserRoleId] = @UserRoleId;
END;