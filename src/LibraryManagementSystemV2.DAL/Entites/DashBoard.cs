namespace LibraryManagementSystemV2.DAL.Entites;

public class DashBoard
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public int TotalBoks { get; set; }
    public int AvailableCopies { get; set; }
    public int BorrowedCopies { get; set; }
    public int Members { get; set; }

    public int TotalRecords { get; set; }

    public List<RecentBorrowedBook> RecentBorrowedBooks { get; set; }
}
public class RecentBorrowedBook
{
    public string Title { get; set; }
    public string Name { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }
}