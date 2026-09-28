CREATE   PROCEDURE [Security].[GetRoleList]
AS
BEGIN
 

    SELECT
        RoleId,
        RoleName,
        RoleCode,
        Description,
        IsActive,
        CreatedAt
    FROM [Security].[Roles]
    ORDER BY RoleId;
END;