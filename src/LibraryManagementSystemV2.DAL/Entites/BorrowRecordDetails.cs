namespace LibraryManagementSystemV2.DAL.Entites;

public class BorrowRecordDetails
{
    public int BorrowId { get; set; }
    public string Title { get; set; }
    public string CopyCode { get; set; }
    public string Name { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; }
}

//dbo.CreateBorrowRecord,
//CopyId
//MemberId,
//IssueDate,
//DueDate,
