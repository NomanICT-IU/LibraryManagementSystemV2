CREATE   PROCEDURE [dbo].[GetMemberList]
    @PageNumber INT = 1,
    @PageSize INT = 10,
    @SearchText NVARCHAR(30) = NULL
AS
BEGIN
    -- Normalize search text
    SET @SearchText = NULLIF(LTRIM(RTRIM(@SearchText)), '');

    -- Validate pagination
    IF @PageNumber < 1
        SET @PageNumber = 1;

    IF @PageSize < 1
        SET @PageSize = 10;

    -- Temporary table
    CREATE TABLE #FilteredMembers
    (
        MemberId INT NOT NULL,
        MemberCode NVARCHAR(50),
        Name NVARCHAR(100),
        Phone NVARCHAR(20),
        Email NVARCHAR(50),
        Address NVARCHAR(256),
        Status int
    );

    -- Insert filtered records
    INSERT INTO #FilteredMembers
    (
        MemberId,
        MemberCode,
        Name,
        Phone,
        Email,
        Address,
        Status
    )
    SELECT
        MemberId,
        MemberCode,
        Name,
        Phone,
        Email,
        Address,
        Status
    FROM dbo.Member
    WHERE
        @SearchText IS NULL
        OR MemberCode LIKE '%' + @SearchText + '%'
        OR Name LIKE '%' + @SearchText + '%'
        OR Phone LIKE '%' + @SearchText + '%'
        OR Email LIKE '%' + @SearchText + '%'
        OR Address LIKE '%' + @SearchText + '%';

    -- Total matching records
    DECLARE @TotalRecords INT;

    SELECT @TotalRecords = COUNT(1)
    FROM #FilteredMembers;

    -- Paginated records
    SELECT
        MemberId,
        MemberCode,
        Name,
        Phone,
        Email,
        Address,
      status 
    FROM #FilteredMembers
    ORDER BY MemberId DESC
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

    -- Return total records
    SELECT @TotalRecords AS TotalRecords;

    DROP TABLE #FilteredMembers;
END;