namespace LibraryManagementSystemV2.BLL.Dtos;

public class BorrowBookSearchResultDto
{
    public int BorrowId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public string CopyCode { get; set; }
    public string Status { get; set; }
    public string Name { get; set; }
    public string MemberCode { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }
}
