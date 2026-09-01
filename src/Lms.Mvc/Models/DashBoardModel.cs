namespace Lms.Mvc.Models;

public class DashBoardModel
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalBoks { get; set; }
    public int AvailableCopies { get; set; }
    public int BorrowedCopies { get; set; }
    public int Members { get; set; }
    public int TotalRecords { get; set; }
    public List<RecentBorrowedBookModel> RecentBorrowedBooks { get; set; }
}
public class RecentBorrowedBookModel
{
    public string Title { get; set; }
    public string Name { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }
}
