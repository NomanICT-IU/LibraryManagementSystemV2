namespace Lms.Mvc.Models;

public class BookListResponseModel
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
    public List<BookModel> BookList { get; set; }
}