CREATE   PROCEDURE [dbo].[GetBookById]
    @BookId INT
AS
BEGIN


    SELECT
        [BookId],
        [Title],
        [Author],
        [ISBN],
        [Category]
    FROM [dbo].[Book]
    WHERE [BookId] = @BookId;
END;
