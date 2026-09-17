
CREATE   PROCEDURE [Security].[GetRoleById]
    @RoleId INT
AS
BEGIN
    SELECT
        [RoleId],
        [RoleName],
        [RoleCode],
        [Description],
        [IsActive],
        [CreatedAt],
        [UpdatedAt]
    FROM [Security].[Roles]
    WHERE [RoleId] = @RoleId;
END;