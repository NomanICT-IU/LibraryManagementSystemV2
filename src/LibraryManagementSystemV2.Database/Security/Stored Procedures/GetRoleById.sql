CREATE   PROCEDURE [Security].[GetRoleById]
    @RoleId INT
AS
BEGIN
    SELECT
        [RoleId],
        [RoleName],
        [Description],
        [IsActive],
        [CreatedAt],
        [UpdatedAt]
    FROM [Security].[Roles]
    WHERE [RoleId] = @RoleId;
END;