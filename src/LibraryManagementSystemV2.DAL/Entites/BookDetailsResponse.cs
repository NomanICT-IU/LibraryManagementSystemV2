namespace LibraryManagementSystemV2.DAL.Entites;

public class BookDetailsResponse
{
    public List<BookInformation> BookInformation { get; set; }
    public List<BookAvailabilitySummary> BookAvailabilitySummary { get; set; }
    public List<CopyInformation> CopyInformation { get; set; }
}
