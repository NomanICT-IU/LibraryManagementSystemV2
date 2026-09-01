namespace LibraryManagementSystemV2.BLL.Dtos;

public class BookAvailabilitySummaryDto
{
    public int BookId { get; set; }
    public int Total { get; set; }
    public int Available { get; set; }
    public int Borrowed { get; set; }
    public string Status { get; set; }
}