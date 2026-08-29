namespace LibraryManagementSystemV2.BLL.Dtos;

public class DashBoardDto
{
    public int TotalBoks { get; set; }
    public int AvailableCopies { get; set; }
    public int BorrowedCopies { get; set; }
    public int Member { get; set; }
    public List<RecentBoardBookDto> RecentBoardBooks { get; set; }
}
