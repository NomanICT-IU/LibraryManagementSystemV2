namespace LibraryManagementSystemV2.DAL.Entites;

public class BorrowRecord
{
    public int BorrowId { get; set; }
    public int CopyId { get; set; }
    public int MemberId { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime ReturnDate { get; set; }
}
