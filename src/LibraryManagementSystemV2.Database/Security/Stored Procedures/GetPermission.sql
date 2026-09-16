CREATE   PROCEDURE [Security].[GetPermission]
   
AS
BEGIN
    SELECT
        [PermissionName],
        [PermissionCode],
[Description],
[IsActive],
[CreatedAt],
[UpdatedAt]
    FROM [Security].[Permissions]
END;