namespace LibraryManagementSystemV2.DAL.Entites;

public class DashBoard
{
    public int TotalBoks { get; set; }
    public int AvailableCopies { get; set; }
    public int BorrowedCopies { get; set; }
    public int Member { get; set; }
    public List<RecentBoardBook> RecentBoardBooks { get; set; }
}
