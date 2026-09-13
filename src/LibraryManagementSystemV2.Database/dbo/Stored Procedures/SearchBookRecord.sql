
CREATE PROCEDURE [dbo].[SearchBookRecord]
    @SearchBy     NVARCHAR(20) = '',
    @SearchText   NVARCHAR(100) = '',
    @PageNumber   INT = 1,
    @PageSize     INT = 10
AS
BEGIN

    SET NOCOUNT ON;

    CREATE TABLE #SearchBookResult
    (
        CopyId      INT,
        BookId      INT,
        Title       NVARCHAR(500),
        Author      NVARCHAR(500),
        ISBN        NVARCHAR(100),
        CopyCode    NVARCHAR(100),
        Status      NVARCHAR(20),
        BorrowedBy  NVARCHAR(200),
        DueDate     DATETIME NULL
    );

    INSERT INTO #SearchBookResult
    (
        CopyId,
        BookId,
        Title,
        Author,
        ISBN,
        CopyCode,
        Status,
        BorrowedBy,
        DueDate
    )
    SELECT
        bc.CopyId,
        bc.BookId,
        b.Title,
        b.Author,
        b.ISBN,
        bc.CopyCode,

        CASE
            WHEN bc.Status = 1 THEN 'Available'
            WHEN bc.Status = 2 THEN 'Borrowed'
            ELSE 'Unknown'
        END AS Status,

        CASE
            WHEN bc.Status = 2 THEN m.Name
            ELSE NULL
        END AS BorrowedBy,

        CASE
            WHEN bc.Status = 2 THEN br.DueDate
            ELSE NULL
        END AS DueDate

    FROM [dbo].[Book] AS b

    INNER JOIN [dbo].[BookCopy] AS bc
        ON b.BookId = bc.BookId

    LEFT JOIN [dbo].[BorrowRecord] AS br
        ON bc.CopyId = br.CopyId
        AND br.ReturnDate IS NULL

    LEFT JOIN [dbo].[Member] AS m
        ON br.MemberId = m.MemberId

    WHERE
        (
            ISNULL(@SearchBy, '') = ''
            OR ISNULL(@SearchText, '') = ''

            OR
            (
                @SearchBy = 'Title'
                AND b.Title LIKE '%' + @SearchText + '%'
            )

            OR
            (
                @SearchBy = 'Author'
                AND b.Author LIKE '%' + @SearchText + '%'
            )

            OR
            (
                @SearchBy = 'ISBN'
                AND b.ISBN LIKE '%' + @SearchText + '%'
            )
        );

    SELECT COUNT(*) AS TotalRecords
    FROM #SearchBookResult;

    SELECT
        CopyId,
        BookId,
        Title,
        Author,
        ISBN,
        CopyCode,
        Status,
        BorrowedBy,
        DueDate
    FROM #SearchBookResult

    ORDER BY BookId DESC

    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

    DROP TABLE #SearchBookResult;

END;