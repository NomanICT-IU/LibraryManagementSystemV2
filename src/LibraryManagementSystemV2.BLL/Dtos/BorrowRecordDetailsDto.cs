namespace LibraryManagementSystemV2.BLL.Dtos;

public class BorrowRecordDetailsDto
{
    public int BorrowId { get; set; }
    public string Title { get; set; }
    public string CopyCode { get; set; }
    public string Name { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; }
}
