CREATE   PROCEDURE [dbo].[SearchBookRecord]
    @SearchBy     NVARCHAR(20),
    @SearchText NVARCHAR(100)
AS
BEGIN


    DECLARE @BookId INT;

    -- ==========================================
    -- 1. Find Book
    -- ==========================================
    SELECT TOP (1)
        @BookId = b.BookId
    FROM [dbo].[Book] AS b
    WHERE
        (@SearchBy = 'Title'
            AND b.Title LIKE '%' + @SearchText + '%')
        OR
        (@SearchBy = 'Author'
            AND b.Author LIKE '%' + @SearchText + '%')
        OR
        (@SearchBy = 'ISBN'
            AND b.ISBN LIKE '%' + @SearchText + '%');


    -- Book not found
    IF @BookId IS NULL
    BEGIN
        RETURN;
    END;


    -- ==========================================
    -- 2. Book Copy Details
    -- ==========================================
    SELECT
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

    LEFT JOIN [dbo].[Member] AS m
        ON br.MemberId = m.MemberId

    WHERE b.BookId = @BookId;


    -- ==========================================
    -- 3. Book Information
    -- ==========================================
    SELECT
        b.Title,
        b.Author,
        b.ISBN,
        b.Category
    FROM [dbo].[Book] AS b
    WHERE b.BookId = @BookId;


    -- ==========================================
    -- 4. Book Copy Summary
    -- ==========================================
    SELECT
        COUNT(*) AS Total,

        COUNT(
            CASE
                WHEN Status = 1 THEN 1
            END
        ) AS Available,

        COUNT(
            CASE
                WHEN Status = 2 THEN 1
            END
        ) AS Borrowed,

        CASE
            WHEN COUNT(CASE WHEN Status = 1 THEN 1 END) > 0
                THEN 'Available'

            WHEN COUNT(CASE WHEN Status = 2 THEN 1 END) > 0
                THEN 'Borrowed'

            ELSE 'Unknown'
        END AS Status

    FROM [dbo].[BookCopy]
    WHERE BookId = @BookId;


    -- ==========================================
    -- 5. Book Copy Status Details
    -- ==========================================
    SELECT
        @BookId as BookId,
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

    FROM [dbo].[BookCopy] AS bc

    LEFT JOIN [dbo].[BorrowRecord] AS br
        ON bc.CopyId = br.CopyId

    LEFT JOIN [dbo].[Member] AS m
        ON br.MemberId = m.MemberId

    WHERE bc.BookId = @BookId

    ORDER BY bc.CopyCode;

END;