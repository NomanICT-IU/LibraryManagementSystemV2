namespace LibraryManagementSystemV2.DAL.Entites;

public class SearchBookRecordResponse
{
    public BookInformation Book { get; set; }
    public BookCopySummary Summary { get; set; }
    //public List<BookCopyDetails> CopyDetails { get; set; }
    public List<BookCopyStatus> CopyStatus { get; set; }
}
