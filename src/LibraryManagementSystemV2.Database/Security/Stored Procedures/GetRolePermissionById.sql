CREATE   PROCEDURE [Security].[GetRolePermissionById]
    @RolePermissionId INT
AS
BEGIN

    SELECT
        [RolePermissionId],
        [RoleId],
        [PermissionId],
        [AssignedAt]
    FROM [Security].[RolePermission]
    WHERE [RolePermissionId] = @RolePermissionId;
END;