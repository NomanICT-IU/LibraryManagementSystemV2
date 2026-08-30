namespace LibraryManagementSystemV2.DAL.Entites;

public class BookCopyStatus
{
    public int BookId { get; set; }
    public string CopyCode { get; set; }
    public string Status { get; set; }
    public string BorrowedBy { get; set; }
    public DateTime? DueDate { get; set; }
}
