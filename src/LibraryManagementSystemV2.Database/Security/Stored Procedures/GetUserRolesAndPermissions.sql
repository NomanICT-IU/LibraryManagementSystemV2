CREATE   PROCEDURE [Security].[GetUserRolesAndPermissions]
    @UserId INT
AS
BEGIN
   
    -- Get User Roles
    SELECT DISTINCT
        r.RoleName
    FROM [Security].[UserRole] AS ur
    INNER JOIN [Security].[Roles] AS r
        ON ur.RoleId = r.RoleId
    WHERE ur.UserId = @UserId;


    -- Get User Permissions
    SELECT DISTINCT
        p.PermissionName
    FROM [Security].[RolePermission] AS rp
    INNER JOIN [Security].[Permissions] AS p
        ON rp.PermissionId = p.PermissionId
    INNER JOIN [Security].[UserRole] AS ur
        ON rp.RoleId = ur.RoleId
    WHERE ur.UserId = @UserId;
END;