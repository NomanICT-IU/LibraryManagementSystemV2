namespace Lms.Mvc.Models;

public class BorrowBookSearchModel
{

    public string SearchBy { get; set; }
    public string SearchText { get; set; }
    public List<BorrowBookSearchResultModel> BorrowModel { get; set; }
    public BorrowBookSearchModel()
    {
        BorrowModel = new List<BorrowBookSearchResultModel>();
    }
}



public class BorrowBookSearchResultModel
{
    public int BorrowId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public string CopyCode { get; set; }
    public string Status { get; set; }
    public string Name { get; set; }
    public string MemberCode { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }
}
