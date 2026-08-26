CREATE   PROCEDURE [dbo].[UpdateMember]
    @MemberId int,
    @MemberCode NVARCHAR(50),
    @Name       NVARCHAR(255),
    @Phone      NVARCHAR(20),
    @Email      NVARCHAR(255),
    @Address    NVARCHAR(500),
    @Status     int
AS
BEGIN
update [dbo].[Member]

set
        MemberCode = @MemberCode ,
        Name = @Name,
        [Phone] = @Phone,
        [Email] = @Email,
        [Address] = @Address ,
        [Status] = @Status
        where Memberid = @Memberid
    
END;