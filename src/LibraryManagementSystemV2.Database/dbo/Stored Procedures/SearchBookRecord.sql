CREATE   PROCEDURE [dbo].[SearchBookRecord]
    @SearchBy NVARCHAR(20),
    @SearchResult NVARCHAR(100)
AS
BEGIN


    SELECT 
        b.BookId,
        b.Title,
        b.Author,
        b.ISBN,
        bc.CopyCode,
        CASE
            WHEN bc.Status = 1 THEN 'Available'
            WHEN bc.Status = 2 THEN 'Borrowed'
            ELSE 'Unknown'
        END AS Status,
        m.Name,
        br.DueDate
    FROM [dbo].[Book] AS b
    INNER JOIN [dbo].[BookCopy] AS bc
        ON b.BookId = bc.BookId
    LEFT JOIN [dbo].[BorrowRecord] AS br
        ON bc.CopyId = br.CopyId
    LEFT JOIN [dbo].[Member] AS m
        ON m.MemberId = br.MemberId
    WHERE
        (@SearchBy = 'Title' 
            AND b.Title LIKE '%' + @SearchResult + '%')
        OR
        (@SearchBy = 'Author' 
            AND b.Author LIKE '%' + @SearchResult + '%')
        OR
        (@SearchBy = 'ISBN' 
            AND b.ISBN LIKE '%' + @SearchResult + '%');
END;
