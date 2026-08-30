CREATE   PROCEDURE [dbo].[GetMemberDetails]
    @SearchBy   NVARCHAR(50),
    @SearchText NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @MemberId INT;
    DECLARE @CurrentDateTime DATETIME = GETDATE();

    
    SELECT TOP (1)
        @MemberId = MemberId
    FROM [dbo].[Member]
    WHERE
        (@SearchBy = 'MemberCode' AND MemberCode = @SearchText)
        OR
        (@SearchBy = 'Phone' AND Phone = @SearchText)
        OR
        (@SearchBy = 'Name' AND Name = @SearchText);
    
    IF @MemberId IS NULL
    BEGIN
        RETURN;
    END;

    SELECT
        m.MemberId,
        m.Name,
        m.MemberCode,
        m.Phone,
        m.Email,
        m.Address,
        CASE
            WHEN m.Status = 1 THEN 'Active'
            WHEN m.Status = 0 THEN 'Inactive'
            ELSE 'Unknown'
        END AS Status
    FROM [dbo].[Member] AS m
    WHERE m.MemberId = @MemberId;

    SELECT
        COUNT(br.BorrowId) AS TotalBorrowed,

        SUM(
            CASE
                WHEN br.ReturnDate IS NULL THEN 1
                ELSE 0
            END
        ) AS CurrentlyBorrowed,

        SUM(
            CASE
                WHEN br.ReturnDate IS Not NULL
                     AND br.DueDate < @CurrentDateTime
                THEN 1
                ELSE 0
            END
        ) AS OverdueBooks,

        MAX(br.IssueDate) AS LastBorrowed
    FROM [dbo].[BorrowRecord] AS br
    WHERE br.MemberId = @MemberId;

    SELECT 
        br.BorrowId,
        b.BookId,
        b.Title,
        bc.CopyCode,
        br.IssueDate,
        br.DueDate
    FROM [dbo].[BorrowRecord] AS br
    INNER JOIN [dbo].[BookCopy] AS bc
        ON br.CopyId = bc.CopyId
    INNER JOIN [dbo].[Book] AS b
        ON bc.BookId = b.BookId
    WHERE br.MemberId = @MemberId
      AND br.ReturnDate IS NULL
    ORDER BY br.IssueDate DESC;

    SELECT Top (5)
        b.BookId,
        b.Title,
        bc.CopyCode,
        br.IssueDate,
        br.ReturnDate
    FROM [dbo].[BorrowRecord] AS br
    INNER JOIN [dbo].[BookCopy] AS bc
        ON br.CopyId = bc.CopyId
    INNER JOIN [dbo].[Book] AS b
        ON bc.BookId = b.BookId
    WHERE br.MemberId = @MemberId
      AND br.ReturnDate IS NOT NULL
    ORDER BY br.IssueDate DESC;
END;
