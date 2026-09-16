CREATE   PROCEDURE [Security].[UpdateUserRole]
    @UserRoleId INT,
    @UserId INT,
    @RoleId INT
AS
BEGIN

    UPDATE [Security].[UserRole]
    SET
        [UserId] = @UserId,
        [RoleId] = @RoleId,
        [AssignedAt] = GETDATE()
    WHERE [UserRoleId] = @UserRoleId;
END;