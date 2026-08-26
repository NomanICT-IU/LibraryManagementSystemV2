CREATE   PROCEDURE [dbo].[UpdateBookCopy]
    @CopyId   INT,
    @CopyCode NVARCHAR(50),
    @BookId   INT,
    @Status   INT
AS
BEGIN
 
    UPDATE [dbo].[BookCopy]
    SET
        [CopyCode] = @CopyCode,
        [BookId]   = @BookId,
        [Status]   = @Status

    WHERE [CopyId] = @CopyId;
END;
