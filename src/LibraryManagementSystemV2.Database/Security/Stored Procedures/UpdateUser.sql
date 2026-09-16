CREATE   PROCEDURE [Security].[UpdateUser]
    @UserId INT,
    @UserName NVARCHAR(100),
    @Email NVARCHAR(255),
    @PasswordHash NVARCHAR(500),
    @FullName NVARCHAR(100),
    @IsActive BIT
AS
BEGIN


    UPDATE [Security].[Users]
    SET
        [UserName] = @UserName,
        [Email] = @Email,
        [PasswordHash] = @PasswordHash,
        [FullName] = @FullName,
        [IsActive] = @IsActive,
        [UpdateAT] = GETDATE()
    WHERE [UserId] = @UserId;
END;