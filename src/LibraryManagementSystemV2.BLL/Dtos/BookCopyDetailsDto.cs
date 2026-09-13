namespace LibraryManagementSystemV2.BLL.Dtos;

public class BookCopyDetailsReponseDto
{
    public int TotalRecords { get; set; }
    public List<BookCopyDetailsDto> BookCopyList { get; set; }
}
public class BookCopyDetailsDto
{
    public int CopyId { get; set; }
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public string CopyCode { get; set; }
    public string Status { get; set; }
    public string BorrowedBy { get; set; }
    public DateTime? DueDate { get; set; }
}
