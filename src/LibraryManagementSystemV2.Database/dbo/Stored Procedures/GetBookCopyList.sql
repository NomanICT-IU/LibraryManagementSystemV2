CREATE   PROCEDURE [dbo].[GetBookCopyList]
    @BookId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
    b.BookId,
        bc.CopyId,
        bc.CopyCode,
        b.Title,
        bc.Status
    FROM dbo.BookCopy AS bc
    INNER JOIN dbo.Book AS b
        ON b.BookId = bc.BookId
    WHERE bc.BookId = @BookId
    ORDER BY bc.CopyId DESC;
END;