CREATE   PROCEDURE [dbo].[CreateMember]
    @MemberCode NVARCHAR(50),
    @Name       NVARCHAR(255),
    @Phone      NVARCHAR(20),
    @Email      NVARCHAR(255),
    @Address    NVARCHAR(500),
    @Status     int
AS
BEGIN


    INSERT INTO [dbo].[Member]
    (
        [MemberCode],
        [Name],
        [Phone],
        [Email],
        [Address],
        [Status]
    )
    OUTPUT INSERTED.*
    VALUES
    (
        @MemberCode,
        @Name,
        @Phone,
        @Email,
        @Address,
        @Status
    );
END;