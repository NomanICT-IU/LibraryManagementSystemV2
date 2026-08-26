CREATE   PROCEDURE [dbo].[UpdateBorrowRecord]
    @BorrowId   INT,
    @CopyId     INT,
    @MemberId   INT,
    @IssueDate  DATETIME,
    @DueDate    DATETIME,
    @ReturnDate DATETIME = NULL
AS
BEGIN


    UPDATE [dbo].[BorrowRecord]
    SET
        [CopyId]     = @CopyId,
        [MemberId]   = @MemberId,
        [IssueDate]  = @IssueDate,
        [DueDate]    = @DueDate,
        [ReturnDate] = @ReturnDate

    WHERE [BorrowId] = @BorrowId;
END;
