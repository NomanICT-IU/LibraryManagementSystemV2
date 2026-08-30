CREATE   PROCEDURE [dbo].[FindMember]
    @SearchText NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        m.MemberId,
        m.Name,
        m.MemberCode,
        m.Phone,
        m.Email,
        COUNT(br.BorrowId) AS TotalBorrowedBooks,
        CASE
            WHEN m.Status = 1 THEN 'Active'
            WHEN m.Status = 2 THEN 'Inactive'
            ELSE 'Unknown'
        END AS Status
    FROM [dbo].[Member] AS m
    LEFT JOIN [dbo].[BorrowRecord] AS br
        ON m.MemberId = br.MemberId
    WHERE 
        m.MemberCode = @SearchText
        OR m.Phone = @SearchText
    GROUP BY
        m.MemberId,
        m.Name,
        m.MemberCode,
        m.Phone,
        m.Email,
        m.Status;
END;
