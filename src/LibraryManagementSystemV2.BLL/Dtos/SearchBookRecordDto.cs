namespace LibraryManagementSystemV2.BLL.Dtos;

public class SearchBookRecordDto
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public string CopyCode { get; set; }
    public string Status { get; set; }
    public string Name { get; set; }
    public DateTime DueDate { get; set; }
}
