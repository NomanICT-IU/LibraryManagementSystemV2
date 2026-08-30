create    PROCEDURE [dbo].[SearchBorrowedBook]
    @SearchBy NVARCHAR(20),
    @SearchText NVARCHAR(100)
AS
BEGIN


    SELECT 
        br.BorrowId,
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
        m.MemberCode,
        m.Phone,
        m.Email,
        br.IssueDate,
        br.DueDate
    FROM [dbo].[Book] AS b
    INNER JOIN [dbo].[BookCopy] AS bc
        ON b.BookId = bc.BookId
    LEFT JOIN [dbo].[BorrowRecord] AS br
        ON bc.CopyId = br.CopyId
    LEFT JOIN [dbo].[Member] AS m
        ON m.MemberId = br.MemberId
    WHERE
        (@SearchBy = 'CopyCode' 
            AND bc.CopyCode LIKE '%' + @SearchText + '%')
        OR
        (@SearchBy = 'ISBN' 
            AND b.ISBN LIKE '%' + @SearchText + '%')
        OR
        (@SearchBy = 'Phone' 
            AND m.Phone LIKE '%' + @SearchText + '%')
        OR
        (@SearchBy = 'MemberCode' 
            AND m.MemberCode LIKE '%' + @SearchText + '%');
END;