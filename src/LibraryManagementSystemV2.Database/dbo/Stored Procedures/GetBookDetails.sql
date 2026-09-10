
CREATE PROCEDURE [dbo].[GetBookDetails]
    @SearchBy   NVARCHAR(20) = NULL,
    @SearchText NVARCHAR(100) = NULL
AS
BEGIN
  

    -- Clean input
    SET @SearchBy = LTRIM(RTRIM(ISNULL(@SearchBy, '')));
    SET @SearchText = LTRIM(RTRIM(ISNULL(@SearchText, '')));


    SELECT
        b.BookId,
        b.Title,
        b.Author,
        b.ISBN,
        b.Category
    INTO #TempBooks
    FROM dbo.Book AS b
    WHERE
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
        );


   

    SELECT
        BookId,
        Title,
        Author,
        ISBN,
        Category
    FROM #TempBooks
    ORDER BY BookId;



    SELECT
        tb.BookId,

        COUNT(bc.CopyId) AS Total,

        COUNT(
            CASE
                WHEN bc.Status = 1 THEN 1
            END
        ) AS Available,

        COUNT(
            CASE
                WHEN bc.Status = 2 THEN 1
            END
        ) AS Borrowed,

        CASE
            WHEN COUNT(
                CASE
                    WHEN bc.Status = 1 THEN 1
                END
            ) > 0
                THEN 'Available'

            WHEN COUNT(
                CASE
                    WHEN bc.Status = 2 THEN 1
                END
            ) > 0
                THEN 'Borrowed'

            ELSE 'Unknown'
        END AS Status

    FROM #TempBooks AS tb

    LEFT JOIN dbo.BookCopy AS bc
        ON tb.BookId = bc.BookId

    GROUP BY
        tb.BookId

    ORDER BY
        tb.BookId;


 

    SELECT
        bc.BookId,
        bc.CopyId,
        b.Title,
        bc.CopyCode,

        CASE
            WHEN bc.Status = 1 THEN 'Available'
            WHEN bc.Status = 2 THEN 'Borrowed'
            ELSE 'Unknown'
        END AS Status,

        CASE
            WHEN bc.Status = 2
                THEN m.Name
            ELSE NULL
        END AS BorrowedBy,

        CASE
            WHEN bc.Status = 2
                THEN br.DueDate
            ELSE NULL
        END AS DueDate

    FROM #TempBooks AS tb

    INNER JOIN dbo.BookCopy AS bc
        ON tb.BookId = bc.BookId

    LEFT JOIN dbo.BorrowRecord AS br
        ON bc.CopyId = br.CopyId
        AND br.ReturnDate IS NULL

    LEFT JOIN dbo.Member AS m
        ON br.MemberId = m.MemberId
    join [dbo].[Book] as b
       on b.BookId = bc.BookId

    ORDER BY
        bc.BookId,
        bc.CopyCode;

END;