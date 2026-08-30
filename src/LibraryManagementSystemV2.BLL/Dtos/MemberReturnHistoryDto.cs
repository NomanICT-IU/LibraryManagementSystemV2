namespace LibraryManagementSystemV2.BLL.Dtos;

public class MemberReturnHistoryDto
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string CopyCode { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}
