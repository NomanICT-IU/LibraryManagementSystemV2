CREATE   PROCEDURE [Security].[DeleteRole]
    @RoleId INT
AS
BEGIN
    DELETE FROM [Security].[Roles]
    WHERE [RoleId] = @RoleId;
END;