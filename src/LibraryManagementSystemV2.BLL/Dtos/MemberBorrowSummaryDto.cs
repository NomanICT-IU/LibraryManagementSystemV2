namespace LibraryManagementSystemV2.BLL.Dtos;

public class MemberBorrowSummaryDto
{
    public int TotalBorrowed { get; set; }
    public int CurrentlyBorrowed { get; set; }
    public int OverdueBooks { get; set; }
    public DateTime? LastBorrowed { get; set; }
}
