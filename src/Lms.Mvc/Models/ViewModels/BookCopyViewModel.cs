namespace Lms.Mvc.Models.ViewModels;

public class BookCopyViewModel
{
    //public string BookTitle { get; set; }
    public BookCopyModel BookCopy { get; set; }
    public IEnumerable<BookCopyResponseModel> BookCopies { get; set; }
    public BookCopyViewModel()
    {
        BookCopies = new List<BookCopyResponseModel>();
        BookCopy = new BookCopyModel();
    }

}
