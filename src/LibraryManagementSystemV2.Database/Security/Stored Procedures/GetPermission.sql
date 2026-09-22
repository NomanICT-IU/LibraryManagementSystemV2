
CREATE   PROCEDURE [Security].[GetPermission]
    @RoleId INT
AS
BEGIN
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