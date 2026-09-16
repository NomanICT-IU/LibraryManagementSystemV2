CREATE   PROCEDURE [Security].[GetUserById]
    @UserId INT
AS
BEGIN
    SELECT
        [UserId],
        [UserName],
        [Email],
        [PasswordHash],
        [FullName],
        [IsActive],
        [CreatedAt],
        [UpdateAT]
    FROM [Security].[Users]
    WHERE [UserId] = @UserId;
END;