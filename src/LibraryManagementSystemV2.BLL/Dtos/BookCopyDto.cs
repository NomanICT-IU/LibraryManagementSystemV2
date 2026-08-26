namespace LibraryManagementSystemV2.BLL.Dtos;

public class BookCopyDto
{
    public int CopyId { get; set; }
    public string CopyCode { get; set; }
    public int BookId { get; set; }
    public int Status { get; set; }
}
