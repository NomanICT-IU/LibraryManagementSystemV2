
CREATE PROCEDURE [dbo].[GetMemberDetails]
    @SearchBy NVARCHAR(50) = NULL,
    @SearchText NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @MemberId INT;
    DECLARE @CurrentDateTime DATETIME = GETDATE();

    -- Clean input
    SET @SearchBy = LTRIM(RTRIM(ISNULL(@SearchBy, '')));
    SET @SearchText = LTRIM(RTRIM(ISNULL(@SearchText, '')));

 

    SELECT TOP (1)
        @MemberId = m.MemberId
    FROM [dbo].[Member] AS m
    WHERE
        (
            @SearchBy = 'MemberCode'
            AND m.MemberCode = @SearchText
        )
        OR
        (
            @SearchBy = 'Phone'
            AND m.Phone = @SearchText
        )
        OR
        (
            @SearchBy = 'Name'
            AND m.Name = @SearchText
        );


   
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

        COALESCE(
            SUM(
                CASE
                    WHEN br.ReturnDate IS NULL THEN 1
                    ELSE 0
                END
            ),
            0
        ) AS CurrentlyBorrowed,

        COALESCE(
            SUM(
                CASE
                    WHEN br.ReturnDate IS NULL
                         AND br.DueDate < @CurrentDateTime
                    THEN 1
                    ELSE 0
                END
            ),
            0
        ) AS OverdueBooks,

        MAX(br.IssueDate) AS LastBorrowed

    FROM [dbo].[BorrowRecord] AS br
    WHERE br.MemberId = @MemberId;


    /* =========================================================
       5. Currently Borrowed Books
       ========================================================= */

    SELECT TOP (5)
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

    ORDER BY br.IssueDate asc;


    SELECT TOP (5)
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