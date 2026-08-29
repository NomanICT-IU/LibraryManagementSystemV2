namespace LibraryManagementSystemV2.BLL.Dtos;

public class BorrowRecordDto
{
    public int BorrowId { get; set; }
    public int CopyId { get; set; }
    public int MemberId { get; set; }

    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }

    public DateTime? ReturnDate { get; set; }
}
