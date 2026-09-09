CREATE   PROCEDURE [dbo].[CreateBorrowRecord]
    @CopyId     INT,
    @MemberId   INT,
    @IssueDate  DATETIME,
    @DueDate    DATETIME,
    @ReturnDate DATETIME = NULL
AS
BEGIN

    -- Create Borrow Record
    INSERT INTO [dbo].[BorrowRecord]
    (
        CopyId,
        MemberId,
        IssueDate,
        DueDate,
        ReturnDate
    )
    VALUES
    (
        @CopyId,
        @MemberId,
        @IssueDate,
        @DueDate,
        @ReturnDate
    );

    UPDATE [dbo].[BookCopy]
    SET Status = 2
    WHERE CopyId = @CopyId
      AND Status = 1;
 
END;