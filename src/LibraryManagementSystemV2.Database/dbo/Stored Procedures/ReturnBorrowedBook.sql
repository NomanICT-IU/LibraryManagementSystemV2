CREATE   PROCEDURE [dbo].[ReturnBorrowedBook]
    @BorrowId INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRANSACTION;

    DECLARE @CopyId INT;


    SELECT 
        @CopyId = CopyId
    FROM [dbo].[BorrowRecord]
    WHERE BorrowId = @BorrowId
      AND ReturnDate IS NULL;



    UPDATE [dbo].[BookCopy]
    SET Status = 1
    WHERE CopyId = @CopyId;


    UPDATE [dbo].[BorrowRecord]
    SET ReturnDate = GETDATE()
    WHERE BorrowId = @BorrowId
      AND ReturnDate IS NULL;


    SELECT
        b.Title,
        bc.CopyCode,
        m.Name,
        br.ReturnDate,
        CASE
            WHEN bc.Status = 1 THEN 'Available'
            WHEN bc.Status = 2 THEN 'Borrowed'
            ELSE 'Unknown'
        END AS Status
    FROM [dbo].[BorrowRecord] AS br
    INNER JOIN [dbo].[BookCopy] AS bc
        ON br.CopyId = bc.CopyId
    INNER JOIN [dbo].[Book] AS b
        ON bc.BookId = b.BookId
    INNER JOIN [dbo].[Member] AS m
        ON br.MemberId = m.MemberId
    WHERE br.BorrowId = @BorrowId;

    COMMIT TRANSACTION;
END;
