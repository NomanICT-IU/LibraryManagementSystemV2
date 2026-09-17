
CREATE   PROCEDURE [Security].[CreateRole]
    @RoleName NVARCHAR(255),
    @RoleCode Nvarchar(20),
    @Description NVARCHAR(255) = NULL,
    @IsActive BIT,
    @CreatedAt DATETIME,
    @UpdatedAt DATETIME = NULL
AS
BEGIN
    INSERT INTO [Security].[Roles]
    (
        [RoleName],
        [RoleCode],
        [Description],
        [IsActive],
        [CreatedAt],
        [UpdatedAt]
    )
    VALUES
    (
        @RoleName,
        @RoleCode,
        @Description,
        @IsActive,
        @CreatedAt,
        @UpdatedAt
    );
END;