
CREATE PROCEDURE [dbo].[GetBookCopyList]
    @PageNumber INT = 1,
    @PageSize INT = 10,
    @SearchText NVARCHAR(30) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Normalize search text
    SET @SearchText = NULLIF(LTRIM(RTRIM(@SearchText)), '');

    -- Validate pagination
    IF @PageNumber < 1
        SET @PageNumber = 1;

    IF @PageSize < 1
        SET @PageSize = 10;

    -- Temporary table
    CREATE TABLE #FilteredBookCopies
    (
        CopyId INT,
        CopyCode NVARCHAR(50),
        Title NVARCHAR(256),
        Status INT
    );

    -- Insert filtered records
    INSERT INTO #FilteredBookCopies
    (
        CopyId,
        CopyCode,
        Title,
        Status
    )
    SELECT
        bc.CopyId,
        bc.CopyCode,
        b.Title,
        bc.Status
    FROM dbo.BookCopy AS bc
    INNER JOIN dbo.Book AS b
        ON bc.BookId = b.BookId
    WHERE
        @SearchText IS NULL
        OR bc.CopyCode LIKE '%' + @SearchText + '%'
        OR b.Title LIKE '%' + @SearchText + '%';

    -- Total matching records
    DECLARE @TotalRecords INT;

    SELECT @TotalRecords = COUNT(1)
    FROM #FilteredBookCopies;

    -- Paginated records
    SELECT
        CopyId,
        CopyCode,
        Title,
        Status
    FROM #FilteredBookCopies
    ORDER BY CopyId DESC
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

    -- Return total records
    SELECT @TotalRecords AS TotalRecords;

    DROP TABLE #FilteredBookCopies;
END;