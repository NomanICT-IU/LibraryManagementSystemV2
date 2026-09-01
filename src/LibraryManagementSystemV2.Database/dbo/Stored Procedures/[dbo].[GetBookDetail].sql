CREATE    PROCEDURE [dbo].[[dbo]].[GetBookDetail]]]
    @SearchBy     NVARCHAR(20),
    @SearchText NVARCHAR(100)
AS
BEGIN

  
    SELECT
    b.BookId,
        b.Title,
        b.Author,
        b.ISBN,
        b.Category
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


    SELECT
  bc.BookId,
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

    FROM [dbo].[BookCopy] as bc
    join [dbo].[Book] as b
     on bc.BookId = b.BookId
  WHERE
        (@SearchBy = 'Title'
            AND b.Title LIKE '%' + @SearchText + '%')
        OR
        (@SearchBy = 'Author'
            AND b.Author LIKE '%' + @SearchText + '%')
        OR
        (@SearchBy = 'ISBN'
            AND b.ISBN LIKE '%' + @SearchText + '%')
GROUP BY
    bc.BookId

ORDER BY
    bc.BookId;


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

    FROM [dbo].[BookCopy] AS bc
    join [dbo].[Book] as b
     on bc.BookId = b.BookId

    LEFT JOIN [dbo].[BorrowRecord] AS br
        ON bc.CopyId = br.CopyId

    LEFT JOIN [dbo].[Member] AS m
        ON br.MemberId = m.MemberId

     WHERE
        (@SearchBy = 'Title'
            AND b.Title LIKE '%' + @SearchText + '%')
        OR
        (@SearchBy = 'Author'
            AND b.Author LIKE '%' + @SearchText + '%')
        OR
        (@SearchBy = 'ISBN'
            AND b.ISBN LIKE '%' + @SearchText + '%')


    ORDER BY bc.CopyCode;

END;