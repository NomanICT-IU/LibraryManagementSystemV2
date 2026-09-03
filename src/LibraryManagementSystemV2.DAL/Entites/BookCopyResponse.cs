namespace LibraryManagementSystemV2.DAL.Entites;

public class BookCopyResponse
{

    public List<BookCopies> BookCopies { get; set; }
    public int TotalRecords { get; set; }
}
public class BookCopies
{
    public int CopyId { get; set; }
    public string CopyCode { get; set; }
    public string Title { get; set; }
    public int Status { get; set; }
}