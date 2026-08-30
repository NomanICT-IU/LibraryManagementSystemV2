CREATE   PROCEDURE [dbo].[GetBookCopyDetails]
    @BookId INT
AS
BEGIN

    SELECT 
        bc.CopyId,
        b.Title,
        b.Author,
        b.ISBN,
        bc.CopyCode,
        CASE
            WHEN bc.Status = 1 THEN 'Available'
            WHEN bc.Status = 2 THEN 'Borrowed'
            ELSE 'Unknown'
        END AS Status
    FROM [dbo].[Book] AS b
    INNER JOIN [dbo].[BookCopy] AS bc
        ON b.BookId = bc.BookId
    WHERE b.BookId = @BookId and bc.Status = 1;
END;
