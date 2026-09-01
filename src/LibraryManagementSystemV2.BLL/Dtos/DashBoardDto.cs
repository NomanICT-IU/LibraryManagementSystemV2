namespace LibraryManagementSystemV2.BLL.Dtos;

public class DashBoardDto
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalBoks { get; set; }
    public int AvailableCopies { get; set; }
    public int BorrowedCopies { get; set; }
    public int Members { get; set; }
    public int TotalRecords { get; set; }
    public List<RecentBorrowedBookDto> RecentBorrowedBooks { get; set; }
}
public class RecentBorrowedBookDto
{
    public string Title { get; set; }
    public string Name { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }
}