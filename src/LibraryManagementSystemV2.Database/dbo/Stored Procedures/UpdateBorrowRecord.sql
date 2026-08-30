CREATE   PROCEDURE [dbo].[UpdateBorrowRecord]
    @BorrowId   INT,
    @CopyId     INT,
    @MemberId   INT,
    @IssueDate  DATETIME,
    @DueDate    DATETIME,
    @ReturnDate DATETIME = NULL
AS
BEGIN
DECLARE @OldCopyId INT;
BEGIN TRANSACTION;

      
        SELECT @OldCopyId = CopyId
        FROM [dbo].[BorrowRecord]
        WHERE BorrowId = @BorrowId;

      
        UPDATE [dbo].[BookCopy]
        SET Status = 1
        WHERE CopyId = @OldCopyId;

     
        UPDATE [dbo].[BorrowRecord]
        SET
            CopyId = @CopyId,
            MemberId = @MemberId,
            IssueDate = @IssueDate,
            DueDate = @DueDate,
            ReturnDate = @ReturnDate
        WHERE BorrowId = @BorrowId;

     
        UPDATE [dbo].[BookCopy]
        SET Status = 2
        WHERE CopyId = @CopyId;

        COMMIT TRANSACTION;
END;