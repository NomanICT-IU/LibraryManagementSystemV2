CREATE   PROCEDURE [Security].[DeleteRolePermission]
    @RolePermissionId INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [Security].[RolePermission]
    WHERE [RolePermissionId] = @RolePermissionId;
END;