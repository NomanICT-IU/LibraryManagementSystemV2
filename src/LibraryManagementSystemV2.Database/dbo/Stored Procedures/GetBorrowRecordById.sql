CREATE   PROCEDURE [dbo].[GetBorrowRecordById]
    @BorrowId int  
AS
BEGIN
select 
        [CopyId]  ,
        [MemberId]  ,
        [IssueDate] ,
        [DueDate]  ,
        [ReturnDate]
        from [dbo].[BorrowRecord]
        where BorrowId = @BorrowId
    
END;
