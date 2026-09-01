CREATE   PROCEDURE dbo.GetBookDetails
    @SearchBy   NVARCHAR(20),
    @SearchText NVARCHAR(100)
AS
BEGIN
    

    -- 1. Store searched books in temp table
    SELECT
        b.BookId,
        b.Title,
        b.Author,
        b.ISBN,
        b.Category
    INTO #TempBooks
    FROM dbo.Book AS b
    WHERE
        (@SearchBy = 'Title'
            AND b.Title LIKE '%' + @SearchText + '%')
        OR
        (@SearchBy = 'Author'
            AND b.Author LIKE '%' + @SearchText + '%')
        OR
        (@SearchBy = 'ISBN'
            AND b.ISBN LIKE '%' + @SearchText + '%');


    -- 2. Book details
    SELECT
        BookId,
        Title,
        Author,
        ISBN,
        Category
    FROM #TempBooks;


    -- 3. Book copy summary
    SELECT
        bc.BookId,
        COUNT(*) AS Total,

        COUNT(CASE
            WHEN bc.Status = 1 THEN 1
        END) AS Available,

        COUNT(CASE
            WHEN bc.Status = 2 THEN 1
        END) AS Borrowed,

        CASE
            WHEN COUNT(CASE WHEN bc.Status = 1 THEN 1 END) > 0
                THEN 'Available'

            WHEN COUNT(CASE WHEN bc.Status = 2 THEN 1 END) > 0
                THEN 'Borrowed'

            ELSE 'Unknown'
        END AS Status

    FROM dbo.BookCopy AS bc
    INNER JOIN #TempBooks AS tb
        ON bc.BookId = tb.BookId

    GROUP BY bc.BookId

    ORDER BY bc.BookId;


    -- 4. Individual book copies
    SELECT
        bc.BookId,
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

    FROM dbo.BookCopy AS bc

    INNER JOIN #TempBooks AS tb
        ON bc.BookId = tb.BookId

    LEFT JOIN dbo.BorrowRecord AS br
        ON bc.CopyId = br.CopyId

    LEFT JOIN dbo.Member AS m
        ON br.MemberId = m.MemberId

    ORDER BY bc.CopyCode;

END;