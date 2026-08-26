CREATE   PROCEDURE [dbo].[CreateBookCopy]
    @CopyCode NVARCHAR(50),
    @BookId   INT,
    @Status   INT
AS
BEGIN


    INSERT INTO [dbo].[BookCopy]
    (
        [CopyCode],
        [BookId],
        [Status]
    )
    OUTPUT INSERTED.*
    VALUES
    (
        @CopyCode,
        @BookId,
        @Status
    );
END;
