namespace LibraryManagementSystemV2.DAL.Entites;

public class BookListResponse
{
    public int TotalRecords { get; set; }
    public List<Book> BookList { get; set; }
}
