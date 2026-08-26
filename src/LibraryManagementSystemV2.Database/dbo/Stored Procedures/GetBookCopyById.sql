CREATE   PROCEDURE [dbo].[GetBookCopyById]
    @CopyId INT
AS
BEGIN
    SELECT
        [CopyId],
        [CopyCode],
        [BookId],
        [Status]
    FROM [dbo].[BookCopy]
    WHERE [CopyId] = @CopyId;
END;
