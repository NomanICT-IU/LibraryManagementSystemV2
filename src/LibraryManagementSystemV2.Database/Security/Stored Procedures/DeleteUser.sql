CREATE   PROCEDURE [Security].[DeleteUser]
    @UserId INT
AS
BEGIN


    DELETE FROM [Security].[Users]
    WHERE [UserId] = @UserId;
END;