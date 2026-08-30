CREATE   PROCEDURE [dbo].[CreateBorrowRecord]
    @CopyId     INT,
    @MemberId   INT,
    @IssueDate  DATETIME,
    @DueDate    DATETIME,
    @ReturnDate DATETIME = NULL
AS
BEGIN

    BEGIN TRANSACTION;

    -- Reserve Book Copy
    UPDATE [dbo].[BookCopy]
    SET Status = 2
    WHERE CopyId = @CopyId
      AND Status = 1;

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

    DECLARE @BorrowId INT = SCOPE_IDENTITY();

    -- Return Created Borrow Details
    SELECT
        br.BorrowId,
        b.Title,
        bc.CopyCode,
        m.Name,
        br.DueDate,
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
