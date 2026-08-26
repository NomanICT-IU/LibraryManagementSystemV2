CREATE   PROCEDURE [dbo].[CreateBorrowRecord]
    @CopyId     INT,
    @MemberId   INT,
    @IssueDate  DATETIME,
    @DueDate    DATETIME,
    @ReturnDate DATETIME = NULL
AS
BEGIN

    INSERT INTO [dbo].[BorrowRecord]
    (
        [CopyId],
        [MemberId],
        [IssueDate],
        [DueDate],
        [ReturnDate]
    )
    OUTPUT INSERTED.*
    VALUES
    (
        @CopyId,
        @MemberId,
        @IssueDate,
        @DueDate,
        @ReturnDate
    );
END;
