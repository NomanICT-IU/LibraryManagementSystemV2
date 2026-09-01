namespace LibraryManagementSystemV2.BLL.Dtos;

public class CopyInformationDto
{
    public int BookId { get; set; }
    public string CopyCode { get; set; }
    public string Status { get; set; }
    public string BorrowedBy { get; set; }
    public DateTime? DueDate { get; set; }
}