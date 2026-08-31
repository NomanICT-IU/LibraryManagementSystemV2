namespace Lms.Mvc.Models;

public class DashBoardModel
{
    public int TotalBoks { get; set; }
    public int AvailableCopies { get; set; }
    public int BorrowedCopies { get; set; }
    public int Member { get; set; }
    public List<RecentBoardBookModel> RecentBoardBooks { get; set; }
}
public class RecentBoardBookModel
{
    public string Title { get; set; }
    public string Name { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }
}
