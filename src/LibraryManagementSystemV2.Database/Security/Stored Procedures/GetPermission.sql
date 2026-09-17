
CREATE   PROCEDURE [Security].[GetPermission]
   @searchText nvarchar(100) = null
AS
BEGIN
    SELECT
[PermissionName],
[PermissionCode],
[Description],
[IsActive]
    FROM [Security].[Permissions]
END;