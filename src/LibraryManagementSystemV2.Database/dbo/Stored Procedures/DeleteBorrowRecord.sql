CREATE   PROCEDURE [dbo].[DeleteBorrowRecord]
    @BorrowId int
   
AS
BEGIN

delete  from [dbo].[BorrowRecord]
        where BorrowId = @BorrowId
    
END;
