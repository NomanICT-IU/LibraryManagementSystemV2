CREATE   PROCEDURE [dbo].[UpdateBook]
    @BookId    INT,
    @Title     NVARCHAR(255),
    @Author    NVARCHAR(255),
    @ISBN      VARCHAR(20),
    @Category  NVARCHAR(100)
AS
BEGIN


    UPDATE [dbo].[Book]
    SET
        [Title]    = @Title,
        [Author]   = @Author,
        [ISBN]     = @ISBN,
        [Category] = @Category
    WHERE [BookId] = @BookId;
END;
