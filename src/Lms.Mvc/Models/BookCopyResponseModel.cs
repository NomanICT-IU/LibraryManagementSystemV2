namespace Lms.Mvc.Models;

public class BookCopyResponseModel
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
    public List<BookCopiesModel> BookCopies { get; set; }

}
public class BookCopiesModel
{
    public int CopyId { get; set; }
    public string CopyCode { get; set; }
    public string Title { get; set; }
    public int Status { get; set; }
}

