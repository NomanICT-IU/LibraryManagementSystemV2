CREATE   PROCEDURE [dbo].[GetBookCopyById]
    @CopyId INT
AS
BEGIN
      SELECT
        bc.CopyId,
        bc.CopyCode,
        b.Title,
        bc.Status
    FROM dbo.BookCopy AS bc
    INNER JOIN dbo.Book AS b
        ON bc.BookId = b.BookId
    WHERE bc.CopyId = @CopyId;
END;