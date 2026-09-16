CREATE   PROCEDURE [Security].[CreateUserRole]
    @UserId INT,
    @RoleId INT,
    @AssignedAt DATETIME
AS
BEGIN
    INSERT INTO [Security].[UserRole]
    (
        [UserId],
        [RoleId],
        [AssignedAt]
    )
    VALUES
    (
        @UserId,
        @RoleId,
        @AssignedAt
    );
END;