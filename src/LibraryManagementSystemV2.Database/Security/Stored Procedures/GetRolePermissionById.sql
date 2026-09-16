CREATE   PROCEDURE [Security].[GetRolePermissionById]
    @RolePermissionId INT
AS
BEGIN

    SELECT
        [RolePermissionId],
        [RoleId],
        [PermissionId],
        [AssignedAt]
    FROM [dbo].[RolePermission]
    WHERE [RolePermissionId] = @RolePermissionId;
END;