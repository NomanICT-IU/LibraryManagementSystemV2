
CREATE   PROCEDURE [Security].[UpdateRole]
    @RoleId INT,
    @RoleName NVARCHAR(255),
    @RoleCode Nvarchar(20),
    @Description NVARCHAR(255) = NULL,
    @IsActive BIT
AS
BEGIN

    UPDATE [Security].[Roles]
    SET
        [RoleName] = @RoleName,
        [RoleCode]=@RoleCode,
        [Description] = @Description,
        [IsActive] = @IsActive,
        [UpdatedAt] = GETDATE()
    WHERE [RoleId] = @RoleId;
END;