CREATE   PROCEDURE [dbo].[ReturnBorrowedBook]
    @BorrowId INT
AS
BEGIN
 

    

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
   
END;