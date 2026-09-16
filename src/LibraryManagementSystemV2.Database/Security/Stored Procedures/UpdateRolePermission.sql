CREATE   PROCEDURE [Security].[UpdateRolePermission]
    @RolePermissionId INT,
    @RoleId INT,
    @PermissionId INT,
    @AssignedAt DATETIME
AS
BEGIN
   
    UPDATE [Security].[RolePermission]
    SET
        [RoleId] = @RoleId,
        [PermissionId] = @PermissionId,
        [AssignedAt] = @AssignedAt
    WHERE [RolePermissionId] = @RolePermissionId;
END;