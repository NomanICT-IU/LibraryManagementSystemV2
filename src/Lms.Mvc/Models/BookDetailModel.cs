namespace Lms.Mvc.Models;

public class BookDetailResponseModel
{

    public int TotalRecords { get; set; }
    public List<BookDetailModel> BookCopyList { get; set; }
}


public class BookDetailModel
{
    public int CopyId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public string CopyCode { get; set; }
    public string Status { get; set; }
    public string BorrowedBy { get; set; }
    public DateTime? DueDate { get; set; }
}
