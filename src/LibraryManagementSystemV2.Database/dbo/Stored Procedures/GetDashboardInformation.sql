 CREATE   PROCEDURE [dbo].[GetDashboardInformation]
AS
BEGIN
  
    SELECT COUNT(*) AS TotalBooks
    FROM [dbo].[BookCopy];


 
    SELECT COUNT(*) AS AvailableCopies
    FROM [dbo].[BookCopy]
    WHERE [Status] = 1;



    SELECT COUNT(*) AS BorrowedCopies
    FROM [dbo].[BookCopy]
    WHERE [Status] = 2;



    SELECT COUNT(*) AS Members
    FROM [dbo].[Member];


 
    SELECT 
        b.Title ,
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
    ORDER BY br.IssueDate DESC;

END;