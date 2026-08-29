namespace LibraryManagementSystemV2.BLL.Dtos;

public class ReturnedBookDto
{
    public string Title { get; set; }
    public string CopyCode { get; set; }
    public string Name { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string Status { get; set; }
}
