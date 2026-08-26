CREATE   PROCEDURE [dbo].[DeleteMember]
    @MemberId int
   
AS
BEGIN

delete from [dbo].[Member]
        where Memberid = @Memberid
    
END;
