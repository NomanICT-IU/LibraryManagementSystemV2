CREATE   PROCEDURE [Security].[CreateRoles]
    @RoleName NVARCHAR(255),
    @Description NVARCHAR(255) = NULL,
    @IsActive BIT,
    @CreatedAt DATETIME,
    @UpdatedAt DATETIME = NULL
AS
BEGIN
    INSERT INTO [Security].[Roles]
    (
        [RoleName],
        [Description],
        [IsActive],
        [CreatedAt],
        [UpdatedAt]
    )
    VALUES
    (
        @RoleName,
        @Description,
        @IsActive,
        @CreatedAt,
        @UpdatedAt
    );
END;