CREATE   PROCEDURE [Security].[GetRolePermissions]
    @RoleName NVARCHAR(255)
AS
BEGIN
   
    DECLARE @RoleId INT;

    SELECT @RoleId = r.RoleId
    FROM [Security].[Roles] AS r
    WHERE r.RoleName = @RoleName;

    SELECT
        p.PermissionId,
        p.PermissionName,
        CAST(
            CASE
                WHEN rp.AssignedAt IS NOT NULL THEN 1
                ELSE 0
            END AS BIT
        ) AS IsAssigned
    FROM [Security].[Permissions] AS p
    LEFT JOIN [Security].[RolePermission] AS rp
        ON rp.PermissionId = p.PermissionId
        AND rp.RoleId = @RoleId
    ORDER BY p.PermissionId;
END;