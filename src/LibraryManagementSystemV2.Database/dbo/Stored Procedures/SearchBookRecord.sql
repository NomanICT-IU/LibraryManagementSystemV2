CREATE   PROCEDURE [dbo].[SearchBookRecord]
    @SearchBy     NVARCHAR(20),
    @SearchText NVARCHAR(100)
AS
BEGIN

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

    JOIN [dbo].[BookCopy] AS bc
        ON b.BookId = bc.BookId

    LEFT JOIN [dbo].[BorrowRecord] AS br
        ON bc.CopyId = br.CopyId

    LEFT JOIN [dbo].[Member] AS m
        ON br.MemberId = m.MemberId

    WHERE
        (
        ISNULL(@SearchBy, '') = ''
        OR ISNULL(@SearchText, '') = ''
        ) OR
        (@SearchBy = 'Title'
            AND b.Title LIKE '%' + @SearchText + '%' )
        OR
        (@SearchBy = 'Author'
            AND b.Author LIKE '%' + @SearchText + '%')
        OR
        (@SearchBy = 'ISBN'
            AND b.ISBN LIKE '%' + @SearchText + '%')
       order by   b.BookId desc

END;