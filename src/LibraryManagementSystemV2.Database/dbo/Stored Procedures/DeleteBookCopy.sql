CREATE   PROCEDURE [dbo].[DeleteBookCopy]
    @CopyId INT
AS
BEGIN

    DELETE FROM [dbo].[BookCopy]
    WHERE [CopyId] = @CopyId;
END;
