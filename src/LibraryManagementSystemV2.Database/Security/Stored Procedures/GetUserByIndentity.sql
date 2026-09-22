Create     PROCEDURE [Security].[GetUserByIndentity]
    @Indentity nvarchar(100)
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
    FROM [Security].[Users] as u
    WHERE u.UserName = @Indentity
         or u.Email = @Indentity;
END;