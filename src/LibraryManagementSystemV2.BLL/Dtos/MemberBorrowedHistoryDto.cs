namespace LibraryManagementSystemV2.BLL.Dtos;

public class MemberBorrowedHistoryDto
{
    public int BorrowId { get; set; }
    public int BookId { get; set; }
    public string Title { get; set; }
    public string CopyCode { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }
}
