 CREATE   PROCEDURE [dbo].[CreateBook]
    @Title    NVARCHAR(255),
    @Author   NVARCHAR(255),
    @ISBN     VARCHAR(20),
    @Category NVARCHAR(100)
AS
BEGIN
    

    INSERT INTO [dbo].[Book]
    (
        [Title],
        [Author],
        [ISBN],
        [Category]
    )
    OUTPUT INSERTED.*
    VALUES
    (
        @Title,
        @Author,
        @ISBN,
        @Category
    );
END;
