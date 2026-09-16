CREATE   PROCEDURE [Security].[CreateUsers]
    @UserName NVARCHAR(100),
    @Email NVARCHAR(255),
    @PasswordHash NVARCHAR(500),
    @FullName NVARCHAR(100),
    @IsActive BIT,
    @CreatedAt DATETIME,
    @UpdateAT DATETIME = NULL
AS
BEGIN
    INSERT INTO [Security].[Users]
    (
        [UserName],
        [Email],
        [PasswordHash],
        [FullName],
        [IsActive],
        [CreatedAt],
        [UpdateAT]
    )
    VALUES
    (
        @UserName,
        @Email,
        @PasswordHash,
        @FullName,
        @IsActive,
        @CreatedAt,
        @UpdateAT
    );
END;