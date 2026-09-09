namespace Lms.Mvc.Models.ViewModels;

public class BookDetailsResponseViewModel
{
    public string SearchBy { get; set; }
    public string SearchText { get; set; }
    public List<BookInformationModel> BookInfoModel { get; set; }
    public List<BookAvailabilitySummaryModel> BookSummaryModel { get; set; }
    public List<CopyInformationModel> CopyInfoModel { get; set; }
    public BookDetailsResponseViewModel()
    {
        var BookInfoModel = new List<BookInformationModel>();
        var BookSummaryModel = new List<BookAvailabilitySummaryModel>();
        var CopyInfoModel = new List<CopyInformationModel>();
    }

}
public class BookInformationModel
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public string Category { get; set; }
}
public class BookAvailabilitySummaryModel
{
    public int BookId { get; set; }
    public int Total { get; set; }
    public int Available { get; set; }
    public int Borrowed { get; set; }
    public string Status { get; set; }
}
public class CopyInformationModel
{
    public int BookId { get; set; }
    public string CopyCode { get; set; }
    public string Status { get; set; }
    public string BorrowedBy { get; set; }
    public DateTime? DueDate { get; set; }
}