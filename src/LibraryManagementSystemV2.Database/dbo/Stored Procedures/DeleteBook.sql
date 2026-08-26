CREATE   PROCEDURE [dbo].[DeleteBook]
    @BookId INT
AS
BEGIN

    DELETE FROM [dbo].[Book]
    WHERE [BookId] = @BookId;
END;
