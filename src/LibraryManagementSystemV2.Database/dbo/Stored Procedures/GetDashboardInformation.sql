
CREATE PROCEDURE [dbo].[GetDashboardInformation]
    @PageNumber INT = 1,
    @PageSize INT = 10
AS
BEGIN


    SELECT 
        COUNT(*) AS TotalBooks
    FROM [dbo].[BookCopy];


    SELECT 
        COUNT(*) AS AvailableCopies
    FROM [dbo].[BookCopy]
    WHERE [Status] = 1;


    SELECT 
        COUNT(*) AS BorrowedCopies
    FROM [dbo].[BookCopy]
    WHERE [Status] = 2;


    SELECT 
        COUNT(*) AS Members
    FROM [dbo].[Member];


 

    SELECT 
        COUNT(*) AS TotalRecords
    FROM [dbo].[BorrowRecord] AS br
    WHERE br.IssueDate >= DATEADD(DAY, -15, GETDATE())
      AND br.ReturnDate IS NULL;

    SELECT 
        b.Title,
        m.Name,
        br.IssueDate,
        br.DueDate
    FROM [dbo].[BorrowRecord] AS br

    INNER JOIN [dbo].[BookCopy] AS bc
        ON br.CopyId = bc.CopyId

    INNER JOIN [dbo].[Book] AS b
        ON bc.BookId = b.BookId

    INNER JOIN [dbo].[Member] AS m
        ON m.MemberId = br.MemberId

    WHERE br.IssueDate >= DATEADD(DAY, -15, GETDATE())
      AND br.ReturnDate IS NULL

    ORDER BY 
        br.IssueDate DESC,
        br.BorrowId DESC

    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

  
END;