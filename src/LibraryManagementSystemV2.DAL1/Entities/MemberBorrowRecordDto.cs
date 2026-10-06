namespace LibraryManagementSystemV2.DAL1.Entities;

public class MemberBorrowRecordDto
{
    public string Title { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}
