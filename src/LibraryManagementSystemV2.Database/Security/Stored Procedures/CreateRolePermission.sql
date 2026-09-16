CREATE   PROCEDURE [Security].[CreateRolePermission]
    @RoleId INT,
    @PermissionId INT,
    @AssignedAt DATETIME
AS
BEGIN
  
    INSERT INTO [Security].[RolePermission]
    (
        [RoleId],
        [PermissionId],
        [AssignedAt]
    )
    VALUES
    (
        @RoleId,
        @PermissionId,
        @AssignedAt
    );
END;