namespace LibraryManagementSystemV2.DAL.Entites;

public class BookAvailabilitySummary
{
    public int BookId { get; set; }
    public int Total { get; set; }
    public int Available { get; set; }
    public int Borrowed { get; set; }
    public string Status { get; set; }
}
