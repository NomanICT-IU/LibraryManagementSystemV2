CREATE   PROCEDURE [dbo].[GetMemberById]
    @MemberId int
   
AS
BEGIN

select 
        MemberId,
        MemberCode ,
        Name ,
        [Phone] ,
        [Email] ,
        [Address]  ,
        [Status] from [dbo].[Member]
        where Memberid = @Memberid
    
END;