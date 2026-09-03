CREATE    PROCEDURE [dbo].[GetBookList]
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

    -- Create temporary table
    CREATE TABLE #FilteredBooks
    (
        BookId INT NOT NULL,
        Title NVARCHAR(256),
        Author NVARCHAR(50),
        ISBN NVARCHAR(50),
        Category NVARCHAR(50)
    );

    -- Insert filtered records
    INSERT INTO #FilteredBooks
    (
        BookId,
        Title,
        Author,
        ISBN,
        Category
    )
    SELECT
        BookId,
        Title,
        Author,
        ISBN,
        Category
    FROM dbo.Book
    WHERE
        @SearchText IS NULL
        OR Title LIKE '%' + @SearchText + '%'
        OR Author LIKE '%' + @SearchText + '%'
        OR ISBN LIKE '%' + @SearchText + '%'
        OR Category LIKE '%' + @SearchText + '%';

    -- Get total matching records
    DECLARE @TotalRecords INT;

    SELECT @TotalRecords = COUNT(1)
    FROM #FilteredBooks;

    -- Get paginated records
    SELECT
        BookId,
        Title,
        Author,
        ISBN,
        Category
    FROM #FilteredBooks
    ORDER BY BookId DESC
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

    -- Return total records
    SELECT @TotalRecords AS TotalRecords;

    -- Cleanup
    DROP TABLE #FilteredBooks;
END;